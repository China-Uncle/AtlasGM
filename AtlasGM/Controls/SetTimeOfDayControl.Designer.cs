namespace AtlasGM.Controls
{
    partial class SetTimeOfDayControl
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
            this.SetTimeOfDay = new System.Windows.Forms.Button();
            this.TextValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SetTimeOfDay
            // 
            this.SetTimeOfDay.Location = new System.Drawing.Point(167, 19);
            this.SetTimeOfDay.Name = "SetTimeOfDay";
            this.SetTimeOfDay.Size = new System.Drawing.Size(75, 23);
            this.SetTimeOfDay.TabIndex = 5;
            this.SetTimeOfDay.Text = "确定";
            this.SetTimeOfDay.UseVisualStyleBackColor = true;
            this.SetTimeOfDay.Click += new System.EventHandler(this.SetTimeOfDay_Click);
            // 
            // TextValue
            // 
            this.TextValue.Location = new System.Drawing.Point(61, 21);
            this.TextValue.Name = "TextValue";
            this.TextValue.Size = new System.Drawing.Size(100, 21);
            this.TextValue.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "时间：";
            // 
            // SetTimeOfDayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SetTimeOfDay);
            this.Controls.Add(this.TextValue);
            this.Controls.Add(this.label1);
            this.Name = "SetTimeOfDayControl";
            this.Size = new System.Drawing.Size(263, 65);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SetTimeOfDay;
        private System.Windows.Forms.TextBox TextValue;
        private System.Windows.Forms.Label label1;
    }
}
