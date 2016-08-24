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
	public partial class Frm_InputBox : Form
	{
		public Frm_InputBox()
		{
			InitializeComponent();
		}

		private string returnValue;
		public string Value
		{
			set
			{
				returnValue = value;
			}
			get
			{
				return returnValue;
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Trim() == "")
			{
				MessageBox.Show("玩家姓名不能为空！", "错误", MessageBoxButtons.OK);
				return;
			}
			else
			{
				returnValue = textBox1.Text.Trim();
				Close();
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '#')
			{
				e.Handled = true;
			}
		}

		

	}
}
