﻿namespace NNTSearchChar
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.picture1 = new System.Windows.Forms.PictureBox();
            this.button = new System.Windows.Forms.Button();
            this.picture2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            this.SuspendLayout();
            // 
            // picture1
            // 
            this.picture1.BackColor = System.Drawing.Color.White;
            this.picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture1.Location = new System.Drawing.Point(13, 13);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(192, 192);
            this.picture1.TabIndex = 0;
            this.picture1.TabStop = false;
            this.picture1.Paint += new System.Windows.Forms.PaintEventHandler(this.picture1_Paint);
            this.picture1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture1_MouseDown);
            this.picture1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture1_MouseMove);
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(211, 320);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(302, 39);
            this.button.TabIndex = 1;
            this.button.Text = "Тест";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // picture2
            // 
            this.picture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture2.Location = new System.Drawing.Point(211, 12);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(302, 302);
            this.picture2.TabIndex = 2;
            this.picture2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 369);
            this.Controls.Add(this.picture2);
            this.Controls.Add(this.button);
            this.Controls.Add(this.picture1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Image";
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picture1;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.PictureBox picture2;
    }
}
