using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using CLTokenFieldView;

namespace Example
{
	public partial class ViewController : UIViewController
	{

		#region Declarations
		public List<string> names, filteredNames;
		public List<CLToken> selectedNames;

		//CLTokenInputView
		CLTokenInputView tokenInputView;

		//UITableview
		UITableView tableview;
		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Example.ViewController"/> class.
		/// </summary>
		/// <param name="handle">Handle.</param>
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		#endregion

		#region View Controller override methods

		/// <summary>
		/// Views the did load.
		/// </summary>
		/// <returns>The did load.</returns>
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			names = new List<string> {"John Doe", "Brenden Mulligan", "Cluster Labs, Inc.", "Pat Fives", "Rizwan Sattar", "Taylor Hughes" };
			filteredNames = new List<string>();
			selectedNames = new List<CLToken>();

			//background color
			this.View.BackgroundColor = UIColor.GroupTableViewBackgroundColor;

			//UIButton infoButton = new UIButton(UIButtonType.InfoDark);

			tokenInputView = new CLTokenInputView();
			tokenInputView.Frame = new CoreGraphics.CGRect(0, 64, UIScreen.MainScreen.Bounds.Width, 45);
			tokenInputView.BackgroundColor = UIColor.White;
			tokenInputView.FieldName = "To:";
			tokenInputView.PlaceholderText = "Enter a name";
			tokenInputView.DrawBottomBorder = true;
			tokenInputView.TintColor = UIColor.Orange;
			tokenInputView.Delegate = new TokenInputViewDelegate(this, filteredNames);
			this.View.AddSubview(tokenInputView);

			tableview = new UITableView();
			tableview.Frame = new CoreGraphics.CGRect(0, tokenInputView.Frame.Y + tokenInputView.Frame.Height, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - 100);
			tableview.Source = new MyTableViewSource(filteredNames, tokenInputView);
			this.View.AddSubview(tableview);
		}

		/// <summary>
		/// Views the did appear.
		/// </summary>
		/// <returns>The did appear.</returns>
		/// <param name="animated">Animated.</param>
		public override void ViewDidAppear(bool animated)
		{
			if (!tokenInputView.Editing)
			{
				tokenInputView.BeginEditing();
			}
		}

		#endregion


		#region CLTokenInputViewDelegate

		/// <summary>
		/// Token input view delegate.
		/// </summary>
		public class TokenInputViewDelegate : CLTokenInputViewDelegate
		{
			List<string> filteredNames;
			ViewController vc;

			#region Constructor

			/// <summary>
			/// Initializes a new instance of the <see cref="T:Example.ViewController.TokenInputViewDelegate"/> class.
			/// </summary>
			public TokenInputViewDelegate(ViewController _vc, List<string> _filteredNames)
			{
				vc = _vc;
				filteredNames = _filteredNames;
			}

			#endregion

			#region Override Methods

			/// <summary>
			/// Dids the change text.
			/// </summary>
			/// <returns>The change text.</returns>
			/// <param name="view">View.</param>
			/// <param name="text">Text.</param>
			public override void DidChangeText(CLTokenInputView view, string text)
			{
				if (text.Equals(""))
				{
					filteredNames = null;
					vc.tableview.Hidden = true;
				}
				else {
					filteredNames = vc.names.FindAll(x=>x.Contains(text));
					vc.tableview.Hidden = false;
				}

				if (filteredNames != null)
				{
					vc.tableview.Source = new MyTableViewSource(filteredNames, vc.tokenInputView);
					vc.tableview.ReloadData();
				}
			}

			public override void DidAddToken(CLTokenInputView view, CLToken token)
			{
				string name = token.DisplayText;
				Console.WriteLine("Did Add token => " + name);
				vc.selectedNames.Add(token);
			}

			public override void DidRemoveToken(CLTokenInputView view, CLToken token)
			{
				string name = token.DisplayText;
				Console.WriteLine("Did Remove token => " + name);
				vc.selectedNames.Remove(token);
			}

			#endregion
		}

		#endregion

		#region DidReceiveMemoryWarning

		/// <summary>
		/// Dids the receive memory warning.
		/// </summary>
		/// <returns>The receive memory warning.</returns>
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
		#endregion
	}
}

