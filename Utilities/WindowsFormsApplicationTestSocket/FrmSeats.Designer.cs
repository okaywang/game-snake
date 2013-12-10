namespace WindowsFormsApplicationTestSocket
{
    partial class FrmSeats
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
            this.btnBottom = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBottom
            // 
            this.btnBottom.Location = new System.Drawing.Point(192, 170);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(75, 50);
            this.btnBottom.TabIndex = 0;
            this.btnBottom.Tag = "3";
            this.btnBottom.Text = "sit here";
            this.btnBottom.UseVisualStyleBackColor = true;
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(102, 74);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 50);
            this.btnLeft.TabIndex = 0;
            this.btnLeft.Tag = "1";
            this.btnLeft.Text = "sit here";
            this.btnLeft.UseVisualStyleBackColor = true;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(275, 74);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 50);
            this.btnRight.TabIndex = 0;
            this.btnRight.Tag = "2";
            this.btnRight.Text = "sit here";
            this.btnRight.UseVisualStyleBackColor = true;
            // 
            // FrmSeats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 322);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnBottom);
            this.Name = "FrmSeats";
            this.Text = "FrmChooseSeat";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBottom;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
    }
}