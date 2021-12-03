using QIGN_COMMON;

namespace QIGN_MAIN
{
	public class VISUAL_RESULT
	{
		public int pno;

		public float box_center_x;

		public float box_center_y;

		public float box_width;

		public float box_height;

		public int move_x;

		public int move_y;

		public int move_a;

		public float move_angle;

		public float px;

		public float py;

		public bool is_test;

		public PinConfig pinconfig;

		public string vis_info;

		public VISUAL_RESULT()
		{
			box_width = 0f;
			box_height = 0f;
			pinconfig = default(PinConfig);
			vis_info = "";
		}

		public VISUAL_RESULT(float w, float h)
		{
			box_width = w;
			box_height = h;
			pinconfig = default(PinConfig);
		}

		public void set_visinfo(string s)
		{
			vis_info = s;
		}

		public void set_w_h(float w, float h)
		{
			box_width = w;
			box_height = h;
		}

		public void set_pinconfig(PinConfig pin)
		{
			pinconfig = default(PinConfig);
			pinconfig.pin_mode = pin.pin_mode;
			pinconfig.is_defects_detection = pin.is_defects_detection;
			pinconfig.is_pin_diff = pin.is_pin_diff;
			pinconfig.pin_side_dis = pin.pin_side_dis;
			pinconfig.pin_side_dis2 = pin.pin_side_dis2;
			pinconfig.pin_count = pin.pin_count;
			pinconfig.pin_length = pin.pin_length;
			pinconfig.pin_width = pin.pin_width;
			pinconfig.pin_slot = pin.pin_slot;
			pinconfig.pin_offset = pin.pin_offset;
			pinconfig.pin_dis = pin.pin_dis;
			pinconfig.pin_count1 = pin.pin_count1;
			pinconfig.pin_length1 = pin.pin_length1;
			pinconfig.pin_width1 = pin.pin_width1;
			pinconfig.pin_slot1 = pin.pin_slot1;
			pinconfig.pin_offset1 = pin.pin_offset1;
			pinconfig.pin_dis1 = pin.pin_dis1;
			pinconfig.pin_count2 = pin.pin_count2;
			pinconfig.pin_length2 = pin.pin_length2;
			pinconfig.pin_width2 = pin.pin_width2;
			pinconfig.pin_slot2 = pin.pin_slot2;
			pinconfig.pin_offset2 = pin.pin_offset2;
			pinconfig.pin_dis2 = pin.pin_dis2;
			pinconfig.pin_count3 = pin.pin_count3;
			pinconfig.pin_length3 = pin.pin_length3;
			pinconfig.pin_width3 = pin.pin_width3;
			pinconfig.pin_slot3 = pin.pin_slot3;
			pinconfig.pin_offset3 = pin.pin_offset3;
			pinconfig.pin_dis3 = pin.pin_dis3;
		}
	}
}
