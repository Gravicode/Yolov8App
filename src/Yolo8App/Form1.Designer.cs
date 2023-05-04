namespace Yolo8App {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            PicBox1 = new PictureBox();
            BtnStart = new Button();
            BtnStop = new Button();
            TxtStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)PicBox1).BeginInit();
            SuspendLayout();
            // 
            // PicBox1
            // 
            PicBox1.BorderStyle = BorderStyle.FixedSingle;
            PicBox1.Location = new Point(12, 12);
            PicBox1.Name = "PicBox1";
            PicBox1.Size = new Size(448, 333);
            PicBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            PicBox1.TabIndex = 0;
            PicBox1.TabStop = false;
            // 
            // BtnStart
            // 
            BtnStart.Location = new Point(12, 368);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(75, 23);
            BtnStart.TabIndex = 1;
            BtnStart.Text = "&Start";
            BtnStart.UseVisualStyleBackColor = true;
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(93, 368);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(75, 23);
            BtnStop.TabIndex = 2;
            BtnStop.Text = "&Stop";
            BtnStop.UseVisualStyleBackColor = true;
            // 
            // TxtStatus
            // 
            TxtStatus.AutoSize = true;
            TxtStatus.Location = new Point(12, 348);
            TxtStatus.Name = "TxtStatus";
            TxtStatus.Size = new Size(84, 15);
            TxtStatus.TabIndex = 3;
            TxtStatus.Text = "Start to begin..";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TxtStatus);
            Controls.Add(BtnStop);
            Controls.Add(BtnStart);
            Controls.Add(PicBox1);
            Name = "Form1";
            Text = "Yolo v8 App";
            ((System.ComponentModel.ISupportInitialize)PicBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PicBox1;
        private Button BtnStart;
        private Button BtnStop;
        private Label TxtStatus;
    }
}