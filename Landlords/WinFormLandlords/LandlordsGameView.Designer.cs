namespace WinFormLandlords
{
    partial class LandlordsGameView
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
            this.btnPrepare = new System.Windows.Forms.Button();
            this.pnoMe = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTakeOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrepare
            // 
            this.btnPrepare.Location = new System.Drawing.Point(364, 228);
            this.btnPrepare.Name = "btnPrepare";
            this.btnPrepare.Size = new System.Drawing.Size(75, 23);
            this.btnPrepare.TabIndex = 0;
            this.btnPrepare.Text = "Prepare";
            this.btnPrepare.UseVisualStyleBackColor = true;
            this.btnPrepare.Click += new System.EventHandler(this.btnPrepare_Click);
            // 
            // pnoMe
            // 
            this.pnoMe.Location = new System.Drawing.Point(217, 387);
            this.pnoMe.Name = "pnoMe";
            this.pnoMe.Size = new System.Drawing.Size(583, 174);
            this.pnoMe.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 392);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(810, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 392);
            this.panel2.TabIndex = 3;
            // 
            // btnTakeOut
            // 
            this.btnTakeOut.Location = new System.Drawing.Point(492, 228);
            this.btnTakeOut.Name = "btnTakeOut";
            this.btnTakeOut.Size = new System.Drawing.Size(75, 23);
            this.btnTakeOut.TabIndex = 4;
            this.btnTakeOut.Text = "Take Out";
            this.btnTakeOut.UseVisualStyleBackColor = true;
            this.btnTakeOut.Click += new System.EventHandler(this.btnTakeOut_Click);
            // 
            // LandlordsGameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 615);
            this.Controls.Add(this.btnTakeOut);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnoMe);
            this.Controls.Add(this.btnPrepare);
            this.Name = "LandlordsGameView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrepare;
        private System.Windows.Forms.Panel pnoMe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTakeOut;
    }
}

