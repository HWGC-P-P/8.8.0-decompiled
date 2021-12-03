using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_RunStop : UserControl
	{
		private IContainer components;

		private Button button_run;

		private Button button_stop;

		private Button button_pause;

		public UserControl_RunStop()
		{
			InitializeComponent();
		}

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
			button_run = new System.Windows.Forms.Button();
			button_stop = new System.Windows.Forms.Button();
			button_pause = new System.Windows.Forms.Button();
			SuspendLayout();
			button_run.Font = new System.Drawing.Font("微软雅黑", 48f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_run.Location = new System.Drawing.Point(257, 22);
			button_run.Margin = new System.Windows.Forms.Padding(4);
			button_run.Name = "button_run";
			button_run.Size = new System.Drawing.Size(113, 96);
			button_run.TabIndex = 0;
			button_run.Text = "▶";
			button_run.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			button_run.UseVisualStyleBackColor = true;
			button_stop.Font = new System.Drawing.Font("黑体", 30f);
			button_stop.Location = new System.Drawing.Point(412, 23);
			button_stop.Margin = new System.Windows.Forms.Padding(4);
			button_stop.Name = "button_stop";
			button_stop.Size = new System.Drawing.Size(115, 96);
			button_stop.TabIndex = 0;
			button_stop.Text = "█";
			button_stop.UseVisualStyleBackColor = true;
			button_pause.Font = new System.Drawing.Font("微软雅黑", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_pause.Location = new System.Drawing.Point(89, 22);
			button_pause.Margin = new System.Windows.Forms.Padding(4);
			button_pause.Name = "button_pause";
			button_pause.Size = new System.Drawing.Size(121, 97);
			button_pause.TabIndex = 0;
			button_pause.Text = " ▌▌";
			button_pause.UseVisualStyleBackColor = true;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.Controls.Add(button_stop);
			base.Controls.Add(button_run);
			base.Controls.Add(button_pause);
			Font = new System.Drawing.Font("黑体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.Name = "UserControl_RunStop";
			base.Size = new System.Drawing.Size(622, 135);
			ResumeLayout(false);
		}
	}
}
