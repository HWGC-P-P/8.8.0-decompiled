using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_ImportAngle : Form
	{
		private IContainer components;

		private Button button_360;

		private USR_DATA USR;

		private USR_INIT_DATA USR_INIT;

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
			button_360 = new System.Windows.Forms.Button();
			SuspendLayout();
			button_360.BackColor = System.Drawing.Color.PapayaWhip;
			button_360.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_360.Location = new System.Drawing.Point(103, 58);
			button_360.Name = "button_360";
			button_360.Size = new System.Drawing.Size(288, 60);
			button_360.TabIndex = 0;
			button_360.Text = "角度360镜像";
			button_360.UseVisualStyleBackColor = false;
			button_360.Click += new System.EventHandler(button_360_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.CadetBlue;
			base.ClientSize = new System.Drawing.Size(495, 189);
			base.Controls.Add(button_360);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_ImportAngle";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
		}

		public Form_ImportAngle(USR_DATA usr)
		{
			InitializeComponent();
			USR = usr;
			USR_INIT = MainForm0.USR_INIT;
			button_360.Font = new Font(DEF.FONT_2020[USR_INIT.mLanguage], button_360.Font.Size + DEF.FSIZE_2020[USR_INIT.mLanguage], FontStyle.Regular);
			string[] array = new string[3] { "角度360镜像", "角度360镜像", "Angle 360 Mirror Image Processing" };
			button_360.Text = array[USR_INIT.mLanguage];
		}

		private void button_360_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}
	}
}
