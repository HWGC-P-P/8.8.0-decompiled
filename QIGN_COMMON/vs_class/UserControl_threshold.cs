using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_threshold : UserControl
	{
		private IContainer components;

		private BackgroundWorker backgroundWorker1;

		private TrackBar trackBar1;

		private Button button_close;

		public UserControl_threshold()
		{
			InitializeComponent();
		}

		private void button_close_Click(object sender, EventArgs e)
		{
			Dispose();
		}

		private void UserControl_threshold_Load(object sender, EventArgs e)
		{
			MainForm0.CreateAddButtonPic(button_close);
		}

		private void UserControl_threshold_MouseLeave(object sender, EventArgs e)
		{
			Dispose();
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
			backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			trackBar1 = new System.Windows.Forms.TrackBar();
			button_close = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
			SuspendLayout();
			trackBar1.Location = new System.Drawing.Point(2, 43);
			trackBar1.Maximum = 255;
			trackBar1.Name = "trackBar1";
			trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
			trackBar1.Size = new System.Drawing.Size(45, 234);
			trackBar1.TabIndex = 1;
			trackBar1.TickFrequency = 10;
			button_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button_close.Location = new System.Drawing.Point(2, 5);
			button_close.Name = "button_close";
			button_close.Size = new System.Drawing.Size(32, 32);
			button_close.TabIndex = 2;
			button_close.Text = "X";
			button_close.UseVisualStyleBackColor = true;
			button_close.Click += new System.EventHandler(button_close_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightBlue;
			base.Controls.Add(button_close);
			base.Controls.Add(trackBar1);
			base.Name = "UserControl_threshold";
			base.Size = new System.Drawing.Size(37, 282);
			base.Load += new System.EventHandler(UserControl_threshold_Load);
			base.MouseLeave += new System.EventHandler(UserControl_threshold_MouseLeave);
			((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
