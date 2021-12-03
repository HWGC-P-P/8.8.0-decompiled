using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using QIGN_COMMON.Properties;

namespace QIGN_COMMON.vs_acontrol
{
	public class CnSearchBoxEx : UserControl
	{
		private IContainer components;

		private TextBox textBox1;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private TableLayoutPanel tableLayoutPanel1;

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override string Text
		{
			get
			{
				return textBox1.Text;
			}
			set
			{
				textBox1.Text = value;
			}
		}

		public event EventHandler SearchEvent;

		public event EventHandler SearchEventExt;

		public CnSearchBoxEx()
		{
			InitializeComponent();
			textBox1.Text = "";
			tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(tableLayoutPanel1, true, null);
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (this.SearchEvent != null)
			{
				this.SearchEvent(this, e);
			}
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			if (this.SearchEventExt != null)
			{
				this.SearchEventExt(this, e);
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
			textBox1 = new System.Windows.Forms.TextBox();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox1.Location = new System.Drawing.Point(3, 6);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(145, 14);
			textBox1.TabIndex = 0;
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23f));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23f));
			tableLayoutPanel1.Controls.Add(pictureBox1, 1, 0);
			tableLayoutPanel1.Controls.Add(pictureBox2, 2, 0);
			tableLayoutPanel1.Controls.Add(textBox1, 0, 0);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 1;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			tableLayoutPanel1.Size = new System.Drawing.Size(197, 26);
			tableLayoutPanel1.TabIndex = 2;
			pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			pictureBox1.Image = QIGN_COMMON.Properties.Resources.searc1;
			pictureBox1.Location = new System.Drawing.Point(154, 4);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(17, 18);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
			pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			pictureBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			pictureBox2.Image = QIGN_COMMON.Properties.Resources.searc2;
			pictureBox2.Location = new System.Drawing.Point(177, 4);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(17, 18);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox2.TabIndex = 1;
			pictureBox2.TabStop = false;
			pictureBox2.Click += new System.EventHandler(pictureBox2_Click);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.White;
			base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			base.Controls.Add(tableLayoutPanel1);
			base.Name = "CnSearchBoxEx";
			base.Size = new System.Drawing.Size(197, 26);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
		}
	}
}
