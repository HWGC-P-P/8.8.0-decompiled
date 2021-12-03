using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_COMMON.vs_acontrol;
using QIGN_MAIN;

namespace QIGN_COMMON
{
	public class Form_OpenShape : Form
	{
		public int mLanguage;

		private IContainer components;

		private Label label1;

		private CnButton button1;

		private CnButton button2;

		public Form_OpenShape(int lan, string s)
		{
			InitializeComponent();
			mLanguage = lan;
			base.Icon = MainForm0.GetIcon(1);
			base.ControlBox = false;
			button1.Visible = false;
			button2.Visible = false;
			button2.Text = ((lan == 2) ? "Disable Feeder Safety Mode" : "禁用飞达防撞功能");
			button1.Text = ((lan == 2) ? "Continue" : "继续运行");
		}

		public void OpenShape()
		{
			label1.Text = ((mLanguage == 2) ? "Device shape is open, device is Pause!" : "机箱盖已经打开，设备进入暂停状态!");
			button1.Visible = false;
		}

		public void CloseShape()
		{
			label1.Text = ((mLanguage == 2) ? "Device shape is closed, please click to continue!" : "机箱盖已经合上，请点击继续运行");
			button1.Visible = true;
		}

		public void FeederGoodbye()
		{
			label1.Text = ((mLanguage == 2) ? ("Please check safety sensor state! " + Environment.NewLine + "whether feeder or other thing is thumbs-up!" + Environment.NewLine + "Please reset thumbs-up feeder or other thing!") : ("请检查安全传感器工作状态! " + Environment.NewLine + "是否有飞达翘起，异物遮挡!" + Environment.NewLine + "请确保将飞达复位，或将异物清除!"));
			button1.Visible = false;
		}

		public void FeederGoodbye_Clear()
		{
			label1.Text = ((mLanguage == 2) ? "Please make sure thumbs-up feeder or other things is reset!" : "确保飞达翘起已清除，或安全传感器遮挡被清除!");
			button1.Visible = true;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show((mLanguage == 2) ? "Are you sure to disable feeder collision avoidance function?" : "确定要禁用飞达防撞功能吗？", "", MessageBoxButtons.YesNo) == DialogResult.Yes && MessageBox.Show((mLanguage == 2) ? "Please make sure again that to disable feeder collision avoidance function?" : "再次确定要禁用飞达防撞功能吗？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				base.DialogResult = DialogResult.No;
			}
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
			label1 = new System.Windows.Forms.Label();
			button2 = new QIGN_COMMON.vs_acontrol.CnButton();
			button1 = new QIGN_COMMON.vs_acontrol.CnButton();
			SuspendLayout();
			label1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			label1.Font = new System.Drawing.Font("黑体", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(4, 39);
			label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(780, 153);
			label1.TabIndex = 0;
			label1.Text = "机箱盖已经打开，设备进入暂停状态！\r\n\r\n";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button2.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button2.CnPressDownColor = System.Drawing.Color.White;
			button2.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button2.Location = new System.Drawing.Point(12, 249);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(199, 28);
			button2.TabIndex = 2;
			button2.Text = "禁用飞达防撞功能";
			button2.UseVisualStyleBackColor = true;
			button2.Visible = false;
			button2.Click += new System.EventHandler(button2_Click);
			button1.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			button1.CnButtonMode = QIGN_COMMON.vs_acontrol.ButtonModeEn.Standard;
			button1.CnPressDownColor = System.Drawing.Color.White;
			button1.Font = new System.Drawing.Font("黑体", 15f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button1.ForeColor = System.Drawing.Color.White;
			button1.Location = new System.Drawing.Point(263, 226);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(246, 72);
			button1.TabIndex = 1;
			button1.Text = "继续运行";
			button1.UseVisualStyleBackColor = false;
			button1.Click += new System.EventHandler(button1_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.SystemColors.ControlDark;
			base.ClientSize = new System.Drawing.Size(788, 320);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
			base.Name = "Form_OpenShape";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "   ";
			ResumeLayout(false);
		}
	}
}
