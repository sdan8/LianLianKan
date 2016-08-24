using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LianLianKan
{
	public partial class Frm_LianLianKan : Form
	{
		enum Direction
		{
			UP,
			RIGHT,
			DOWN,
			LEFT
		};

		Button[,] btn;
		List<Button> btnList = new List<Button>();
		List<Button> allBtn = new List<Button>();	//场上未消除的所有按钮
		Button currentBtn;
		Button tempLastBtn;
		bool finded = false;

		int minute = 0;
		int second = 0;

		

		public Frm_LianLianKan()
		{
			InitializeComponent();
		}

		private void Frm_LianLianKan_Load(object sender, EventArgs e)
		{
			btn = new Button[Data.width, Data.height];
			finded = false;
		}

		private void btn_start_Click(object sender, EventArgs e)
		{
			minute = 0;
			second = 0;
			timer1.Start();
			if (btn_start.Text.Trim() == "重新开始")
			{
				panel_gameArea.BackgroundImage = null;
				for (int i = 0; i < Data.height; i++)
				{
					for (int ii = 0; ii < Data.width; ii++)
					{
						panel_gameArea.Controls.Remove(btn[ii, i]);
					}
				}
			}

			ImageInit();
			GridInit();
			RandomApplyImage();
			btn_start.Text = "重新开始";
			panel_gameArea.BackgroundImage = Bitmap.FromFile(Application.StartupPath + @"\img\bg.jpg");
			allBtn.Clear();
			for (int i = 0; i < Data.height; i++)
			{
				for (int ii = 0; ii < Data.width; ii++)
				{
					allBtn.Add(btn[ii, i]);
				}
			}
			
		}

		private void btn_clear_Click(object sender, EventArgs e)
		{
			panel_gameArea.BackgroundImage = null;
			for (int i = 0; i < Data.height; i++)
			{
				for (int ii = 0; ii < Data.width; ii++)
				{
					panel_gameArea.Controls.Remove(btn[ii, i]);
				}
			}
		}

		private void btnClick(object sender, EventArgs e)
		{
			Button tempCurrentBtn = (Button)sender;
			//选中第一个
			if (currentBtn == null)
			{
				currentBtn = tempCurrentBtn;
				tempCurrentBtn.Enabled = false;
				tempCurrentBtn.FlatAppearance.BorderSize = 2;
				tempCurrentBtn.FlatAppearance.BorderColor = Color.Red;
				tempLastBtn = tempCurrentBtn;
			}
			//选中第二个
			else
			{
				IsFindPath(tempLastBtn, tempCurrentBtn);
				if (finded)
				{
					btn[GetWByBtn(tempCurrentBtn), GetHByBtn(tempCurrentBtn)] = null;
					btn[GetWByBtn(tempLastBtn), GetHByBtn(tempLastBtn)] = null;
					allBtn.Remove(tempLastBtn);
					allBtn.Remove(tempCurrentBtn);
					panel_gameArea.Controls.Remove(tempLastBtn);
					panel_gameArea.Controls.Remove(tempCurrentBtn);
					finded = false;
					currentBtn = null;

					if (allBtn.Count == 0)
					{
						timer1.Stop();
						MessageBox.Show("你赢了！用时：" + minute + "分" + second + "秒", "恭喜", MessageBoxButtons.OK);
						SaveTime();
					}
					//遍历是否有解
					else if(!CheckResult())
					{
						timer1.Stop();
						MessageBox.Show("无解", "提示", MessageBoxButtons.OK);
					}
				}
				else
				{
					tempLastBtn.Enabled = true;
					tempLastBtn.FlatAppearance.BorderSize = 0;
					tempLastBtn.FlatAppearance.BorderColor = Color.White;
					currentBtn = null;
				}
			}
		}

		private void btn_exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void ImageInit()
		{
			Data.images = new Image[Data.imageCount];
			for (int i = 0; i < Data.imageCount; i++)
			{
				Data.images[i] = Image.FromFile(Application.StartupPath + @"\img\" + i + ".png");
			}
		}

		private void GridInit()
		{
			for (int i = 0; i < Data.height; i++)
			{
				for (int ii = 0; ii < Data.width; ii++)
				{
					Button bt = new Button();
					bt.Click += new EventHandler(btnClick);
					bt.Name = ii.ToString() + "_" + i.ToString();
					bt.Text = "";
					bt.Location = new Point(1 + ii * (Data.imageSize + Data.offset), 1 + i * (Data.imageSize + Data.offset)); // 按钮屏幕位置
					bt.Size = new Size(Data.imageSize, Data.imageSize);
					bt.Parent = panel_gameArea;
					bt.BackgroundImageLayout = ImageLayout.Stretch;
					bt.FlatStyle = FlatStyle.Flat;
					bt.FlatAppearance.BorderSize = 0;
					bt.FlatAppearance.BorderColor = Color.White;
					panel_gameArea.Controls.Add(bt);

					btn[ii, i] = bt;
					btnList.Add(btn[ii, i]);
				}
			}
		}

		private void RandomApplyImage()
		{
			//一共有l对
			int l = Data.height * Data.width / 2;
			//每种类型一共有a对
			int a = l / Data.imageCount;
			//余出r对
			int r = l % Data.imageCount;

			Random random = new Random();

			for (int i = 0; i < Data.imageCount; i++)
			{
				for (int ii = 0; ii < a; ii++)
				{
					for (int iii = 0; iii < 2; iii++)
					{
						Button tempBtn = btnList[random.Next(0, btnList.Count)];
						tempBtn.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\" + i + ".png");
						tempBtn.BackgroundImage.Tag = i;
						btnList.Remove(tempBtn);
					}
				}
			}

			//如果有多余的
			if (r != 0)
			{
				int ran;
				for (int i = 0; i < r; i++)
				{
					ran = random.Next(0, Data.imageCount);
					for (int ii = 0; ii < 2; ii++)
					{
						Button tempBtn = btnList[random.Next(0, btnList.Count)];
						tempBtn.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\" + ran + ".png");
						tempBtn.BackgroundImage.Tag = ran;
						btnList.Remove(tempBtn);
					}
				}
			}
		}

		#region 寻路系统
		
		private void IsFindPath(Button origin,Button destination)
		{
			if (!origin.BackgroundImage.Tag.Equals(destination.BackgroundImage.Tag))
				return;

			int ow = GetWByBtn(origin);
			int oh = GetHByBtn(origin);
			int dw = GetWByBtn(destination);
			int dh = GetHByBtn(destination);

			FindPathNext(Direction.UP, 0, ow, oh - 1, dw, dh);
			FindPathNext(Direction.RIGHT, 0, ow + 1, oh, dw, dh);
			FindPathNext(Direction.DOWN, 0, ow, oh + 1, dw, dh);
			FindPathNext(Direction.LEFT, 0, ow - 1, oh, dw, dh);

		}

		private void FindPathNext(Direction dir, int turnTimes, int targetW, int targetH, int destinationW, int destinationH)
		{
			//Console.WriteLine(dir.ToString());
			//边界情况 
			//	W = -1		W = Data.width;
			//	H = -1		H = Data.height;
			if (finded)	return;
			if (targetW < -1 || targetW > Data.width)	return;
			if (targetH < -1 || targetH > Data.height)	return;
			if (turnTimes > 2)	return;
			if (targetW == destinationW && targetH == destinationH)
			{
				finded = true;
				return;
			}
			if (targetW >= 0 && targetW < Data.width && targetH >= 0 && targetH < Data.height)
			{
				if (btn[targetW, targetH] != null)
				{
					return;
				}
			}
			switch (dir)
			{
				case Direction.UP:
					FindPathNext(Direction.UP, turnTimes, targetW, targetH - 1, destinationW, destinationH);
					FindPathNext(Direction.RIGHT, turnTimes + 1, targetW + 1, targetH, destinationW, destinationH);
					FindPathNext(Direction.LEFT, turnTimes + 1, targetW - 1, targetH, destinationW, destinationH);
					break;
				case Direction.RIGHT:
					FindPathNext(Direction.UP, turnTimes + 1, targetW, targetH - 1, destinationW, destinationH);
					FindPathNext(Direction.RIGHT, turnTimes, targetW + 1, targetH, destinationW, destinationH);
					FindPathNext(Direction.DOWN, turnTimes + 1, targetW, targetH + 1, destinationW, destinationH);
					break;
				case Direction.DOWN:
					FindPathNext(Direction.RIGHT, turnTimes + 1, targetW + 1, targetH, destinationW, destinationH);
					FindPathNext(Direction.DOWN, turnTimes, targetW, targetH + 1, destinationW, destinationH);
					FindPathNext(Direction.LEFT, turnTimes + 1, targetW - 1, targetH, destinationW, destinationH);
					break;
				case Direction.LEFT:
					FindPathNext(Direction.UP, turnTimes + 1, targetW, targetH - 1, destinationW, destinationH);
					FindPathNext(Direction.DOWN, turnTimes + 1, targetW, targetH + 1, destinationW, destinationH);
					FindPathNext(Direction.LEFT, turnTimes, targetW - 1, targetH, destinationW, destinationH);
					break;
			}
		}

		#endregion

		#region 根据名称获得位置

		private int GetWByBtn(Button button)
		{
			string buttonName = button.Name;
			int w = int.Parse(buttonName.Substring(0, buttonName.LastIndexOf('_')));
			return w;
		}

		private int GetHByBtn(Button button)
		{
			string buttonName = button.Name;
			int h = int.Parse(buttonName.Substring(buttonName.LastIndexOf('_') + 1));
			return h;
		}

		#endregion

		//遍历寻解
		private bool CheckResult()
		{
			for (int i = 0; i < allBtn.Count - 1; i++)
			{
				for (int ii = i + 1; ii < allBtn.Count; ii++)
				{
					IsFindPath(allBtn[i], allBtn[ii]);
					if (finded)
					{
						finded = false;
						return true;
					}
				}
			}
			return false;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			second++;
			if (second == 60)
			{
				second = 0;
				minute++;
			}
			if (minute != 0)
			{
				lab_timeCount.Text = minute.ToString() + "分" + second.ToString() + "秒";
			}
			else
			{
				lab_timeCount.Text = second.ToString() + "秒";
			}
		}

		private void SaveTime()
		{
			int time = minute * 60 + second;
			int count = 0;
			char flag = '#';
			string lineTime;
			string str;

			string[] lines = File.ReadAllLines(Application.StartupPath + @"\data.txt");

			foreach (var line in lines)
			{
				lineTime = line.Substring(line.LastIndexOf(flag) + 1);
				if (Convert.ToInt32(lineTime) > time)	break;
				count++;
			}
			//没进入排行榜
			if (count == 10)
			{
				return;
			}
			//进入排行榜
			else
			{
				Frm_InputBox frm_inputBox = new Frm_InputBox();
				frm_inputBox.ShowDialog();
				//格式化
				str = frm_inputBox.Value + flag + time.ToString();
				//排名后移
				for (int i = 9; i > count; i--)
				{
					lines[i] = lines[i - 1];
				}
				lines[count] = str;
				File.WriteAllLines(Application.StartupPath + @"\data.txt", lines);
			}
		}

		private void 开始ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			btn_start_Click(sender, e);
			开始ToolStripMenuItem.Text = "重新开始";
		}

		private void 排行榜ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FrmRank frmRank = new FrmRank();
			frmRank.ShowDialog();
		}

		private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
