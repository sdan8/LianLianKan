using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
		object currentBtnTag;
		Button tempLastBtn;
		bool finded;

		public Frm_LianLianKan()
		{
			InitializeComponent();
		}

		private void Frm_LianLianKan_Load(object sender, EventArgs e)
		{
			btn = new Button[Data.width, Data.height];
			tempLastBtn = new Button();
			finded = false;
		}

		private void btn_start_Click(object sender, EventArgs e)
		{
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
			panel_gameArea.BackgroundImage = Bitmap.FromFile(Application.StartupPath + @"\img\bg.jpg");
			panel_gameArea.BackgroundImageLayout = ImageLayout.Center;
			btn_start.Text = "重新开始";
			
		}

		private void btn_clear_Click(object sender, EventArgs e)
		{
			//if (btn[0, 0].BackgroundImage.Tag.Equals(btn[0, 1].BackgroundImage.Tag))
			//{
			//	panel_gameArea.Controls.Remove(btn[0, 0]);
			//}
			//if (btn[0, 0].BackgroundImage.Tag.Equals(btn[1, 0].BackgroundImage.Tag))
			//{
			panel_gameArea.BackgroundImage = null;
				for (int i = 0; i < Data.height; i++)
				{
					for (int ii = 0; ii < Data.width; ii++)
					{
						panel_gameArea.Controls.Remove(btn[ii, i]);
					}
				}
			//}
		}

		void ImageInit()
		{
			Data.images = new Image[Data.imageCount];
			for (int i = 0; i < Data.imageCount; i++)
			{
				Data.images[i] = Image.FromFile(Application.StartupPath + @"\img\" + i + ".png");
			}
		}

		void GridInit()
		{
			for (int i = 0; i < Data.height; i++)
			{
				for (int ii = 0; ii < Data.width; ii++)
				{
					Button bt = new Button();
					bt.Click += new EventHandler(btnClick);
					bt.Name = ii.ToString() + "_" + i.ToString();
					bt.Text = "";
					bt.Location = new Point(0 + ii * (Data.imageSize + Data.offset), 0 + i * (Data.imageSize + Data.offset)); // 按钮屏幕位置
					bt.Size = new Size(Data.imageSize, Data.imageSize);
					bt.Parent = panel_gameArea;
					bt.BackgroundImageLayout = ImageLayout.Stretch;

					bt.Font = new System.Drawing.Font("华文行楷", 27);
					bt.ForeColor = Color.Red;

					panel_gameArea.Controls.Add(bt);

					btn[ii, i] = bt;
				}
			}

			//for (int i = 0; i < Data.width; i++)
			//{
			//	for (int ii = 0; ii < Data.height; ii++)
			//	{
			//		btn[i, ii].Text = i.ToString() + "," + ii.ToString();
			//	}
			//}
		}

		void RandomApplyImage()
		{
			//一共有l对
			int l = Data.height * Data.width / 2;
			//每种类型一共有a对
			int a = l / Data.imageCount;
			//余出r对
			int r = l % Data.imageCount;

			List<Button> btnList = new List<Button>();

			for (int i = 0; i < Data.height; i++)
			{
				for (int ii = 0; ii < Data.width; ii++)
				{
					btnList.Add(btn[ii, i]);
				}
			}


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



		void IsFindPath(Button origin,Button destination)
		{
			//string oName = origin.Name;
			//string dName = destination.Name;
			
			//int ow = int.Parse(oName.Substring(0, oName.LastIndexOf('_')));
			//int oh = int.Parse(oName.Substring(oName.LastIndexOf('_') + 1));
			//int dw = int.Parse(dName.Substring(0, dName.LastIndexOf('_')));
			//int dh = int.Parse(dName.Substring(dName.LastIndexOf('_') + 1));

			int ow = GetWByBtn(origin);
			int oh = GetHByBtn(origin);
			int dw = GetWByBtn(destination);
			int dh = GetHByBtn(destination);

			FindPathNext(Direction.UP, 0, ow, oh - 1, dw, dh);
			FindPathNext(Direction.RIGHT, 0, ow + 1, oh, dw, dh);
			FindPathNext(Direction.DOWN, 0, ow, oh + 1, dw, dh);
			FindPathNext(Direction.LEFT, 0, ow - 1, oh, dw, dh);

			
		}

		void FindPathNext(Direction dir, int turnTimes, int targetW, int targetH, int destinationW, int destinationH)
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



		#region 是否可达

		//bool IsFindPath(Button origin,Button destination)
		//{
			
		//	bool finded;

		//	Position viaPosition;
		//	Position originPosition;
		//	Position destinationPosition;

		//	//Name格式为 w_h
		//	string o = origin.Name;
		//	string d = destination.Name;

		//	int ow = int.Parse(o.Substring(0, o.LastIndexOf('_')));
		//	int oh = int.Parse(o.Substring(o.LastIndexOf('_') + 1));
		//	int dw = int.Parse(d.Substring(0, d.LastIndexOf('_')));
		//	int dh = int.Parse(d.Substring(d.LastIndexOf('_') + 1));

		//	viaPosition = new Position(ow, oh);
		//	originPosition = new Position(ow,oh);
		//	destinationPosition = new Position(dw, dh);

		//	Console.WriteLine(origin.Name + ", " + destination.Name);


			
		//	#region
		//	Console.WriteLine("up");
		//	if (FindPathNext(Direction.UP, 0, viaPosition, originPosition, destinationPosition))
		//	{
				
		//		return true;
		//	}
		//	Console.WriteLine("right");
		//	if (FindPathNext(Direction.RIGHT, 0, viaPosition, originPosition, destinationPosition))
		//	{
				
		//		return true;
		//	}
		//	Console.WriteLine("down");
		//	if (FindPathNext(Direction.DOWN, 0, viaPosition, originPosition, destinationPosition))
		//	{
				
		//		return true;
		//	}
		//	Console.WriteLine("left");
		//	if (FindPathNext(Direction.LEFT, 0, viaPosition, originPosition, destinationPosition))
		//	{
				
		//		return true;
		//	}
		//	#endregion
		//	Console.WriteLine("no finded");
		//	return false;
		//}

		#endregion

		#region 寻路系统


		///// <summary>
		///// 寻路系统
		///// </summary>
		///// <param name="dir">下一个方向</param>
		///// <param name="turnTimes">已转角次数</param>
		///// <param name="viaPosition">过程中的坐标，第一次为起点坐标</param>
		///// <param name="originPosition">起点坐标</param>
		///// <param name="destinationPosition">目标坐标</param>
		//bool FindPathNext(Direction dir,int turnTimes,Position viaPosition, Position originPosition, Position destinationPosition)
		//{
		//	if (viaPosition.w < -1 || viaPosition.w > Data.width)
		//	{
		//		return false;
		//	}
		//	if (viaPosition.h < -1 || viaPosition.h > Data.height)
		//	{
		//		return false;
		//	}
		//	if (turnTimes > 2)
		//	{
		//		return false;
		//	}
		//	if (viaPosition.w >= 0 && viaPosition.w < Data.width && viaPosition.h >= 0 && viaPosition.h < Data.height)
		//	{
		//		Console.WriteLine("Name:" + btn[viaPosition.w, viaPosition.h].Name);

		//		//if ((viaPosition.w != originPosition.w) || (viaPosition.h != originPosition.h))
		//		//{
		//		//	if (btn[viaPosition.w, viaPosition.h] != null)
		//		//	{

		//		//撞到物体，并且不为起点
		//		if ((btn[viaPosition.w, viaPosition.h] != null) && (viaPosition.w != originPosition.w || viaPosition.h != originPosition.h))
		//		{
		//				Console.WriteLine("originPosition.w:" + viaPosition.w + ", originPosition.h:" + viaPosition.h);
		//				if (btn[viaPosition.w, viaPosition.h].BackgroundImage.Tag.Equals(btn[destinationPosition.w, destinationPosition.h].BackgroundImage.Tag))
		//				{
		//					Console.WriteLine("true");
		//					return true;
		//				}
		//				else
		//				{
		//					Console.WriteLine("false");
		//					return false;
		//				}
		//		}
		//		//	}
		//		//}
		//	}
		//	switch (dir)
		//	{
		//		case Direction.UP:

		//			viaPosition.h = viaPosition.h - 1;

		//			if (FindPathNext(Direction.UP, turnTimes, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}

		//			if (FindPathNext(Direction.RIGHT, turnTimes + 1, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}

		//			if (FindPathNext(Direction.LEFT, turnTimes + 1, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}

		//			break;
		//		case Direction.RIGHT:
		//			Console.WriteLine("RIGHT");
		//			viaPosition.w = viaPosition.w + 1;
		//			if (FindPathNext(Direction.UP, turnTimes + 1, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}
		//			if (FindPathNext(Direction.RIGHT, turnTimes, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}
		//			if (FindPathNext(Direction.DOWN, turnTimes + 1, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}
		//			break;
		//		case Direction.DOWN:
		//			Console.WriteLine("DOWN");
		//			viaPosition.h = viaPosition.h + 1;
		//			if (FindPathNext(Direction.RIGHT, turnTimes + 1, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}
		//			if (FindPathNext(Direction.DOWN, turnTimes, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}
		//			if (FindPathNext(Direction.LEFT, turnTimes + 1, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}
		//			break;
		//		case Direction.LEFT:
		//			Console.WriteLine("LEFT");
		//			viaPosition.w = viaPosition.w - 1;
		//			if (FindPathNext(Direction.UP, turnTimes + 1, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}
		//			if (FindPathNext(Direction.DOWN, turnTimes + 1, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}
		//			if (FindPathNext(Direction.LEFT, turnTimes, viaPosition, originPosition, destinationPosition))
		//			{
		//				return true;
		//			}
		//			break;
		//	}
		//	return false;
		//}
		
		#endregion


		void btnClick(object sender, EventArgs e)
		{
			
			Button tempCurrentBtn = (Button)sender;
			if (currentBtnTag == null)
			{
				currentBtnTag = tempCurrentBtn.BackgroundImage.Tag;
				tempCurrentBtn.Enabled = false;
				tempLastBtn = tempCurrentBtn;
				

			}
			else
			{
				if (currentBtnTag.Equals(tempCurrentBtn.BackgroundImage.Tag))
				{
					//Destroy
					IsFindPath(tempLastBtn, tempCurrentBtn);
					if (finded)
					{
						//Console.Write(tempLastBtn.Name + "," + tempCurrentBtn.Name);
						btn[GetWByBtn(tempLastBtn), GetHByBtn(tempLastBtn)] = null;
						btn[GetWByBtn(tempCurrentBtn), GetHByBtn(tempCurrentBtn)] = null;
						panel_gameArea.Controls.Remove(tempLastBtn);
						panel_gameArea.Controls.Remove(tempCurrentBtn);
						finded = false;
						currentBtnTag = null;
					}
					else
					{
						tempLastBtn.Enabled = true;
						currentBtnTag = null;
					}
					//MessageBox.Show("Same!");
				}
				else
				{
					currentBtnTag = null;
					tempLastBtn.Enabled = true;
					

				}
			}
		}


		int GetWByBtn(Button button)
		{
			string buttonName = button.Name;
			int w = int.Parse(buttonName.Substring(0, buttonName.LastIndexOf('_')));
			return w;
		}

		int GetHByBtn(Button button)
		{
			string buttonName = button.Name;
			int h = int.Parse(buttonName.Substring(buttonName.LastIndexOf('_') + 1));
			return h;
		}

		private void btn_exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}


	}
}
