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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LianLianKan));
			this.btn_start = new System.Windows.Forms.Button();
			this.btn_clear = new System.Windows.Forms.Button();
			this.panel_gameArea = new System.Windows.Forms.Panel();
			this.btn_exit = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lab_timeCount = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.排行榜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_key = new System.Windows.Forms.Button();
			this.panel_gameArea.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_start
			// 
			this.btn_start.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btn_start.Location = new System.Drawing.Point(69, 60);
			this.btn_start.Name = "btn_start";
			this.btn_start.Size = new System.Drawing.Size(100, 62);
			this.btn_start.TabIndex = 0;
			this.btn_start.Text = "开始";
			this.btn_start.UseVisualStyleBackColor = true;
			this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
			// 
			// btn_clear
			// 
			this.btn_clear.Location = new System.Drawing.Point(222, 89);
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
			this.panel_gameArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_gameArea.Controls.Add(this.btn_clear);
			this.panel_gameArea.Location = new System.Drawing.Point(69, 159);
			this.panel_gameArea.Name = "panel_gameArea";
			this.panel_gameArea.Size = new System.Drawing.Size(743, 425);
			this.panel_gameArea.TabIndex = 2;
			// 
			// btn_exit
			// 
			this.btn_exit.Location = new System.Drawing.Point(712, 60);
			this.btn_exit.Name = "btn_exit";
			this.btn_exit.Size = new System.Drawing.Size(100, 62);
			this.btn_exit.TabIndex = 3;
			this.btn_exit.Text = "退出";
			this.btn_exit.UseVisualStyleBackColor = true;
			this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(213, 77);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 29);
			this.label1.TabIndex = 4;
			this.label1.Text = "计时：";
			// 
			// lab_timeCount
			// 
			this.lab_timeCount.AutoSize = true;
			this.lab_timeCount.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lab_timeCount.Location = new System.Drawing.Point(319, 77);
			this.lab_timeCount.Name = "lab_timeCount";
			this.lab_timeCount.Size = new System.Drawing.Size(0, 29);
			this.lab_timeCount.TabIndex = 5;
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.排行榜ToolStripMenuItem,
            this.退出ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(884, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 开始ToolStripMenuItem
			// 
			this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
			this.开始ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.开始ToolStripMenuItem.Text = "开始";
			this.开始ToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
			// 
			// 排行榜ToolStripMenuItem
			// 
			this.排行榜ToolStripMenuItem.Name = "排行榜ToolStripMenuItem";
			this.排行榜ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.排行榜ToolStripMenuItem.Text = "排行榜";
			this.排行榜ToolStripMenuItem.Click += new System.EventHandler(this.排行榜ToolStripMenuItem_Click);
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
			// 
			// btn_key
			// 
			this.btn_key.Enabled = false;
			this.btn_key.Location = new System.Drawing.Point(540, 60);
			this.btn_key.Name = "btn_key";
			this.btn_key.Size = new System.Drawing.Size(100, 62);
			this.btn_key.TabIndex = 7;
			this.btn_key.Text = "提示";
			this.btn_key.UseVisualStyleBackColor = true;
			this.btn_key.Click += new System.EventHandler(this.btn_key_Click);
			// 
			// Frm_LianLianKan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 661);
			this.Controls.Add(this.btn_key);
			this.Controls.Add(this.lab_timeCount);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_exit);
			this.Controls.Add(this.panel_gameArea);
			this.Controls.Add(this.btn_start);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Frm_LianLianKan";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "连连看";
			this.Load += new System.EventHandler(this.Frm_LianLianKan_Load);
			this.panel_gameArea.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_start;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.Panel panel_gameArea;
		private System.Windows.Forms.Button btn_exit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lab_timeCount;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 排行榜ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
		private System.Windows.Forms.Button btn_key;
	}
}

