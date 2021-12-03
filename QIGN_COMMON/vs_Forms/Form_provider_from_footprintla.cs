using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using QIGN_MAIN;

namespace QIGN_COMMON.vs_Forms
{
	public class Form_provider_from_footprintlab : Form
	{
		private IContainer components;

		private Label label1;

		private Panel panel1;

		private BindingList<int_2d> idx_list = new BindingList<int_2d>();

		private BindingList<Label> label_list = new BindingList<Label>();

		private BindingList<Label> yesno_list = new BindingList<Label>();

		private USR_DATA USR;

		private USR2_DATA USR2;

		private USR_INIT_DATA USR_INIT;

		private int mMode;

		private bool mIsView;

		public event void_Func_void stacksel_new_flushdata;

		public event void_Func_void stacksel_new_flushpage;

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
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("黑体", 14f);
			label1.Location = new System.Drawing.Point(111, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(269, 19);
			label1.TabIndex = 0;
			label1.Text = "从封装库同步数据到料站参数";
			panel1.Location = new System.Drawing.Point(12, 41);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1010, 918);
			panel1.TabIndex = 1;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new System.Drawing.Size(516, 971);
			base.Controls.Add(panel1);
			base.Controls.Add(label1);
			Font = new System.Drawing.Font("黑体", 12f);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Form_provider_from_footprintlab";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			base.Load += new System.EventHandler(Form_provider_from_footprintlab_Load);
			ResumeLayout(false);
			PerformLayout();
		}

		public Form_provider_from_footprintlab(USR_DATA usr, USR2_DATA usr2, bool is_view, int mode)
		{
			InitializeComponent();
			USR_INIT = MainForm0.USR_INIT;
			USR = usr;
			USR2 = usr2;
			mIsView = is_view;
			mMode = mode;
			if (USR_INIT.mLanguage != 0)
			{
				MainForm0.common_updateLanguage(USR_INIT.mLanguage, initLanguageTable());
			}
		}

		private List<LanguageItem> initLanguageTable()
		{
			List<LanguageItem> list = new List<LanguageItem>();
			list.Add(new LanguageItem
			{
				font = DEF.FONT_2020,
				fsize = DEF.FSIZE_2020,
				ctrl = label1,
				str = new string[3] { "从封装库同步数据到料站参数", "從封裝庫同步數據到料站參數", "Get Parameters from Footprint Lab" }
			});
			return list;
		}

		private void Form_provider_from_footprintlab_Load(object sender, EventArgs e)
		{
			idx_list = new BindingList<int_2d>();
			label_list = new BindingList<Label>();
			yesno_list = new BindingList<Label>();
			if (mMode == 1)
			{
				BackColor = Color.LightBlue;
			}
			int num = panel1.Height / 24;
			int num2 = 0;
			for (int i = 0; i < 3; i++)
			{
				if (mMode == 1 && i != 0)
				{
					continue;
				}
				StackElement[] array = USR2.mStackLib.stacktab[i];
				_ = USR2.mStackLib.index[i];
				int num3 = HW.mStackNum[MainForm0.mFn][i];
				for (int j = 0; j < num3; j++)
				{
					if (array[j].mSelected)
					{
						int num4 = num2 / num;
						int num5 = num2 % num;
						Label label = new Label();
						panel1.Controls.Add(label);
						label.Location = new Point(25 + num4 * 200, 24 * num5);
						label.Text = STR.PROVIDER_STR[i][USR_INIT.mLanguage] + "-" + (j + 1) + " " + array[j].mChipFootprint + " " + array[j].mChipValue;
						label.AutoSize = false;
						label.Size = new Size(200, 24);
						label.Tag = num2;
						label.Click += lb1_Click;
						int_2d item = new int_2d(i, j);
						idx_list.Add(item);
						label_list.Add(label);
						Label label2 = new Label();
						panel1.Controls.Add(label2);
						label2.Location = new Point(num4 * 200, 24 * num5);
						label2.AutoSize = false;
						label2.Size = new Size(25, 24);
						label2.BringToFront();
						label2.Text = " ";
						yesno_list.Add(label2);
						num2++;
					}
				}
			}
			int num6 = num2 / num + ((num2 % num != 0) ? 1 : 0);
			if (num6 > 2)
			{
				base.Size = new Size(base.Size.Width + (num6 - 2) * 200, base.Size.Height);
			}
			Thread thread = new Thread(thd_run);
			thread.IsBackground = true;
			thread.Start();
		}

