using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_LabPrintfoot_Conflict : Form
	{
		private USR_DATA USR;

		private BindingList<int[]> footprint_index_list;

		private int mSelectIndex;

		private IContainer components;

		private Label label1;

		private Panel panel1;

		private Button button_OK;

		private Button button_cancel;

		public Form_LabPrintfoot_Conflict(USR_DATA usr, string name, BindingList<int[]> index_list)
		{
			InitializeComponent();
			USR = usr;
			footprint_index_list = index_list;
			label1.Text = name + "存在于多个封装库文件里，请选择";
			if (footprint_index_list != null && footprint_index_list.Count >= 2)
			{
				for (int i = 0; i < footprint_index_list.Count; i++)
				{
					Button button = new Button();
					panel1.Controls.Add(button);
					button.Location = new Point(4, i * 30 + 2);
					button.Size = new Size(75, 28);
					button.Text = "查看";
					button.UseVisualStyleBackColor = true;
					button.Tag = i;
					button.Click += bt_Click;
					RadioButton radioButton = new RadioButton();
					panel1.Controls.Add(radioButton);
					radioButton.Location = new Point(84, i * 30 + 2 + 4);
					radioButton.AutoSize = true;
					radioButton.Size = new Size(300, 28);
					radioButton.TextAlign = ContentAlignment.MiddleLeft;
					radioButton.Tag = i;
					radioButton.Checked = ((i == mSelectIndex) ? true : false);
					radioButton.Text = name + " (" + MainForm0.FP_PATH.mFootprintLib_NameList[index_list[i][0]] + ")";
					radioButton.CheckedChanged += rd_CheckedChanged;
				}
			}
		}

		public void bt_Click(object sender, EventArgs e)
		{
			int index = (int)((Button)sender).Tag;
			MainForm0.FP_PATH.mFootprintLib_Index = footprint_index_list[index][0];
			USR_LIB uSR_LIB = MainForm0.load_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[footprint_index_list[index][0]]);
			uSR_LIB.fpcatindex = footprint_index_list[index][1];
			uSR_LIB.fpcatlist[uSR_LIB.fpcatindex].index = footprint_index_list[index][2];
			MainForm0.save_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[footprint_index_list[index][0]], uSR_LIB);
			Form_LabPrintfoot form_LabPrintfoot = new Form_LabPrintfoot(MainForm0.USR_INIT, 0);
			form_LabPrintfoot.StartPosition = FormStartPosition.CenterParent;
			form_LabPrintfoot.ShowDialog();
		}

		public void rd_CheckedChanged(object sender, EventArgs e)
		{
			int num = (mSelectIndex = (int)((RadioButton)sender).Tag);
		}

		public int get_selectedindex()
		{
			return mSelectIndex;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
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
			button_OK = new System.Windows.Forms.Button();
			button_cancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.Font = new System.Drawing.Font("楷体", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(24, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(576, 25);
			label1.TabIndex = 0;
			label1.Text = "多个封装选项";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			panel1.BackColor = System.Drawing.Color.LightSalmon;
			panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panel1.Location = new System.Drawing.Point(24, 49);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(576, 181);
			panel1.TabIndex = 1;
			button_OK.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_OK.Location = new System.Drawing.Point(171, 236);
			button_OK.Name = "button_OK";
			button_OK.Size = new System.Drawing.Size(87, 35);
			button_OK.TabIndex = 2;
			button_OK.Text = "确定";
			button_OK.UseVisualStyleBackColor = true;
			button_OK.Click += new System.EventHandler(button_OK_Click);
			button_cancel.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_cancel.Location = new System.Drawing.Point(337, 236);
			button_cancel.Name = "button_cancel";
			button_cancel.Size = new System.Drawing.Size(87, 35);
			button_cancel.TabIndex = 2;
			button_cancel.Text = "取消";
			button_cancel.UseVisualStyleBackColor = true;
			button_cancel.Click += new System.EventHandler(button_cancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.NavajoWhite;
			base.ClientSize = new System.Drawing.Size(624, 280);
			base.Controls.Add(button_cancel);
			base.Controls.Add(button_OK);
			base.Controls.Add(panel1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_LabPrintfoot_Conflict";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			ResumeLayout(false);
		}
	}
}
