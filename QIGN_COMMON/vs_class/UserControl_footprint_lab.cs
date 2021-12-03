using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_class
{
	public class UserControl_footprint_lab : UserControl
	{
		private IContainer components;

		private Panel panel3;

		private Panel panel_foot;

		private CheckBox checkBox_iscollect;

		private CheckBox checkBox_islowspeed;

		private ComboBox comboBox_feedertype;

		private ComboBox comboBox_provider;

		private ComboBox comboBox_nozzle2;

		private ComboBox comboBox_nozzle;

		private ComboBox comboBox_cameraType;

		private PictureBox pictureBox1;

		private NumericUpDown numericUpDown_collectrate;

		private NumericUpDown numericUpDown_mnt_downspeed;

		private NumericUpDown numericUpDown_mnt_upspeed;

		private NumericUpDown numericUpDown_pik_downspeed;

		private NumericUpDown numericUpDown_mnt_delay;

		private NumericUpDown numericUpDown_pik_delay;

		private NumericUpDown numericUpDown_pik_upspeed;

		private NumericUpDown numericUpDown_mnt_offset;

		private NumericUpDown numericUpDown_pik_offset;

		private NumericUpDown numericUpDown_threshold;

		private NumericUpDown numericUpDown_delta;

		private NumericUpDown numericUpDown_scanrmm;

		private NumericUpDown numericUpDown_width;

		private NumericUpDown numericUpDown_length;

		private NumericUpDown numericUpDown_height;

		private Label label_scanr;

		private Label label_visualType;

		private Label label207;

		private Button button19;

		private Label label6;

		private Label label4;

		private Label label5;

		private Label label3;

		private Label label206;

		private Label label9;

		private Label label17;

		private Label label16;

		private Label label15;

		private Label label19;

		private Label label18;

		private Label label14;

		private Label label11;

		private Label label10;

		private Label label13;

		private Label label208;

		private Label label7;

		private Label label204;

		private Label label203;

		private Label label202;

		private Label label_name;

		private Label label_filename;

		private Panel panel2;

		private ListBox listBox2;

		private Button button_order;

		private Button button_clone;

		private Button button_rename;

		private Button button_save;

		private Button button_rem;

		private Button button_add;

		private Button button_combinefile;

		private Button button_removefile;

		private Button button_createfile;

		private Button button_addfile;

		private Panel panel1;

		private ListBox listBox1;

		private Label label1;

		private Button button1;

		private Label label12;

		private Label label20;

		private NumericUpDown numericUpDown1;

		private NumericUpDown numericUpDown2;

		private NumericUpDown numericUpDown3;

		private NumericUpDown numericUpDown4;

		private NumericUpDown numericUpDown5;

		private NumericUpDown numericUpDown6;

		private Label label21;

		private Label label2;

		private TrackBar trackBar1;

		private TrackBar trackBar2;

		private Label label23;

		private Label label24;

		private Label label25;

		private TableLayoutPanel tableLayoutPanel2;

		private Label label28;

		private Label label27;

		private TableLayoutPanel tableLayoutPanel3;

		private Label label8;

		private NumericUpDown numericUpDown7;

		private Panel panel4;

		private Label label22;

		private TextBox textBox1;

		private Button button2;

		public UserControl_footprint_lab()
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
			panel3 = new System.Windows.Forms.Panel();
			panel_foot = new System.Windows.Forms.Panel();
			textBox1 = new System.Windows.Forms.TextBox();
			panel4 = new System.Windows.Forms.Panel();
			label22 = new System.Windows.Forms.Label();
			tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			label20 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			numericUpDown_mnt_delay = new System.Windows.Forms.NumericUpDown();
			numericUpDown_mnt_downspeed = new System.Windows.Forms.NumericUpDown();
			numericUpDown6 = new System.Windows.Forms.NumericUpDown();
			numericUpDown5 = new System.Windows.Forms.NumericUpDown();
			numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			numericUpDown_mnt_upspeed = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pik_delay = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pik_downspeed = new System.Windows.Forms.NumericUpDown();
			numericUpDown_pik_upspeed = new System.Windows.Forms.NumericUpDown();
			label18 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			numericUpDown_height = new System.Windows.Forms.NumericUpDown();
			label203 = new System.Windows.Forms.Label();
			label204 = new System.Windows.Forms.Label();
			numericUpDown_length = new System.Windows.Forms.NumericUpDown();
			numericUpDown_width = new System.Windows.Forms.NumericUpDown();
			label208 = new System.Windows.Forms.Label();
			comboBox_feedertype = new System.Windows.Forms.ComboBox();
			numericUpDown_mnt_offset = new System.Windows.Forms.NumericUpDown();
			checkBox_iscollect = new System.Windows.Forms.CheckBox();
			numericUpDown_pik_offset = new System.Windows.Forms.NumericUpDown();
			comboBox_provider = new System.Windows.Forms.ComboBox();
			label7 = new System.Windows.Forms.Label();
			comboBox_nozzle2 = new System.Windows.Forms.ComboBox();
			label11 = new System.Windows.Forms.Label();
			numericUpDown_delta = new System.Windows.Forms.NumericUpDown();
			comboBox_nozzle = new System.Windows.Forms.ComboBox();
			numericUpDown_scanrmm = new System.Windows.Forms.NumericUpDown();
			label10 = new System.Windows.Forms.Label();
			numericUpDown_collectrate = new System.Windows.Forms.NumericUpDown();
			label6 = new System.Windows.Forms.Label();
			label206 = new System.Windows.Forms.Label();
			comboBox_cameraType = new System.Windows.Forms.ComboBox();
			label207 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label_visualType = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			checkBox_islowspeed = new System.Windows.Forms.CheckBox();
			label5 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label202 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			trackBar2 = new System.Windows.Forms.TrackBar();
			trackBar1 = new System.Windows.Forms.TrackBar();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			numericUpDown_threshold = new System.Windows.Forms.NumericUpDown();
			label_scanr = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button19 = new System.Windows.Forms.Button();
			label27 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			numericUpDown7 = new System.Windows.Forms.NumericUpDown();
			label2 = new System.Windows.Forms.Label();
			label_name = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label_filename = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			listBox2 = new System.Windows.Forms.ListBox();
			button_order = new System.Windows.Forms.Button();
			button_clone = new System.Windows.Forms.Button();
			button_rename = new System.Windows.Forms.Button();
			button_save = new System.Windows.Forms.Button();
			button_rem = new System.Windows.Forms.Button();
			button_add = new System.Windows.Forms.Button();
			button_combinefile = new System.Windows.Forms.Button();
			button_removefile = new System.Windows.Forms.Button();
			button_createfile = new System.Windows.Forms.Button();
			button_addfile = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			listBox1 = new System.Windows.Forms.ListBox();
			label1 = new System.Windows.Forms.Label();
			button2 = new System.Windows.Forms.Button();
			panel3.SuspendLayout();
			panel_foot.SuspendLayout();
			panel4.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_delay).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_downspeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_upspeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_delay).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_downspeed).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_upspeed).BeginInit();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_height).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_length).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_width).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_offset).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_offset).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_delta).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_scanrmm).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_collectrate).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_threshold).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
			panel2.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			panel3.Controls.Add(panel_foot);
			panel3.Controls.Add(label_filename);
			panel3.Controls.Add(panel2);
			panel3.Controls.Add(button_order);
			panel3.Controls.Add(button_clone);
			panel3.Controls.Add(button_rename);
			panel3.Controls.Add(button_save);
			panel3.Controls.Add(button_rem);
			panel3.Controls.Add(button_add);
			panel3.Controls.Add(button_combinefile);
			panel3.Controls.Add(button_removefile);
			panel3.Controls.Add(button_createfile);
			panel3.Controls.Add(button_addfile);
			panel3.Controls.Add(panel1);
			panel3.Location = new System.Drawing.Point(8, 39);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(708, 848);
			panel3.TabIndex = 12;
			panel_foot.BackColor = System.Drawing.Color.PeachPuff;
			panel_foot.Controls.Add(textBox1);
			panel_foot.Controls.Add(panel4);
			panel_foot.Controls.Add(tableLayoutPanel3);
			panel_foot.Controls.Add(tableLayoutPanel2);
			panel_foot.Controls.Add(label28);
			panel_foot.Controls.Add(label24);
			panel_foot.Controls.Add(trackBar2);
			panel_foot.Controls.Add(trackBar1);
			panel_foot.Controls.Add(pictureBox1);
			panel_foot.Controls.Add(numericUpDown_threshold);
			panel_foot.Controls.Add(label_scanr);
			panel_foot.Controls.Add(button1);
			panel_foot.Controls.Add(button19);
			panel_foot.Controls.Add(label27);
			panel_foot.Controls.Add(label23);
			panel_foot.Controls.Add(label13);
			panel_foot.Controls.Add(label25);
			panel_foot.Controls.Add(label21);
			panel_foot.Controls.Add(numericUpDown7);
			panel_foot.Controls.Add(label2);
			panel_foot.Controls.Add(label_name);
			panel_foot.Controls.Add(label8);
			panel_foot.Location = new System.Drawing.Point(194, 112);
			panel_foot.Name = "panel_foot";
			panel_foot.Size = new System.Drawing.Size(505, 718);
			panel_foot.TabIndex = 9;
			textBox1.Location = new System.Drawing.Point(399, 46);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(100, 71);
			textBox1.TabIndex = 13;
			textBox1.Text = "R_0603\r\n0603R\r\n0603_R\r\n603\r\n";
			panel4.BackColor = System.Drawing.Color.White;
			panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel4.Controls.Add(label22);
			panel4.Location = new System.Drawing.Point(224, 222);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(133, 72);
			panel4.TabIndex = 12;
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(3, 24);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(56, 14);
			label22.TabIndex = 1;
			label22.Text = "左：0度";
			tableLayoutPanel3.BackColor = System.Drawing.Color.White;
			tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			tableLayoutPanel3.ColumnCount = 3;
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25f));
			tableLayoutPanel3.Controls.Add(label20, 2, 0);
			tableLayoutPanel3.Controls.Add(label12, 1, 0);
			tableLayoutPanel3.Controls.Add(numericUpDown_mnt_delay, 1, 6);
			tableLayoutPanel3.Controls.Add(numericUpDown6, 2, 6);
			tableLayoutPanel3.Controls.Add(numericUpDown3, 2, 3);
			tableLayoutPanel3.Controls.Add(numericUpDown_pik_delay, 1, 3);
			tableLayoutPanel3.Controls.Add(label18, 0, 3);
			tableLayoutPanel3.Controls.Add(label19, 0, 6);
			tableLayoutPanel3.Controls.Add(label14, 0, 2);
			tableLayoutPanel3.Controls.Add(numericUpDown_pik_upspeed, 1, 2);
			tableLayoutPanel3.Controls.Add(numericUpDown_pik_downspeed, 1, 1);
			tableLayoutPanel3.Controls.Add(numericUpDown1, 2, 2);
			tableLayoutPanel3.Controls.Add(numericUpDown2, 2, 1);
			tableLayoutPanel3.Controls.Add(label15, 0, 1);
			tableLayoutPanel3.Controls.Add(label16, 0, 5);
			tableLayoutPanel3.Controls.Add(numericUpDown_mnt_upspeed, 1, 5);
			tableLayoutPanel3.Controls.Add(numericUpDown_mnt_downspeed, 1, 4);
			tableLayoutPanel3.Controls.Add(numericUpDown4, 2, 5);
			tableLayoutPanel3.Controls.Add(numericUpDown5, 2, 4);
			tableLayoutPanel3.Controls.Add(label17, 0, 4);
			tableLayoutPanel3.Location = new System.Drawing.Point(218, 306);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 7;
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel3.Size = new System.Drawing.Size(272, 204);
			tableLayoutPanel3.TabIndex = 11;
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(207, 1);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(28, 14);
			label20.TabIndex = 1;
			label20.Text = "503";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(139, 1);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(28, 14);
			label12.TabIndex = 1;
			label12.Text = "501";
			numericUpDown_mnt_delay.Location = new System.Drawing.Point(139, 178);
			numericUpDown_mnt_delay.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
			numericUpDown_mnt_delay.Name = "numericUpDown_mnt_delay";
			numericUpDown_mnt_delay.Size = new System.Drawing.Size(61, 23);
			numericUpDown_mnt_delay.TabIndex = 2;
			numericUpDown_mnt_delay.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_mnt_downspeed.Location = new System.Drawing.Point(139, 120);
			numericUpDown_mnt_downspeed.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_mnt_downspeed.Name = "numericUpDown_mnt_downspeed";
			numericUpDown_mnt_downspeed.Size = new System.Drawing.Size(61, 23);
			numericUpDown_mnt_downspeed.TabIndex = 2;
			numericUpDown_mnt_downspeed.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown6.Location = new System.Drawing.Point(207, 178);
			numericUpDown6.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
			numericUpDown6.Name = "numericUpDown6";
			numericUpDown6.Size = new System.Drawing.Size(61, 23);
			numericUpDown6.TabIndex = 2;
			numericUpDown6.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown5.Location = new System.Drawing.Point(207, 120);
			numericUpDown5.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown5.Name = "numericUpDown5";
			numericUpDown5.Size = new System.Drawing.Size(61, 23);
			numericUpDown5.TabIndex = 2;
			numericUpDown5.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown4.Location = new System.Drawing.Point(207, 149);
			numericUpDown4.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown4.Name = "numericUpDown4";
			numericUpDown4.Size = new System.Drawing.Size(61, 23);
			numericUpDown4.TabIndex = 2;
			numericUpDown4.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown3.Location = new System.Drawing.Point(207, 91);
			numericUpDown3.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
			numericUpDown3.Name = "numericUpDown3";
			numericUpDown3.Size = new System.Drawing.Size(61, 23);
			numericUpDown3.TabIndex = 2;
			numericUpDown3.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown2.Location = new System.Drawing.Point(207, 33);
			numericUpDown2.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown2.Name = "numericUpDown2";
			numericUpDown2.Size = new System.Drawing.Size(61, 23);
			numericUpDown2.TabIndex = 2;
			numericUpDown2.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown1.Location = new System.Drawing.Point(207, 62);
			numericUpDown1.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(61, 23);
			numericUpDown1.TabIndex = 2;
			numericUpDown1.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_mnt_upspeed.Location = new System.Drawing.Point(139, 149);
			numericUpDown_mnt_upspeed.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_mnt_upspeed.Name = "numericUpDown_mnt_upspeed";
			numericUpDown_mnt_upspeed.Size = new System.Drawing.Size(61, 23);
			numericUpDown_mnt_upspeed.TabIndex = 2;
			numericUpDown_mnt_upspeed.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_delay.Location = new System.Drawing.Point(139, 91);
			numericUpDown_pik_delay.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
			numericUpDown_pik_delay.Name = "numericUpDown_pik_delay";
			numericUpDown_pik_delay.Size = new System.Drawing.Size(61, 23);
			numericUpDown_pik_delay.TabIndex = 2;
			numericUpDown_pik_delay.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			numericUpDown_pik_downspeed.Location = new System.Drawing.Point(139, 33);
			numericUpDown_pik_downspeed.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_downspeed.Name = "numericUpDown_pik_downspeed";
			numericUpDown_pik_downspeed.Size = new System.Drawing.Size(61, 23);
			numericUpDown_pik_downspeed.TabIndex = 2;
			numericUpDown_pik_downspeed.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_upspeed.Location = new System.Drawing.Point(139, 62);
			numericUpDown_pik_upspeed.Maximum = new decimal(new int[4] { 64, 0, 0, 0 });
			numericUpDown_pik_upspeed.Name = "numericUpDown_pik_upspeed";
			numericUpDown_pik_upspeed.Size = new System.Drawing.Size(61, 23);
			numericUpDown_pik_upspeed.TabIndex = 2;
			numericUpDown_pik_upspeed.Value = new decimal(new int[4] { 64, 0, 0, 0 });
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(4, 88);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(84, 14);
			label18.TabIndex = 1;
			label18.Text = "取料延时/ms";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(4, 30);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(91, 14);
			label15.TabIndex = 1;
			label15.Text = "取料下伸速度";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(4, 59);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(91, 14);
			label14.TabIndex = 1;
			label14.Text = "取料上拉速度";
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(4, 175);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(84, 14);
			label19.TabIndex = 1;
			label19.Text = "贴装延时/ms";
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(4, 117);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(91, 14);
			label17.TabIndex = 1;
			label17.Text = "贴装下伸速度";
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(4, 146);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(91, 14);
			label16.TabIndex = 1;
			label16.Text = "贴装上拉速度";
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			tableLayoutPanel2.Controls.Add(numericUpDown_height, 1, 0);
			tableLayoutPanel2.Controls.Add(label203, 0, 1);
			tableLayoutPanel2.Controls.Add(label204, 0, 2);
			tableLayoutPanel2.Controls.Add(numericUpDown_length, 1, 1);
			tableLayoutPanel2.Controls.Add(numericUpDown_width, 1, 2);
			tableLayoutPanel2.Controls.Add(label208, 0, 3);
			tableLayoutPanel2.Controls.Add(comboBox_feedertype, 1, 13);
			tableLayoutPanel2.Controls.Add(numericUpDown_mnt_offset, 1, 15);
			tableLayoutPanel2.Controls.Add(checkBox_iscollect, 0, 7);
			tableLayoutPanel2.Controls.Add(numericUpDown_pik_offset, 1, 14);
			tableLayoutPanel2.Controls.Add(comboBox_provider, 1, 12);
			tableLayoutPanel2.Controls.Add(label7, 0, 4);
			tableLayoutPanel2.Controls.Add(comboBox_nozzle2, 1, 11);
			tableLayoutPanel2.Controls.Add(label11, 0, 15);
			tableLayoutPanel2.Controls.Add(numericUpDown_delta, 1, 3);
			tableLayoutPanel2.Controls.Add(comboBox_nozzle, 1, 10);
			tableLayoutPanel2.Controls.Add(numericUpDown_scanrmm, 1, 4);
			tableLayoutPanel2.Controls.Add(label10, 0, 14);
			tableLayoutPanel2.Controls.Add(numericUpDown_collectrate, 1, 8);
			tableLayoutPanel2.Controls.Add(label6, 0, 13);
			tableLayoutPanel2.Controls.Add(label206, 0, 5);
			tableLayoutPanel2.Controls.Add(comboBox_cameraType, 1, 5);
			tableLayoutPanel2.Controls.Add(label207, 0, 6);
			tableLayoutPanel2.Controls.Add(label4, 0, 12);
			tableLayoutPanel2.Controls.Add(label_visualType, 1, 6);
			tableLayoutPanel2.Controls.Add(label9, 0, 8);
			tableLayoutPanel2.Controls.Add(checkBox_islowspeed, 0, 9);
			tableLayoutPanel2.Controls.Add(label5, 0, 11);
			tableLayoutPanel2.Controls.Add(label3, 0, 10);
			tableLayoutPanel2.Controls.Add(label202, 0, 0);
			tableLayoutPanel2.Location = new System.Drawing.Point(12, 44);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 16;
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28f));
			tableLayoutPanel2.Size = new System.Drawing.Size(200, 466);
			tableLayoutPanel2.TabIndex = 10;
			numericUpDown_height.DecimalPlaces = 2;
			numericUpDown_height.Location = new System.Drawing.Point(103, 3);
			numericUpDown_height.Name = "numericUpDown_height";
			numericUpDown_height.Size = new System.Drawing.Size(66, 23);
			numericUpDown_height.TabIndex = 2;
			label203.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label203.AutoSize = true;
			label203.Location = new System.Drawing.Point(3, 28);
			label203.Name = "label203";
			label203.Size = new System.Drawing.Size(94, 28);
			label203.TabIndex = 1;
			label203.Text = "元件长度/mm";
			label203.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label204.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label204.AutoSize = true;
			label204.Location = new System.Drawing.Point(3, 56);
			label204.Name = "label204";
			label204.Size = new System.Drawing.Size(94, 28);
			label204.TabIndex = 1;
			label204.Text = "元件宽度/mm";
			label204.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			numericUpDown_length.DecimalPlaces = 2;
			numericUpDown_length.Location = new System.Drawing.Point(103, 31);
			numericUpDown_length.Name = "numericUpDown_length";
			numericUpDown_length.Size = new System.Drawing.Size(66, 23);
			numericUpDown_length.TabIndex = 2;
			numericUpDown_width.DecimalPlaces = 2;
			numericUpDown_width.Location = new System.Drawing.Point(103, 59);
			numericUpDown_width.Name = "numericUpDown_width";
			numericUpDown_width.Size = new System.Drawing.Size(66, 23);
			numericUpDown_width.TabIndex = 2;
			label208.AutoSize = true;
			label208.Location = new System.Drawing.Point(3, 84);
			label208.Name = "label208";
			label208.Size = new System.Drawing.Size(84, 14);
			label208.TabIndex = 1;
			label208.Text = "同取容差/mm";
			comboBox_feedertype.FormattingEnabled = true;
			comboBox_feedertype.Location = new System.Drawing.Point(103, 367);
			comboBox_feedertype.Name = "comboBox_feedertype";
			comboBox_feedertype.Size = new System.Drawing.Size(61, 22);
			comboBox_feedertype.TabIndex = 4;
			numericUpDown_mnt_offset.DecimalPlaces = 2;
			numericUpDown_mnt_offset.Location = new System.Drawing.Point(103, 423);
			numericUpDown_mnt_offset.Minimum = new decimal(new int[4] { 100, 0, 0, -2147483648 });
			numericUpDown_mnt_offset.Name = "numericUpDown_mnt_offset";
			numericUpDown_mnt_offset.Size = new System.Drawing.Size(62, 23);
			numericUpDown_mnt_offset.TabIndex = 2;
			numericUpDown_mnt_offset.Value = new decimal(new int[4] { 5, 0, 0, 65536 });
			checkBox_iscollect.AutoSize = true;
			checkBox_iscollect.Location = new System.Drawing.Point(3, 199);
			checkBox_iscollect.Name = "checkBox_iscollect";
			checkBox_iscollect.Size = new System.Drawing.Size(82, 18);
			checkBox_iscollect.TabIndex = 5;
			checkBox_iscollect.Text = "特征识别";
			checkBox_iscollect.UseVisualStyleBackColor = true;
			numericUpDown_pik_offset.BackColor = System.Drawing.Color.LightGray;
			numericUpDown_pik_offset.DecimalPlaces = 2;
			numericUpDown_pik_offset.Location = new System.Drawing.Point(103, 395);
			numericUpDown_pik_offset.Minimum = new decimal(new int[4] { 100, 0, 0, -2147483648 });
			numericUpDown_pik_offset.Name = "numericUpDown_pik_offset";
			numericUpDown_pik_offset.Size = new System.Drawing.Size(62, 23);
			numericUpDown_pik_offset.TabIndex = 2;
			numericUpDown_pik_offset.Value = new decimal(new int[4] { 5, 0, 0, 65536 });
			comboBox_provider.FormattingEnabled = true;
			comboBox_provider.Location = new System.Drawing.Point(103, 339);
			comboBox_provider.Name = "comboBox_provider";
			comboBox_provider.Size = new System.Drawing.Size(54, 22);
			comboBox_provider.TabIndex = 4;
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(3, 112);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(84, 14);
			label7.TabIndex = 1;
			label7.Text = "扫描半径/mm";
			comboBox_nozzle2.FormattingEnabled = true;
			comboBox_nozzle2.Location = new System.Drawing.Point(103, 311);
			comboBox_nozzle2.Name = "comboBox_nozzle2";
			comboBox_nozzle2.Size = new System.Drawing.Size(61, 22);
			comboBox_nozzle2.TabIndex = 4;
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(3, 420);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(91, 28);
			label11.TabIndex = 1;
			label11.Text = "贴装下压偏移/mm";
			numericUpDown_delta.DecimalPlaces = 2;
			numericUpDown_delta.Location = new System.Drawing.Point(103, 87);
			numericUpDown_delta.Name = "numericUpDown_delta";
			numericUpDown_delta.Size = new System.Drawing.Size(66, 23);
			numericUpDown_delta.TabIndex = 2;
			comboBox_nozzle.FormattingEnabled = true;
			comboBox_nozzle.Location = new System.Drawing.Point(103, 283);
			comboBox_nozzle.Name = "comboBox_nozzle";
			comboBox_nozzle.Size = new System.Drawing.Size(54, 22);
			comboBox_nozzle.TabIndex = 4;
			numericUpDown_scanrmm.DecimalPlaces = 2;
			numericUpDown_scanrmm.Location = new System.Drawing.Point(103, 115);
			numericUpDown_scanrmm.Name = "numericUpDown_scanrmm";
			numericUpDown_scanrmm.Size = new System.Drawing.Size(66, 23);
			numericUpDown_scanrmm.TabIndex = 2;
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(3, 392);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(91, 28);
			label10.TabIndex = 1;
			label10.Text = "取料下压偏移/mm";
			numericUpDown_collectrate.DecimalPlaces = 2;
			numericUpDown_collectrate.Location = new System.Drawing.Point(103, 227);
			numericUpDown_collectrate.Name = "numericUpDown_collectrate";
			numericUpDown_collectrate.Size = new System.Drawing.Size(66, 23);
			numericUpDown_collectrate.TabIndex = 2;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(3, 364);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(63, 14);
			label6.TabIndex = 1;
			label6.Text = "飞达型号";
			label206.AutoSize = true;
			label206.Location = new System.Drawing.Point(3, 140);
			label206.Name = "label206";
			label206.Size = new System.Drawing.Size(63, 14);
			label206.TabIndex = 1;
			label206.Text = "相机类型";
			comboBox_cameraType.FormattingEnabled = true;
			comboBox_cameraType.Location = new System.Drawing.Point(103, 143);
			comboBox_cameraType.Name = "comboBox_cameraType";
			comboBox_cameraType.Size = new System.Drawing.Size(66, 22);
			comboBox_cameraType.TabIndex = 4;
			label207.AutoSize = true;
			label207.Location = new System.Drawing.Point(3, 168);
			label207.Name = "label207";
			label207.Size = new System.Drawing.Size(63, 14);
			label207.TabIndex = 1;
			label207.Text = "视觉类型";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 336);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(63, 14);
			label4.TabIndex = 1;
			label4.Text = "供料类型";
			label_visualType.BackColor = System.Drawing.Color.SeaShell;
			label_visualType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_visualType.Location = new System.Drawing.Point(103, 168);
			label_visualType.Name = "label_visualType";
			label_visualType.Size = new System.Drawing.Size(93, 22);
			label_visualType.TabIndex = 1;
			label_visualType.Text = "自定义视觉";
			label_visualType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(3, 224);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(91, 28);
			label9.TabIndex = 1;
			label9.Text = "特征识别容差/%";
			checkBox_islowspeed.AutoSize = true;
			checkBox_islowspeed.Location = new System.Drawing.Point(3, 255);
			checkBox_islowspeed.Name = "checkBox_islowspeed";
			checkBox_islowspeed.Size = new System.Drawing.Size(82, 18);
			checkBox_islowspeed.TabIndex = 5;
			checkBox_islowspeed.Text = "降速搬运";
			checkBox_islowspeed.UseVisualStyleBackColor = true;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(3, 308);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(91, 14);
			label5.TabIndex = 1;
			label5.Text = "备用吸嘴型号";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 280);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(63, 14);
			label3.TabIndex = 1;
			label3.Text = "吸嘴型号";
			label202.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			label202.AutoSize = true;
			label202.Location = new System.Drawing.Point(3, 0);
			label202.Name = "label202";
			label202.Size = new System.Drawing.Size(94, 28);
			label202.TabIndex = 1;
			label202.Text = "*元件厚度/mm";
			label202.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			label28.BackColor = System.Drawing.Color.LightSalmon;
			label28.Location = new System.Drawing.Point(-8, 629);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(513, 4);
			label28.TabIndex = 7;
			label24.BackColor = System.Drawing.Color.LightSalmon;
			label24.Location = new System.Drawing.Point(1, 525);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(513, 4);
			label24.TabIndex = 7;
			trackBar2.Location = new System.Drawing.Point(178, 673);
			trackBar2.Name = "trackBar2";
			trackBar2.Size = new System.Drawing.Size(187, 45);
			trackBar2.TabIndex = 9;
			trackBar1.Location = new System.Drawing.Point(316, 577);
			trackBar1.Name = "trackBar1";
			trackBar1.Size = new System.Drawing.Size(187, 45);
			trackBar1.TabIndex = 9;
			pictureBox1.BackColor = System.Drawing.Color.Gray;
			pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pictureBox1.Location = new System.Drawing.Point(224, 44);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(110, 107);
			pictureBox1.TabIndex = 3;
			pictureBox1.TabStop = false;
			numericUpDown_threshold.Location = new System.Drawing.Point(102, 574);
			numericUpDown_threshold.Maximum = new decimal(new int[4] { 255, 0, 0, 0 });
			numericUpDown_threshold.Name = "numericUpDown_threshold";
			numericUpDown_threshold.Size = new System.Drawing.Size(86, 23);
			numericUpDown_threshold.TabIndex = 2;
			numericUpDown_threshold.Value = new decimal(new int[4] { 127, 0, 0, 0 });
			label_scanr.BackColor = System.Drawing.Color.SeaShell;
			label_scanr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			label_scanr.Location = new System.Drawing.Point(340, 94);
			label_scanr.Name = "label_scanr";
			label_scanr.Size = new System.Drawing.Size(53, 23);
			label_scanr.TabIndex = 1;
			label_scanr.Text = "280";
			label_scanr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			button1.Location = new System.Drawing.Point(340, 45);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(53, 23);
			button1.TabIndex = 0;
			button1.Text = "导入";
			button1.UseVisualStyleBackColor = true;
			button19.Location = new System.Drawing.Point(340, 69);
			button19.Name = "button19";
			button19.Size = new System.Drawing.Size(53, 23);
			button19.TabIndex = 0;
			button19.Text = "采集";
			button19.UseVisualStyleBackColor = true;
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(220, 577);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(91, 14);
			label27.TabIndex = 1;
			label27.Text = "高清相机光源";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(53, 681);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(91, 14);
			label23.TabIndex = 1;
			label23.Text = "快速相机光源";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(33, 577);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(63, 14);
			label13.TabIndex = 1;
			label13.Text = "视觉阈值";
			label25.AutoSize = true;
			label25.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label25.Location = new System.Drawing.Point(188, 642);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(88, 16);
			label25.TabIndex = 1;
			label25.Text = "不通用参数";
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label21.Location = new System.Drawing.Point(173, 549);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(120, 16);
			label21.TabIndex = 1;
			label21.Text = "仅本机通用参数";
			numericUpDown7.DecimalPlaces = 2;
			numericUpDown7.Location = new System.Drawing.Point(291, 193);
			numericUpDown7.Name = "numericUpDown7";
			numericUpDown7.Size = new System.Drawing.Size(66, 23);
			numericUpDown7.TabIndex = 2;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("楷体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label2.Location = new System.Drawing.Point(223, 19);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(72, 16);
			label2.TabIndex = 1;
			label2.Text = "通用参数";
			label_name.AutoSize = true;
			label_name.Font = new System.Drawing.Font("楷体", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label_name.Location = new System.Drawing.Point(23, 9);
			label_name.Name = "label_name";
			label_name.Size = new System.Drawing.Size(65, 21);
			label_name.TabIndex = 0;
			label_name.Text = "R0603";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(222, 197);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(63, 14);
			label8.TabIndex = 1;
			label8.Text = "进料角度";
			label_filename.BackColor = System.Drawing.Color.PeachPuff;
			label_filename.Location = new System.Drawing.Point(11, 85);
			label_filename.Name = "label_filename";
			label_filename.Size = new System.Drawing.Size(685, 24);
			label_filename.TabIndex = 4;
			label_filename.Text = "C:\\aaaa\\footprint.fplab";
			label_filename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			panel2.AutoScroll = true;
			panel2.Controls.Add(listBox2);
			panel2.Location = new System.Drawing.Point(77, 109);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(117, 727);
			panel2.TabIndex = 8;
			listBox2.FormattingEnabled = true;
			listBox2.ItemHeight = 14;
			listBox2.Items.AddRange(new object[19]
			{
				"C0201", "C0402", "C0603", "C0805", "C1206", "C3216", "C3528", "C6032", "C7343", "C7845",
				"R0201", "R0402", "R0603", "R0805", "R1206", "R1210", "R1812", "R2010", "R2512"
			});
			listBox2.Location = new System.Drawing.Point(3, 3);
			listBox2.Name = "listBox2";
			listBox2.Size = new System.Drawing.Size(111, 718);
			listBox2.TabIndex = 5;
			button_order.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_order.Location = new System.Drawing.Point(10, 332);
			button_order.Name = "button_order";
			button_order.Size = new System.Drawing.Size(64, 35);
			button_order.TabIndex = 6;
			button_order.Text = "排序";
			button_order.UseVisualStyleBackColor = true;
			button_clone.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_clone.Location = new System.Drawing.Point(10, 200);
			button_clone.Name = "button_clone";
			button_clone.Size = new System.Drawing.Size(64, 35);
			button_clone.TabIndex = 6;
			button_clone.Text = "克隆";
			button_clone.UseVisualStyleBackColor = true;
			button_rename.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_rename.Location = new System.Drawing.Point(10, 244);
			button_rename.Name = "button_rename";
			button_rename.Size = new System.Drawing.Size(64, 35);
			button_rename.TabIndex = 6;
			button_rename.Text = "重命名";
			button_rename.UseVisualStyleBackColor = true;
			button_save.Font = new System.Drawing.Font("楷体", 10.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_save.Location = new System.Drawing.Point(10, 288);
			button_save.Name = "button_save";
			button_save.Size = new System.Drawing.Size(64, 35);
			button_save.TabIndex = 6;
			button_save.Text = "保存";
			button_save.UseVisualStyleBackColor = true;
			button_rem.Font = new System.Drawing.Font("楷体", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_rem.Location = new System.Drawing.Point(10, 156);
			button_rem.Name = "button_rem";
			button_rem.Size = new System.Drawing.Size(64, 35);
			button_rem.TabIndex = 6;
			button_rem.Text = "-";
			button_rem.UseVisualStyleBackColor = true;
			button_add.Font = new System.Drawing.Font("楷体", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			button_add.Location = new System.Drawing.Point(10, 112);
			button_add.Name = "button_add";
			button_add.Size = new System.Drawing.Size(64, 35);
			button_add.TabIndex = 7;
			button_add.Text = "+";
			button_add.UseVisualStyleBackColor = true;
			button_combinefile.Enabled = false;
			button_combinefile.Location = new System.Drawing.Point(493, 47);
			button_combinefile.Name = "button_combinefile";
			button_combinefile.Size = new System.Drawing.Size(101, 35);
			button_combinefile.TabIndex = 3;
			button_combinefile.Text = "合并库文件";
			button_combinefile.UseVisualStyleBackColor = true;
			button_removefile.Location = new System.Drawing.Point(388, 47);
			button_removefile.Name = "button_removefile";
			button_removefile.Size = new System.Drawing.Size(101, 35);
			button_removefile.TabIndex = 3;
			button_removefile.Text = "移除库文件";
			button_removefile.UseVisualStyleBackColor = true;
			button_createfile.Location = new System.Drawing.Point(388, 8);
			button_createfile.Name = "button_createfile";
			button_createfile.Size = new System.Drawing.Size(101, 35);
			button_createfile.TabIndex = 3;
			button_createfile.Text = "新建库文件";
			button_createfile.UseVisualStyleBackColor = true;
			button_addfile.Location = new System.Drawing.Point(493, 8);
			button_addfile.Name = "button_addfile";
			button_addfile.Size = new System.Drawing.Size(101, 35);
			button_addfile.TabIndex = 3;
			button_addfile.Text = "添加库文件";
			button_addfile.UseVisualStyleBackColor = true;
			panel1.AutoScroll = true;
			panel1.Controls.Add(listBox1);
			panel1.Location = new System.Drawing.Point(9, 5);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(373, 77);
			panel1.TabIndex = 2;
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 14;
			listBox1.Items.AddRange(new object[5] { "C:\\aaaa\\footprint1.fplab", "C:\\aaaa\\footprint2.fplab", "C:\\aaaa\\footprint3.fplab", "C:\\aaaa\\footprint4.fplab", "C:\\aaaa\\footprint5.fplab" });
			listBox1.Location = new System.Drawing.Point(3, 3);
			listBox1.Name = "listBox1";
			listBox1.Size = new System.Drawing.Size(350, 74);
			listBox1.TabIndex = 1;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("楷体", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
			label1.Location = new System.Drawing.Point(316, 17);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(76, 21);
			label1.TabIndex = 11;
			label1.Text = "封装库";
			button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button2.Location = new System.Drawing.Point(684, 3);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(32, 32);
			button2.TabIndex = 13;
			button2.Text = "X";
			button2.UseVisualStyleBackColor = true;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			BackColor = System.Drawing.Color.LightSalmon;
			base.Controls.Add(button2);
			base.Controls.Add(panel3);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("楷体", 10.5f);
			base.Name = "UserControl_footprint_lab";
			base.Size = new System.Drawing.Size(719, 892);
			panel3.ResumeLayout(false);
			panel_foot.ResumeLayout(false);
			panel_foot.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			tableLayoutPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_delay).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_downspeed).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_upspeed).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_delay).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_downspeed).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_upspeed).EndInit();
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDown_height).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_length).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_width).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_mnt_offset).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_pik_offset).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_delta).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_scanrmm).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_collectrate).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown_threshold).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
			panel2.ResumeLayout(false);
			panel1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
