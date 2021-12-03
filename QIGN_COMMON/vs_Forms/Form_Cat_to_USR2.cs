using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_Cat_to_USR2 : Form
	{
		public CheckBox checkbox_para_all;

		public CheckBox[] checkbox_para;

		public BindingList<PcatHead> mOverideList;

		public bool mIsOnlyValidData;

		public bool mIsUpdatePikMntH;

		public int mLanguage;

		private IContainer components;

		private Label label1;

		private Button button_RunOveride;

		private Button button_cancle;

		private CheckBox checkBox_only_validdata;

		private CheckBox checkBox_update_pikmnt_H;

		private Panel panel_parameter;

		private Label label2;

		public Form_Cat_to_USR2(int lan)
		{
			InitializeComponent();
			mLanguage = lan;
			label1.Text = ((mLanguage == 2) ? "Overide to Feeder/Plate Setting" : "覆盖到料站料盘参数");
			button_RunOveride.Text = ((mLanguage == 2) ? "Run" : "开始覆盖");
			button_cancle.Text = ((mLanguage == 2) ? "Cancel" : "取消退出");
			checkBox_only_validdata.Text = ((mLanguage == 2) ? "only overide no-zero data" : "仅覆盖非0的有效数据");
			checkBox_update_pikmnt_H.Text = ((mLanguage == 2) ? "update Pik/Mnt Height" : "同时更新取料/贴装高度");
			mOverideList = new BindingList<PcatHead>();
			int num = 16;
			checkbox_para = new CheckBox[num];
			for (int i = 0; i < num; i++)
			{
				checkbox_para[i] = new CheckBox();
				panel_parameter.Controls.Add(checkbox_para[i]);
				checkbox_para[i].Checked = true;
				checkbox_para[i].Size = new Size(115, 20);
				checkbox_para[i].AutoSize = false;
				checkbox_para[i].Text = Form_PcbEdit_Cat.CAT_HEAD[i + 13].str[mLanguage];
				if (i <= 6)
				{
					checkbox_para[i].Location = new Point(5, 2 + 20 * (i + 1));
				}
				else if (i == 15)
				{
					checkbox_para[i].Location = new Point(5, 162);
				}
				else if (i > 6)
				{
					checkbox_para[i].Location = new Point(135, 2 + 20 * (i - 7 + 1));
				}
			}
			checkbox_para_all = new CheckBox();
			panel_parameter.Controls.Add(checkbox_para_all);
			checkbox_para_all.Text = STR.ALL[mLanguage];
			checkbox_para_all.Location = new Point(5, 2);
			checkbox_para_all.Checked = true;
			checkbox_para_all.CheckedChanged += checkBox_para_all_CheckedChanged;
		}

		private void checkBox_para_all_CheckedChanged(object sender, EventArgs e)
		{
			for (int i = 0; i < 16; i++)
			{
				checkbox_para[i].Checked = checkbox_para_all.Checked;
			}
		}

		private void button_RunOveride_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 16; i++)
			{
				if (checkbox_para[i].Checked)
				{
					mOverideList.Add((PcatHead)(13 + i));
				}
			}
			mIsOnlyValidData = checkBox_only_validdata.Checked;
			mIsUpdatePikMntH = checkBox_update_pikmnt_H.Checked;
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancle_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		public BindingList<PcatHead> get_overidelist()
		{
			return mOverideList;
		}

		public bool get_is_onlyvaliddata()
		{
			return mIsOnlyValidData;
		}

		public bool get_is_updatepikmntH()
		{
			return mIsUpdatePikMntH;
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
			button_RunOveride = new System.Windows.Forms.Button();
			button_cancle = new System.Windows.Forms.Button();
			checkBox_only_validdata = new System.Windows.Forms.CheckBox();
			checkBox_update_pikmnt_H = new System.Windows.Forms.CheckBox();
			panel_parameter = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(31, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(529, 47);
			label1.TabIndex = 0;
			label1.Text = "覆盖到料站料盘视觉参数";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button_RunOveride.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button_RunOveride.Location = new System.Drawing.Point(426, 102);
			button_RunOveride.Name = "button_RunOveride";
			button_RunOveride.Size = new System.Drawing.Size(134, 118);
			button_RunOveride.TabIndex = 1;
			button_RunOveride.Text = "开始覆盖";
			button_RunOveride.UseVisualStyleBackColor = true;
			button_RunOveride.Click += new System.EventHandler(button_RunOveride_Click);
			button_cancle.Font = new System.Drawing.Font("黑体", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			button_cancle.Location = new System.Drawing.Point(426, 235);
			button_cancle.Name = "button_cancle";
			button_cancle.Size = new System.Drawing.Size(134, 55);
			button_cancle.TabIndex = 1;
			button_cancle.Text = "取消退出";
			button_cancle.UseVisualStyleBackColor = true;
			button_cancle.Click += new System.EventHandler(button_cancle_Click);
			checkBox_only_validdata.AutoSize = true;
			checkBox_only_validdata.Checked = true;
			checkBox_only_validdata.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_only_validdata.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			checkBox_only_validdata.Location = new System.Drawing.Point(329, 319);
			checkBox_only_validdata.Name = "checkBox_only_validdata";
			checkBox_only_validdata.Size = new System.Drawing.Size(179, 20);
			checkBox_only_validdata.TabIndex = 2;
			checkBox_only_validdata.Text = "仅覆盖非0的有效数据";
			checkBox_only_validdata.UseVisualStyleBackColor = true;
			checkBox_update_pikmnt_H.AutoSize = true;
			checkBox_update_pikmnt_H.Checked = true;
			checkBox_update_pikmnt_H.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBox_update_pikmnt_H.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			checkBox_update_pikmnt_H.Location = new System.Drawing.Point(329, 345);
			checkBox_update_pikmnt_H.Name = "checkBox_update_pikmnt_H";
			checkBox_update_pikmnt_H.Size = new System.Drawing.Size(195, 20);
			checkBox_update_pikmnt_H.TabIndex = 2;
			checkBox_update_pikmnt_H.Text = "同时更新取料/贴装高度";
			checkBox_update_pikmnt_H.UseVisualStyleBackColor = true;
			panel_parameter.BackColor = System.Drawing.Color.PaleTurquoise;
			panel_parameter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel_parameter.Font = new System.Drawing.Font("微软雅黑", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			panel_parameter.Location = new System.Drawing.Point(31, 106);
			panel_parameter.Name = "panel_parameter";
			panel_parameter.Size = new System.Drawing.Size(282, 194);
			panel_parameter.TabIndex = 3;
			label2.Font = new System.Drawing.Font("微软雅黑", 27.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(319, 202);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(52, 52);
			label2.TabIndex = 16;
			label2.Text = "➠";
			label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.CadetBlue;
			base.ClientSize = new System.Drawing.Size(636, 386);
			base.Controls.Add(label2);
			base.Controls.Add(panel_parameter);
			base.Controls.Add(checkBox_update_pikmnt_H);
			base.Controls.Add(checkBox_only_validdata);
			base.Controls.Add(button_cancle);
			base.Controls.Add(button_RunOveride);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			base.Name = "Form_Cat_to_USR2";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
