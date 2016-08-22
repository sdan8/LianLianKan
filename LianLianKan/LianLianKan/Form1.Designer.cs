namespace LianLianKan
{
	partial class Frm_LianLianKan
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_start = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.panel_gameArea = new System.Windows.Forms.Panel();
			this.btn_exit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_start
			// 
			this.btn_start.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btn_start.Location = new System.Drawing.Point(69, 34);
			this.btn_start.Name = "btn_start";
			this.btn_start.Size = new System.Drawing.Size(120, 60);
			this.btn_start.TabIndex = 0;
			this.btn_start.Text = "开始";
			this.btn_start.UseVisualStyleBackColor = true;
			this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
			// 
			// btn_clear
			// 
			this.btn_clear.Location = new System.Drawing.Point(421, 34);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(120, 60);
			this.btn_clear.TabIndex = 1;
			this.btn_clear.Text = "清除";
			this.btn_clear.UseVisualStyleBackColor = true;
			this.btn_clear.Visible = false;
			this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
			// 
			// panel_gameArea
			// 
			this.panel_gameArea.BackColor = System.Drawing.SystemColors.Control;
			this.panel_gameArea.Location = new System.Drawing.Point(53, 118);
			this.panel_gameArea.Name = "panel_gameArea";
			this.panel_gameArea.Size = new System.Drawing.Size(779, 515);
			this.panel_gameArea.TabIndex = 2;
			// 
			// btn_exit
			// 
			this.btn_exit.Location = new System.Drawing.Point(698, 34);
			this.btn_exit.Name = "btn_exit";
			this.btn_exit.Size = new System.Drawing.Size(120, 60);
			this.btn_exit.TabIndex = 3;
			this.btn_exit.Text = "退出";
			this.btn_exit.UseVisualStyleBackColor = true;
			this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
			// 
			// Frm_LianLianKan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 661);
			this.Controls.Add(this.btn_exit);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.panel_gameArea);
			this.Controls.Add(this.btn_start);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "Frm_LianLianKan";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "连连看";
			this.Load += new System.EventHandler(this.Frm_LianLianKan_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_start;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Panel panel_gameArea;
		private System.Windows.Forms.Button btn_exit;
	}
}

