﻿namespace NugetSync
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnOpen1 = new System.Windows.Forms.Button();
            this.btnOpen2 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnOpenDir1 = new System.Windows.Forms.Button();
            this.btnOpenDir2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxAdd = new System.Windows.Forms.CheckBox();
            this.checkBoxUpdate = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 53);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(548, 141);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 53);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(548, 141);
            this.textBox2.TabIndex = 1;
            // 
            // btnOpen1
            // 
            this.btnOpen1.Location = new System.Drawing.Point(6, 22);
            this.btnOpen1.Name = "btnOpen1";
            this.btnOpen1.Size = new System.Drawing.Size(75, 25);
            this.btnOpen1.TabIndex = 2;
            this.btnOpen1.Text = "文件";
            this.btnOpen1.UseVisualStyleBackColor = true;
            this.btnOpen1.Click += new System.EventHandler(this.btnOpen1_Click);
            // 
            // btnOpen2
            // 
            this.btnOpen2.Location = new System.Drawing.Point(6, 22);
            this.btnOpen2.Name = "btnOpen2";
            this.btnOpen2.Size = new System.Drawing.Size(75, 25);
            this.btnOpen2.TabIndex = 3;
            this.btnOpen2.Text = "文件";
            this.btnOpen2.UseVisualStyleBackColor = true;
            this.btnOpen2.Click += new System.EventHandler(this.btnOpen2_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(491, 424);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnOpenDir1
            // 
            this.btnOpenDir1.Location = new System.Drawing.Point(87, 22);
            this.btnOpenDir1.Name = "btnOpenDir1";
            this.btnOpenDir1.Size = new System.Drawing.Size(75, 25);
            this.btnOpenDir1.TabIndex = 5;
            this.btnOpenDir1.Text = "目录";
            this.btnOpenDir1.UseVisualStyleBackColor = true;
            this.btnOpenDir1.Click += new System.EventHandler(this.btnOpenDir1_Click);
            // 
            // btnOpenDir2
            // 
            this.btnOpenDir2.Location = new System.Drawing.Point(87, 22);
            this.btnOpenDir2.Name = "btnOpenDir2";
            this.btnOpenDir2.Size = new System.Drawing.Size(75, 25);
            this.btnOpenDir2.TabIndex = 6;
            this.btnOpenDir2.Text = "目录";
            this.btnOpenDir2.UseVisualStyleBackColor = true;
            this.btnOpenDir2.Click += new System.EventHandler(this.btnOpenDir2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenDir1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnOpen1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 200);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "来源";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpen2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.btnOpenDir2);
            this.groupBox2.Location = new System.Drawing.Point(12, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 200);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目标";
            // 
            // checkBoxAdd
            // 
            this.checkBoxAdd.AutoSize = true;
            this.checkBoxAdd.Location = new System.Drawing.Point(75, 424);
            this.checkBoxAdd.Name = "checkBoxAdd";
            this.checkBoxAdd.Size = new System.Drawing.Size(51, 21);
            this.checkBoxAdd.TabIndex = 9;
            this.checkBoxAdd.Text = "新增";
            this.checkBoxAdd.UseVisualStyleBackColor = true;
            // 
            // checkBoxUpdate
            // 
            this.checkBoxUpdate.AutoSize = true;
            this.checkBoxUpdate.Location = new System.Drawing.Point(18, 424);
            this.checkBoxUpdate.Name = "checkBoxUpdate";
            this.checkBoxUpdate.Size = new System.Drawing.Size(51, 21);
            this.checkBoxUpdate.TabIndex = 10;
            this.checkBoxUpdate.Text = "更新";
            this.checkBoxUpdate.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(410, 424);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 25);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "帮助";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 456);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.checkBoxUpdate);
            this.Controls.Add(this.checkBoxAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuget包修复工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnOpen1;
        private System.Windows.Forms.Button btnOpen2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnOpenDir1;
        private System.Windows.Forms.Button btnOpenDir2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxAdd;
        private System.Windows.Forms.CheckBox checkBoxUpdate;
        private System.Windows.Forms.Button btnHelp;
    }
}

