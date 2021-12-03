using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_importViewPCB : Form
	{
		private IContainer components;

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			SuspendLayout();
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(1264, 761);
			Font = new System.Drawing.Font("黑体", 12f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_importViewPCB";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
		}

		public Form_importViewPCB()
		{
			InitializeComponent();
		}
	}
}
