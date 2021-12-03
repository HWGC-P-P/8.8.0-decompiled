using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_FeederPara : Form
	{
		private USR_DATA USR;

		private USR_INIT_DATA USR_INIT;

		private IContainer components;

		private Label label1;

		private Panel panel1;

		private Label label2;

		public Form_FeederPara(USR_DATA usr)
		{
			InitializeComponent();
			USR = usr;
			USR_INIT = MainForm0.USR_INIT;
			FeederType[] array = new FeederType[8]
			{
				FeederType.CL8_2_0201,
				FeederType.CL8_2,
				FeederType.CL8_4,
				FeederType.CL12,
				FeederType.CL16,
				FeederType.CL24,
				FeederType.CL32,
				FeederType.CL44
			};
			for (int i = 0; i < array.Count(); i++)
			{
				Label label = new Label
				{
					Text = STR.FEEDER_STR[(int)array[i]][USR_INIT.mLanguage]
				};
				panel1.Controls.Add(label);
				label.Location = new Point(5, 5 + 28 * i);
				NumericUpDown numericUpDown = new NumericUpDown();
				panel1.Controls.Add(numericUpDown);
				numericUpDown.Location = new Point(105, 5 + 28 * i);
				numericUpDown.DecimalPlaces = 0;
				numericUpDown.Minimum = 0m;
				numericUpDown.Maximum = 2000m;
				numericUpDown.Size = new Size(70, 26);
				Label label2 = new Label
				{
					Text = "ms"
				};
				panel1.Controls.Add(label2);
				label2.Location = new Point(177, 5 + 28 * i);
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
			panel1 = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 13f);
			label1.Location = new System.Drawing.Point(158, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(80, 18);
			label1.TabIndex = 0;
			label1.Text = "飞达参数";
			panel1.Location = new System.Drawing.Point(32, 91);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(346, 418);
			panel1.TabIndex = 1;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("黑体", 13f);
			label2.Location = new System.Drawing.Point(29, 54);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(188, 18);
			label2.TabIndex = 0;
			label2.Text = "飞达连续取料换料延时";
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(414, 540);
			base.Controls.Add(panel1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_FeederPara";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
