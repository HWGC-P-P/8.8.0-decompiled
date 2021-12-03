using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace QIGN_COMMON.vs_acontrol
{
	public class CnLabel : Button
	{
		private enum EventEn
		{
			None,
			MouseEnter,
			MouseLeave,
			MouseDown,
			MouseUp,
			MouseHover
		}

		private volatile EventEn mouseEvent;

		private volatile bool is_mouseHover;

		private Color pressdown_color = Color.White;

		private volatile bool is_pressdown;

		public CnLabel()
		{
			base.UseVisualStyleBackColor = true;
			EventHandler value = delegate
			{
				mouseEvent = EventEn.MouseEnter;
				is_mouseHover = true;
			};
			base.MouseEnter += value;
			base.MouseLeave += delegate
			{
				mouseEvent = EventEn.MouseLeave;
				is_mouseHover = false;
			};
			base.MouseDown += delegate
			{
				mouseEvent = EventEn.MouseDown;
				is_pressdown = !is_pressdown;
			};
			base.MouseUp += delegate
			{
				mouseEvent = EventEn.MouseUp;
				is_mouseHover = false;
				if (this != null && !base.IsDisposed)
				{
					Graphics g = CreateGraphics();
					cn_paint(g);
				}
			};
		}

		private void cn_paint(Graphics g)
		{
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			cn_paint_standard_mode(g);
			if (Text != null && !(Text == ""))
			{
				SolidBrush solidBrush = new SolidBrush(ForeColor);
				string[] array = Text.Split('\r');
				int num = array.Count();
				float num2 = 0f;
				SizeF[] array2 = new SizeF[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = array[i].Replace("\n", "");
					ref SizeF reference = ref array2[i];
					reference = g.MeasureString(array[i], new Font(Font.FontFamily, Font.Size, GraphicsUnit.Point));
					num2 += array2[i].Height;
				}
				num2 = ((float)base.Size.Height - num2) / 2f + array2[0].Height / 10f;
				for (int j = 0; j < num; j++)
				{
					int num3 = 0;
					num2 += ((j - 1 < 0) ? 0f : array2[j - 1].Height);
					g.DrawString(array[j], Font, solidBrush, new Point(num3, (int)((double)num2 + 0.5)));
				}
				solidBrush.Dispose();
			}
		}

		private void cn_paint_standard_mode(Graphics g)
		{
			Pen pen = new Pen(Color.Black, 1f);
			SolidBrush solidBrush = new SolidBrush(BackColor);
			if (is_mouseHover)
			{
				int num = BackColor.R - 60;
				int num2 = BackColor.G - 60;
				int num3 = BackColor.B - 60;
				num = ((num > 255) ? 255 : num);
				num2 = ((num2 > 255) ? 255 : num2);
				num3 = ((num3 > 255) ? 255 : num3);
				if (num < 0)
				{
					num = 0;
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				solidBrush.Color = Color.FromArgb(num, num2, num3);
			}
			if (!base.Enabled)
			{
				solidBrush.Color = Color.LightGray;
			}
			g.FillRectangle(solidBrush, 0, 0, base.Size.Width, base.Size.Height);
			solidBrush.Dispose();
			pen.Dispose();
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			Graphics graphics = pevent.Graphics;
			cn_paint(graphics);
		}
	}
}
