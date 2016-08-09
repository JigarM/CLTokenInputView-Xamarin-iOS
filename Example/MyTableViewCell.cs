using System;

using Foundation;
using UIKit;

namespace Example
{
	public partial class MyTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("MyTableViewCell");
		public static readonly UINib Nib;

		static MyTableViewCell()
		{
			Nib = UINib.FromName("MyTableViewCell", NSBundle.MainBundle);
		}

		protected MyTableViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
