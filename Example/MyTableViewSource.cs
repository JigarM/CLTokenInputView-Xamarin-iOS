using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using CLTokenFieldView;

namespace Example
{
	public class MyTableViewSource : UITableViewSource
	{
		#region Declarations

		public static readonly NSString Key = new NSString("MyTableViewSource");
		List<string> filteredNames;
		CLTokenInputView tokenInputView;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Example.MyTableViewSource"/> class.
		/// </summary>
		public MyTableViewSource(List<string> _filteredNames, CLTokenInputView _tokenInputView)
		{
			filteredNames = _filteredNames;
			tokenInputView = _tokenInputView;
		}
		#endregion

		#region -= data binding/display methods =-

		/// <summary>
		/// Numbers the of sections.
		/// </summary>
		/// <returns>The of sections.</returns>
		/// <param name="tableView">Table view.</param>
		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		/// <summary>
		/// Gets the height for row.
		/// </summary>
		/// <returns>The height for row.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			return 40f;
		}

		/// <summary>
		/// Rowses the in section.
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return filteredNames.Count;
		}
		#endregion

		#region -= user interaction methods =-

		/// <summary>
		/// Rows the selected.
		/// </summary>
		/// <returns>The selected.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true);

			string name = filteredNames[indexPath.Row];
			CLToken token = new CLToken(name, null);
			if (tokenInputView.Editing)
			{
				tokenInputView.AddToken(token);
			}
		}

		#endregion

		#region Get Cell

		/// <summary>
		/// Gets the cell.
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = (UITableViewCell)tableView.DequeueReusableCell(Key);

			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Value1, Key);
			}

			//Cell textlabel
			cell.TextLabel.Text = filteredNames[indexPath.Row];
			cell.TextLabel.Font = UIFont.BoldSystemFontOfSize(15);

			//Set selection style
			cell.SelectionStyle = UITableViewCellSelectionStyle.Default;

			return cell;
		}
	}

	#endregion
}

