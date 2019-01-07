namespace AtlasGM.Controls
{
    partial class ExperienceControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.Exp = new System.Windows.Forms.TextBox();
            this.IsOnly = new System.Windows.Forms.CheckBox();
            this.AddExperience = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "经验值：";
            // 
            // Exp
            // 
            this.Exp.Location = new System.Drawing.Point(79, 15);
            this.Exp.Name = "Exp";
            this.Exp.Size = new System.Drawing.Size(100, 21);
            this.Exp.TabIndex = 1;
            // 
            // IsOnly
            // 
            this.IsOnly.AutoSize = true;
            this.IsOnly.Location = new System.Drawing.Point(22, 54);
            this.IsOnly.Name = "IsOnly";
            this.IsOnly.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.IsOnly.Size = new System.Drawing.Size(84, 16);
            this.IsOnly.TabIndex = 2;
            this.IsOnly.Text = "：用户独享";
            this.IsOnly.UseVisualStyleBackColor = true;
            // 
            // AddExperience
            // 
            this.AddExperience.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddExperience.Location = new System.Drawing.Point(123, 50);
            this.AddExperience.Name = "AddExperience";
            this.AddExperience.Size = new System.Drawing.Size(75, 23);
            this.AddExperience.TabIndex = 3;
            this.AddExperience.Text = "确定";
            this.AddExperience.UseVisualStyleBackColor = true;
            this.AddExperience.Click += new System.EventHandler(this.AddExperience_Click);
            // 
            // ExperienceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddExperience);
            this.Controls.Add(this.IsOnly);
            this.Controls.Add(this.Exp);
            this.Controls.Add(this.label1);
            this.Name = "ExperienceControl";
            this.Size = new System.Drawing.Size(255, 89);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Exp;
        private System.Windows.Forms.CheckBox IsOnly;
        private System.Windows.Forms.Button AddExperience;
    }
}
