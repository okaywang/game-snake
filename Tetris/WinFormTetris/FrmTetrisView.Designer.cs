namespace WinFormTetris
{
    partial class FrmTetrisView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.tetrominoChest1 = new WindowsFormsApplication1.TetrominoChest();
            this.tetrominoChest2 = new WindowsFormsApplication1.TetrominoChest();
            this.lblScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tetrominoChest1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrominoChest2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(28, 28);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(143, 54);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(196, 25);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(143, 57);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(366, 24);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(143, 58);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tetrominoChest1
            // 
            this.tetrominoChest1.BackColor = System.Drawing.Color.Tan;
            this.tetrominoChest1.Location = new System.Drawing.Point(116, 135);
            this.tetrominoChest1.Name = "tetrominoChest1";
            this.tetrominoChest1.Size = new System.Drawing.Size(197, 318);
            this.tetrominoChest1.TabIndex = 0;
            this.tetrominoChest1.TabStop = false;
            this.tetrominoChest1.Text = "tetrominoChest1";
            // 
            // tetrominoChest2
            // 
            this.tetrominoChest2.BackColor = System.Drawing.Color.Tan;
            this.tetrominoChest2.Location = new System.Drawing.Point(335, 135);
            this.tetrominoChest2.Name = "tetrominoChest2";
            this.tetrominoChest2.Size = new System.Drawing.Size(100, 77);
            this.tetrominoChest2.TabIndex = 4;
            this.tetrominoChest2.TabStop = false;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(342, 293);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(60, 32);
            this.lblScore.TabIndex = 5;
            this.lblScore.Text = "400";
            // 
            // FrmTetrisView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 465);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.tetrominoChest2);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tetrominoChest1);
            this.KeyPreview = true;
            this.Name = "FrmTetrisView";
            this.Text = "Form1";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmTetrisView_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.tetrominoChest1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrominoChest2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WindowsFormsApplication1.TetrominoChest tetrominoChest1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRestart;
        private WindowsFormsApplication1.TetrominoChest tetrominoChest2;
        private System.Windows.Forms.Label lblScore;
    }
}

