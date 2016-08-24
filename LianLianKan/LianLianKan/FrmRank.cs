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
	public partial class FrmRank : Form
	{
		
		public FrmRank()
		{
			InitializeComponent();
		}

		private void FrmRank_Load(object sender, EventArgs e)
		{
			DataRefresh();
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btn_clear_Click(object sender, EventArgs e)
		{
			DialogResult dr;
			dr = MessageBox.Show("确定清空吗？", "提示", MessageBoxButtons.YesNo);
			if (dr == DialogResult.Yes)
			{
				string[] lines = new string[10];
				for (int i = 0; i < lines.Length; i++)
				{
					lines[i] = "无#9999";
				}
				File.WriteAllLines(Application.StartupPath + @"\data.txt", lines);
				DataRefresh();
			}
		}

		private void DataRefresh()
		{
			char flag = '#';
			string name;
			string time;
			string showTime;
			int count = 0;
			string[] lines = File.ReadAllLines(Application.StartupPath + @"\data.txt");
			foreach (var line in lines)
			{
				time = line.Substring(line.LastIndexOf(flag) + 1);
				name = line.Substring(0, line.LastIndexOf(flag));
				showTime = (Convert.ToInt32(time) / 60) + "分" + (Convert.ToInt32(time) % 60) + "秒";
				((Label)this.Controls.Find("lab_time" + count, true)[0]).Text = showTime;
				((Label)this.Controls.Find("lab_name" + count, true)[0]).Text = name;
				count++;
			}
		}
	}
}
