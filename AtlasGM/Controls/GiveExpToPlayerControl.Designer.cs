namespace AtlasGM.Controls
{
    partial class GiveExpToPlayerControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.GiveExpToPlayer = new System.Windows.Forms.Button();
            this.Exp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GiveExpToPlayer
            // 
            this.GiveExpToPlayer.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.GiveExpToPlayer.Location = new System.Drawing.Point(180, 32);
            this.GiveExpToPlayer.Name = "GiveExpToPlayer";
            this.GiveExpToPlayer.Size = new System.Drawing.Size(75, 23);
            this.GiveExpToPlayer.TabIndex = 9;
            this.GiveExpToPlayer.Text = "确定";
            this.GiveExpToPlayer.UseVisualStyleBackColor = true;
            this.GiveExpToPlayer.Click += new System.EventHandler(this.GiveExpToPlayer_Click);
            // 
            // Exp
            // 
            this.Exp.Location = new System.Drawing.Point(59, 47);
            this.Exp.Name = "Exp";
            this.Exp.Size = new System.Drawing.Size(100, 21);
            this.Exp.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "经验值：";
            // 
            // UserId
            // 
            this.UserId.Location = new System.Drawing.Point(59, 11);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(100, 21);
            this.UserId.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "玩家ID：";
            // 
            // GiveExpToPlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GiveExpToPlayer);
            this.Controls.Add(this.Exp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.label1);
            this.Name = "GiveExpToPlayerControl";
            this.Size = new System.Drawing.Size(268, 85);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GiveExpToPlayer;
        private System.Windows.Forms.TextBox Exp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserId;
        private System.Windows.Forms.Label label1;
    }
}