		private void lb1_Click(object sender, EventArgs e)
		{
			Label label = (Label)sender;
			int index = (int)label.Tag;
			int a = idx_list[index].a;
			int b = idx_list[index].b;
			USR2.mStackLib.sel = (ProviderType)a;
			USR2.mStackLib.index[a] = b;
			MainForm0.save_usrProjectData();
			Invoke((MethodInvoker)delegate
			{
				if (this.stacksel_new_flushpage != null)
				{
					this.stacksel_new_flushpage();
				}
				if (this.stacksel_new_flushdata != null)
				{
					this.stacksel_new_flushdata();
				}
			});
		}

		private void thd_run()
		{
			int num = panel1.Height / 24;
			int i = 0;
			for (int j = 0; j < 3; j++)
			{
				if (mMode == 1 && j != 0)
				{
					continue;
				}
				StackElement[] array = USR2.mStackLib.stacktab[j];
				_ = USR2.mStackLib.index[j];
				int num2 = HW.mStackNum[MainForm0.mFn][j];
				if (mMode != 0)
				{
					continue;
				}
				for (int k = 0; k < num2; k++)
				{
					if (!array[k].mSelected)
					{
						continue;
					}
					bool is_matched = false;
					for (int l = 0; l < MainForm0.FP_PATH.mFootprintLib_NameList.Count; l++)
					{
						USR_LIB uSR_LIB = MainForm0.load_footprint_file(MainForm0.FP_PATH.mFootprintLib_NameList[l]);
						if (uSR_LIB.fpcatlist == null || uSR_LIB.fpcatlist.Count <= 0)
						{
							continue;
						}
						for (int m = 0; m < uSR_LIB.fpcatlist.Count; m++)
						{
							BindingList<FootPrint> footlist = uSR_LIB.fpcatlist[m].footlist;
							if (footlist == null || footlist.Count <= 0)
							{
								continue;
							}
							for (int n = 0; n < footlist.Count; n++)
							{
								if (!MainForm0.is_match_footprint(footlist[n], array[k].mChipFootprint))
								{
									continue;
								}
								is_matched = true;
								if (!is_matched || mIsView)
								{
									break;
								}
								array[k].lenght = footlist[n].length;
								array[k].width = footlist[n].width;
								array[k].height = footlist[n].height;
								array[k].angle = footlist[n].angle;
								array[k].visualtype = footlist[n].visual;
								if (j != 1)
								{
									array[k].mFeederDelay = (int)footlist[n].feeder_ant_delay;
								}
								else
								{
									array[k].mPlt.mAutoEntTimeDelay = footlist[n].feeder_ant_delay;
								}
								array[k].mIsCollect = footlist[n].iscollect;
								array[k].mCollectDelta = footlist[n].collect_rate;
								array[k].mIsScanR = footlist[n].isscan_r;
								int num3 = MainForm0.mZn[MainForm0.mFn];
								if (!array[k].mZnData[num3].mEnabled)
								{
									for (int num4 = 0; num4 < HW.mZnNum[MainForm0.mFn]; num4++)
									{
										if (array[k].mZnData[num4].mEnabled)
										{
											num3 = num4;
											break;
										}
									}
								}
								float scan_r_mm = footlist[n].scan_r_mm;
								if (footlist[n].camera == CameraType.Fast)
								{
									array[k].scanR = (int)(scan_r_mm * 100f / USR.mFastCamRatio[0][num3] + 0.5f);
									if (array[k].scanR > 360)
									{
										array[k].scanR = 360;
									}
								}
								else if (footlist[n].camera == CameraType.High)
								{
									array[k].scanR = (int)(scan_r_mm * 100f / USR.mHighCamRatio[0] + 0.5f);
									if (array[k].scanR > 900)
									{
										array[k].scanR = 900;
									}
								}
								for (int num5 = 0; num5 < HW.mZnNum[MainForm0.mFn]; num5++)
								{
									array[k].mZnData[num5].threshold = footlist[n].threshold;
									array[k].mZnData[num5].Pik.Offset = footlist[n].pik_offset;
									array[k].mZnData[num5].Pik.UpSpeed = footlist[n].pik_up_speed;
									array[k].mZnData[num5].Pik.DownSpeed = footlist[n].pik_down_speed;
									array[k].mZnData[num5].Pik.Delay = footlist[n].pik_delay;
									array[k].mZnData[num5].Mnt.Offset = footlist[n].mnt_offset;
									array[k].mZnData[num5].Mnt.UpSpeed = footlist[n].mnt_up_speed;
									array[k].mZnData[num5].Mnt.DownSpeed = footlist[n].mnt_down_speed;
									array[k].mZnData[num5].Mnt.Delay = footlist[n].mnt_delay;
								}
								if (array[k].mAutoPixXY == null)
								{
									array[k].mAutoPixXY = new AutoFeederPikXY();
								}
								array[k].mAutoPixXY.scanr = (int)((double)(scan_r_mm * 100f / USR.mMarkCamRatio[0]) * 1.2 + 0.5);
								array[k].mAutoPixXY.belt_color = footlist[n].belt_color;
								if (array[k].mAutoPixXY.belt_color == 0)
								{
									array[k].mAutoPixXY.threshold = USR.mAutoPik_threshold_whitebelt;
								}
								else if (array[k].mAutoPixXY.belt_color == 1)
								{
									array[k].mAutoPixXY.threshold = USR.mAutoPik_threshold_blackbelt;
								}
								else
								{
									array[k].mAutoPixXY.threshold = USR.mAutoPik_threshold_toumingbelt;
								}
								array[k].mAutoPixXY.first_feederin = footlist[n].first_feederin;
								break;
							}
							if (is_matched)
							{
								break;
							}
						}
						if (is_matched)
						{
							break;
						}
					}
					_ = i / num;
					_ = i % num;
					Invoke((MethodInvoker)delegate
					{
						yesno_list[i].Text = (is_matched ? "✔" : "✘");
						yesno_list[i].ForeColor = (is_matched ? Color.Green : Color.Red);
						label_list[i].ForeColor = (is_matched ? Color.LightGray : Color.Black);
					});
					if (!mIsView)
					{
						Thread.Sleep(30);
					}
					i++;
				}
			}
			if (!mIsView)
			{
				MainForm0.save_usrProjectData();
			}
			Invoke((MethodInvoker)delegate
			{
				if (this.stacksel_new_flushdata != null)
				{
					this.stacksel_new_flushdata();
				}
			});
		}

		public void set_match(ProviderType sel, int stackno, bool is_matched)
		{
			if (yesno_list == null || label_list == null || idx_list == null)
			{
				return;
			}
			for (int i = 0; i < idx_list.Count; i++)
			{
				if (idx_list[i].a == (int)sel && idx_list[i].b == stackno)
				{
					int index = i;
					yesno_list[index].Text = (is_matched ? "✔" : "✘");
					yesno_list[index].ForeColor = (is_matched ? Color.Green : Color.Red);
					label_list[index].ForeColor = (is_matched ? Color.LightGray : Color.Black);
					break;
				}
			}
		}
	}
}
