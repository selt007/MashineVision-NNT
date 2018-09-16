namespace NNTSearchChar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.picture1 = new System.Windows.Forms.PictureBox();
            this.buttonRemember = new System.Windows.Forms.Button();
            this.picture2 = new System.Windows.Forms.PictureBox();
            this.textFaceId = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.buttonTrain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // picture1
            // 
            this.picture1.BackColor = System.Drawing.Color.White;
            this.picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture1.Location = new System.Drawing.Point(22, 21);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(192, 192);
            this.picture1.TabIndex = 0;
            this.picture1.TabStop = false;
            this.picture1.Visible = false;
            this.picture1.Paint += new System.Windows.Forms.PaintEventHandler(this.picture1_Paint);
            this.picture1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture1_MouseDown);
            this.picture1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture1_MouseMove);
            // 
            // buttonRemember
            // 
            this.buttonRemember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemember.Location = new System.Drawing.Point(12, 345);
            this.buttonRemember.Name = "buttonRemember";
            this.buttonRemember.Size = new System.Drawing.Size(131, 38);
            this.buttonRemember.TabIndex = 1;
            this.buttonRemember.Text = "Remember face";
            this.buttonRemember.UseVisualStyleBackColor = true;
            this.buttonRemember.Click += new System.EventHandler(this.button_Click);
            // 
            // picture2
            // 
            this.picture2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture2.Location = new System.Drawing.Point(12, 12);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(300, 299);
            this.picture2.TabIndex = 2;
            this.picture2.TabStop = false;
            // 
            // textFaceId
            // 
            this.textFaceId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFaceId.Location = new System.Drawing.Point(12, 319);
            this.textFaceId.Name = "textFaceId";
            this.textFaceId.Size = new System.Drawing.Size(300, 20);
            this.textFaceId.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 386);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(324, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // progressBar
            // 
            this.progressBar.Maximum = 15;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // buttonTrain
            // 
            this.buttonTrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTrain.Location = new System.Drawing.Point(171, 346);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(141, 37);
            this.buttonTrain.TabIndex = 5;
            this.buttonTrain.Text = "Train";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 408);
            this.Controls.Add(this.buttonTrain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.textFaceId);
            this.Controls.Add(this.picture1);
            this.Controls.Add(this.picture2);
            this.Controls.Add(this.buttonRemember);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Image";
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture1;
        private System.Windows.Forms.Button buttonRemember;
        private System.Windows.Forms.PictureBox picture2;
        private System.Windows.Forms.TextBox textFaceId;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Button buttonTrain;
    }
}

