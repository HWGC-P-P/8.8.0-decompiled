using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_FillXY : Form
	{
		private Coordinate mPoint;

		private int mH_Value;

		private int mH_Sign;

		private float mV_F;

		private int mV_I;

		public List<LanguageItem> mLanguageList = new List<LanguageItem>();

		private IContainer components;

		private NumericUpDown numericUpDown_X;

		private NumericUpDown numericUpDown_Y;

		private Label label1;

		private Label label2;

		private Button button_ok;

		private Button button_cancel;

		private Panel panel_xy;

		private Panel panel_z;

		private Label label3;

		private NumericUpDown numericUpDown_Z;

		private Panel panel_v_f;

		private NumericUpDown numericUpDown_V_f;

		private Label label4;

		private Label label_title;

		private Panel panel_v_i;

		private NumericUpDown numericUpDown_V_i;

		private Label label5;

		private void updateLanguage(int mLanguage)
		{
			foreach (LanguageItem mLanguage2 in mLanguageList)
			{
				mLanguage2.ctrl.Text = mLanguage2.str[mLanguage];
				if (mLanguage2.font != null && mLanguage2.fsize != null)
				{
					mLanguage2.ctrl.Font = new Font(mLanguage2.font[mLanguage], mLanguage2.ctrl.Font.Size + mLanguage2.fsize[mLanguage], mLanguage2.ctrl.Font.Style);
					continue;
				}
				switch (mLanguage)
				{
				case 2:
					mLanguage2.ctrl.Font = new Font("Oswald", mLanguage2.ctrl.Font.Size, FontStyle.Regular);
					break;
				case 0:
				case 1:
					mLanguage2.ctrl.Font = new Font("微软雅黑", mLanguage2.ctrl.Font.Size, mLanguage2.ctrl.Font.Style);
					break;
				}
			}
		}

		private void initLanguageTable()
		{
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label_title,
				str = new string[3] { "", "", "" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_ok,
				str = new string[3] { "确定", "确定", "OK" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = button_cancel,
				str = new string[3] { "取消", "取消", "CANCEL" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label4,
				str = new string[3] { "数值修改", "数值修改", "Value Edit" }
			});
			mLanguageList.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label5,
				str = new string[3] { "数值修改", "数值修改", "Value Edit" }
			});
		}

		public Form_FillXY(object o, int lan, string mode)
		{
			InitializeComponent();
			base.Size = new Size(481, 188);
			panel_z.Location = (panel_v_f.Location = (panel_v_i.Location = panel_xy.Location));
			panel_z.Visible = (panel_v_f.Visible = (panel_v_i.Visible = (panel_xy.Visible = false)));
			initLanguageTable();
			updateLanguage(lan);
			switch (mode)
			{
			case "XY":
			{
				label_title.Text = ((lan == 2) ? "XY Coordinate Edit" : "XY坐标数据设置");
				panel_xy.Visible = true;
				Coordinate coordinate = (Coordinate)o;
				mPoint = new Coordinate(coordinate.X, coordinate.Y);
				numericUpDown_X.Value = mPoint.X;
				numericUpDown_Y.Value = mPoint.Y;
				break;
			}
			case "Z":
			{
				label_title.Text = ((lan == 2) ? "Height Value Edit" : "高度数据设置");
				panel_z.Visible = true;
				int num = (int)o;
				mH_Value = Math.Abs(num);
				mH_Sign = ((num > 0) ? 1 : (-1));
				numericUpDown_Z.Value = mH_Value;
				break;
			}
			case "V_F":
				label_title.Text = "";
				panel_v_f.Visible = true;
				mV_F = (float)o;
				numericUpDown_V_f.Value = (decimal)mV_F;
				break;
			case "V_I":
				label_title.Text = "";
				panel_v_i.Visible = true;
				mV_I = (int)o;
				numericUpDown_V_i.Value = mV_I;
				break;
			}
			if (lan == 2)
			{
				button_ok.Text = "OK";
				button_cancel.Text = "Cancel";
			}
		}

		public Form_FillXY(int o, int lan, string mode, int min_v, int max_v, string title)
		{
			InitializeComponent();
			base.Size = new Size(481, 188);
			panel_z.Location = (panel_v_f.Location = (panel_v_i.Location = panel_xy.Location));
			panel_z.Visible = (panel_v_f.Visible = (panel_v_i.Visible = (panel_xy.Visible = false)));
			label_title.Text = title;
			initLanguageTable();
			updateLanguage(lan);
			if (mode == "V_I")
			{
				panel_v_i.Visible = true;
				mV_I = o;
				numericUpDown_V_i.Minimum = min_v;
				numericUpDown_V_i.Maximum = max_v;
				if (o <= min_v)
				{
					mV_I = min_v;
				}
				else if (o >= max_v)
				{
					mV_I = max_v;
				}
				else
				{
					mV_I = o;
				}
				numericUpDown_V_i.Value = mV_I;
			}
			if (lan == 2)
			{
				button_ok.Text = "OK";
				button_cancel.Text = "Cancel";
			}
		}

		public Form_FillXY(float o, int lan, string mode, float min_v, float max_v, string title)
		{
			InitializeComponent();
			base.Size = new Size(481, 188);
			panel_z.Location = (panel_v_f.Location = (panel_v_i.Location = panel_xy.Location));
			panel_z.Visible = (panel_v_f.Visible = (panel_v_i.Visible = (panel_xy.Visible = false)));
			label_title.Text = title;
			initLanguageTable();
			updateLanguage(lan);
			if (mode == "V_F")
			{
				panel_v_f.Visible = true;
				mV_F = o;
				numericUpDown_V_f.Minimum = (decimal)min_v;
				numericUpDown_V_f.Maximum = (decimal)max_v;
				if (mV_F <= min_v)
				{
					mV_F = min_v;
				}
				else if (mV_F >= max_v)
				{
					mV_F = max_v;
				}
				numericUpDown_V_f.Value = (decimal)mV_F;
			}
			if (lan == 2)
			{
				button_ok.Text = "OK";
				button_cancel.Text = "Cancel";
			}
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		public Coordinate Get_FillXY()
		{
			return mPoint;
		}

		public int Get_FillZ()
		{
			return mH_Value * mH_Sign;
		}

		public float Get_Fill_V_F()
		{
			return mV_F;
		}

		public int Get_Fill_V_I()
		{
			return mV_I;
		}

		private void numericUpDown_X_ValueChanged(object sender, EventArgs e)
		{
			mPoint.X = (int)numericUpDown_X.Value;
		}

		private void numericUpDown_Y_ValueChanged(object sender, EventArgs e)
		{
			mPoint.Y = (int)numericUpDown_Y.Value;
		}

		private void numericUpDown_Z_ValueChanged(object sender, EventArgs e)
		{
			mH_Value = (int)numericUpDown_Z.Value;
		}

		private void numericUpDown_V_f_ValueChanged(object sender, EventArgs e)
		{
			mV_F = (float)numericUpDown_V_f.Value;
		}

		private void numericUpDown_V_i_ValueChanged(object sender, EventArgs e)
		{
			mV_I = (int)numericUpDown_V_i.Value;
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
			numericUpDown_X = new System.Windows.Forms.NumericUpDown();
			numericUpDown_Y = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			button_ok = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			panel_xy = new System.Windows.Forms.Panel();
			panel_z = new System.Windows.Forms.Panel();
			numericUpDown_Z = new System.Windows.Forms.NumericUpDown();
			label3 = new System.Windows.Forms.Label();
			panel_v_f = new System.Windows.Forms.Panel();
			numericUpDown_V_f = new System.Windows.Forms.NumericUpDown();
			label4 = new System.Windows.Forms.Label();
			label_title = new System.Windows.Forms.Label();
			panel_v_i = new System.Windows.Forms.Panel();
			numericUpDown_V_i = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)numericUpDown_X).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_Y).BeginInit();
			panel_xy.SuspendLayout();
			panel_z.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_Z).BeginInit();
			panel_v_f.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_V_f).BeginInit();
			panel_v_i.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_V_i).BeginInit();
			SuspendLayout();
			numericUpDown_X.Font = new System.Drawing.Font("微软雅黑", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_X.Location = new System.Drawing.Point(37, 9);
			numericUpDown_X.Margin = new System.Windows.Forms.Padding(4);
			numericUpDown_X.Maximum = new decimal(new int[4] { 100000, 0, 0, 0 });
			numericUpDown_X.Name = "numericUpDown_X";
			numericUpDown_X.Size = new System.Drawing.Size(105, 27);
			numericUpDown_X.TabIndex = 0;
			numericUpDown_X.ValueChanged += new System.EventHandler(numericUpDown_X_ValueChanged);
			numericUpDown_Y.Font = new System.Drawing.Font("微软雅黑", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			numericUpDown_Y.Location = new System.Drawing.Point(191, 9);
			numericUpDown_Y.Margin = new System.Windows.Forms.Padding(4);
			numericUpDown_Y.Maximum = new decimal(new int[4] { 100000, 0, 0, 0 });
			numericUpDown_Y.Name = "numericUpDown_Y";
			numericUpDown_Y.Size = new System.Drawing.Size(105, 27);
			numericUpDown_Y.TabIndex = 0;
			numericUpDown_Y.ValueChanged += new System.EventHandler(numericUpDown_Y_ValueChanged);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(13, 10);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(15, 15);
			label1.TabIndex = 1;
			label1.Text = "X";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(168, 10);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(15, 15);
			label2.TabIndex = 1;
			label2.Text = "Y";
			button_ok.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_ok.Location = new System.Drawing.Point(143, 102);
			button_ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_ok.Name = "button_ok";
			button_ok.Size = new System.Drawing.Size(67, 30);
			button_ok.TabIndex = 2;
			button_ok.Text = "确定";
			button_ok.UseVisualStyleBackColor = true;
			button_ok.Click += new System.EventHandler(button_ok_Click);
			button_cancel.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_cancel.Location = new System.Drawing.Point(259, 102);
			button_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(67, 30);
			button_cancel.TabIndex = 2;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			panel_xy.Controls.Add(label2);
			panel_xy.Controls.Add(label1);
			panel_xy.Controls.Add(numericUpDown_Y);
			panel_xy.Controls.Add(numericUpDown_X);
			panel_xy.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel_xy.Location = new System.Drawing.Point(73, 44);
			panel_xy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel_xy.Name = "panel_xy";
			panel_xy.Size = new System.Drawing.Size(320, 36);
			panel_xy.TabIndex = 3;
			panel_z.Controls.Add(numericUpDown_Z);
			panel_z.Controls.Add(label3);
			panel_z.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel_z.Location = new System.Drawing.Point(75, 62);
			panel_z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel_z.Name = "panel_z";
			panel_z.Size = new System.Drawing.Size(321, 34);
			panel_z.TabIndex = 4;
			numericUpDown_Z.Location = new System.Drawing.Point(119, 6);
			numericUpDown_Z.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			numericUpDown_Z.Maximum = new decimal(new int[4] { 20000, 0, 0, 0 });
			numericUpDown_Z.Name = "numericUpDown_Z";
			numericUpDown_Z.Size = new System.Drawing.Size(107, 25);
			numericUpDown_Z.TabIndex = 2;
			numericUpDown_Z.ValueChanged += new System.EventHandler(numericUpDown_Z_ValueChanged);
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(84, 9);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(15, 15);
			label3.TabIndex = 1;
			label3.Text = "Z";
			panel_v_f.Controls.Add(numericUpDown_V_f);
			panel_v_f.Controls.Add(label4);
			panel_v_f.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel_v_f.Location = new System.Drawing.Point(73, 88);
			panel_v_f.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel_v_f.Name = "panel_v_f";
			panel_v_f.Size = new System.Drawing.Size(320, 26);
			panel_v_f.TabIndex = 5;
			numericUpDown_V_f.DecimalPlaces = 2;
			numericUpDown_V_f.Increment = new decimal(new int[4] { 1, 0, 0, 131072 });
			numericUpDown_V_f.Location = new System.Drawing.Point(143, 2);
			numericUpDown_V_f.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			numericUpDown_V_f.Name = "numericUpDown_V_f";
			numericUpDown_V_f.Size = new System.Drawing.Size(107, 25);
			numericUpDown_V_f.TabIndex = 1;
			numericUpDown_V_f.ValueChanged += new System.EventHandler(numericUpDown_V_f_ValueChanged);
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(64, 4);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(71, 15);
			label4.TabIndex = 0;
			label4.Text = "数值修改";
			label_title.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_title.Location = new System.Drawing.Point(1, -3);
			label_title.Name = "label_title";
			label_title.Size = new System.Drawing.Size(472, 42);
			label_title.TabIndex = 6;
			label_title.Text = "数据修改主题";
			label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel_v_i.Controls.Add(numericUpDown_V_i);
			panel_v_i.Controls.Add(label5);
			panel_v_i.Font = new System.Drawing.Font("楷体", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			panel_v_i.Location = new System.Drawing.Point(73, 129);
			panel_v_i.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			panel_v_i.Name = "panel_v_i";
			panel_v_i.Size = new System.Drawing.Size(317, 30);
			panel_v_i.TabIndex = 7;
			numericUpDown_V_i.Location = new System.Drawing.Point(154, 4);
			numericUpDown_V_i.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			numericUpDown_V_i.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			numericUpDown_V_i.Minimum = new decimal(new int[4] { 1000, 0, 0, -2147483648 });
			numericUpDown_V_i.Name = "numericUpDown_V_i";
			numericUpDown_V_i.Size = new System.Drawing.Size(107, 25);
			numericUpDown_V_i.TabIndex = 1;
			numericUpDown_V_i.ValueChanged += new System.EventHandler(numericUpDown_V_i_ValueChanged);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(60, 9);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(71, 15);
			label5.TabIndex = 0;
			label5.Text = "数值修改";
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.CadetBlue;
			base.ClientSize = new System.Drawing.Size(475, 159);
			base.Controls.Add(panel_v_i);
			base.Controls.Add(label_title);
			base.Controls.Add(panel_v_f);
			base.Controls.Add(panel_z);
			base.Controls.Add(panel_xy);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_ok);
			Font = new System.Drawing.Font("楷体", 12.25f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "Form_FillXY";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)numericUpDown_X).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_Y).EndInit();
			panel_xy.ResumeLayout(false);
			panel_xy.PerformLayout();
			panel_z.ResumeLayout(false);
			panel_z.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_Z).EndInit();
			panel_v_f.ResumeLayout(false);
			panel_v_f.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_V_f).EndInit();
			panel_v_i.ResumeLayout(false);
			panel_v_i.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_V_i).EndInit();
			ResumeLayout(false);
		}
	}
}
