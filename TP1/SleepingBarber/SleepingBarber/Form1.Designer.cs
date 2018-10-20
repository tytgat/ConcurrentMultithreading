namespace SleepingBarber
{
    partial class formBarberShop
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
            this.buttonAddClient = new System.Windows.Forms.Button();
            this.pbChair1 = new System.Windows.Forms.PictureBox();
            this.pbChair2 = new System.Windows.Forms.PictureBox();
            this.pbChair3 = new System.Windows.Forms.PictureBox();
            this.pbChair6 = new System.Windows.Forms.PictureBox();
            this.pbChair5 = new System.Windows.Forms.PictureBox();
            this.pbChair4 = new System.Windows.Forms.PictureBox();
            this.pbWorkingChair = new System.Windows.Forms.PictureBox();
            this.pbBarberChair = new System.Windows.Forms.PictureBox();
            this.progressBarWorking = new System.Windows.Forms.ProgressBar();
            this.panelWaitingRoom = new System.Windows.Forms.Panel();
            this.labelClient = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbChair1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChair2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChair3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChair6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChair5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChair4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWorkingChair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarberChair)).BeginInit();
            this.panelWaitingRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddClient
            // 
            this.buttonAddClient.Location = new System.Drawing.Point(18, 240);
            this.buttonAddClient.Name = "buttonAddClient";
            this.buttonAddClient.Size = new System.Drawing.Size(227, 41);
            this.buttonAddClient.TabIndex = 1;
            this.buttonAddClient.Text = "Add Client";
            this.buttonAddClient.UseVisualStyleBackColor = true;
            this.buttonAddClient.Click += new System.EventHandler(this.buttonAddClient_Click);
            // 
            // pbChair1
            // 
            this.pbChair1.Location = new System.Drawing.Point(3, 18);
            this.pbChair1.Name = "pbChair1";
            this.pbChair1.Size = new System.Drawing.Size(50, 50);
            this.pbChair1.TabIndex = 0;
            this.pbChair1.TabStop = false;
            // 
            // pbChair2
            // 
            this.pbChair2.Location = new System.Drawing.Point(3, 74);
            this.pbChair2.Name = "pbChair2";
            this.pbChair2.Size = new System.Drawing.Size(50, 50);
            this.pbChair2.TabIndex = 1;
            this.pbChair2.TabStop = false;
            // 
            // pbChair3
            // 
            this.pbChair3.Location = new System.Drawing.Point(3, 130);
            this.pbChair3.Name = "pbChair3";
            this.pbChair3.Size = new System.Drawing.Size(50, 50);
            this.pbChair3.TabIndex = 2;
            this.pbChair3.TabStop = false;
            // 
            // pbChair6
            // 
            this.pbChair6.Location = new System.Drawing.Point(59, 130);
            this.pbChair6.Name = "pbChair6";
            this.pbChair6.Size = new System.Drawing.Size(50, 50);
            this.pbChair6.TabIndex = 5;
            this.pbChair6.TabStop = false;
            // 
            // pbChair5
            // 
            this.pbChair5.Location = new System.Drawing.Point(59, 74);
            this.pbChair5.Name = "pbChair5";
            this.pbChair5.Size = new System.Drawing.Size(50, 50);
            this.pbChair5.TabIndex = 4;
            this.pbChair5.TabStop = false;
            // 
            // pbChair4
            // 
            this.pbChair4.Location = new System.Drawing.Point(59, 18);
            this.pbChair4.Name = "pbChair4";
            this.pbChair4.Size = new System.Drawing.Size(50, 50);
            this.pbChair4.TabIndex = 3;
            this.pbChair4.TabStop = false;
            // 
            // pbWorkingChair
            // 
            this.pbWorkingChair.Location = new System.Drawing.Point(195, 31);
            this.pbWorkingChair.Name = "pbWorkingChair";
            this.pbWorkingChair.Size = new System.Drawing.Size(50, 50);
            this.pbWorkingChair.TabIndex = 6;
            this.pbWorkingChair.TabStop = false;
            // 
            // pbBarberChair
            // 
            this.pbBarberChair.Location = new System.Drawing.Point(195, 143);
            this.pbBarberChair.Name = "pbBarberChair";
            this.pbBarberChair.Size = new System.Drawing.Size(50, 50);
            this.pbBarberChair.TabIndex = 7;
            this.pbBarberChair.TabStop = false;
            // 
            // progressBarWorking
            // 
            this.progressBarWorking.Enabled = false;
            this.progressBarWorking.Location = new System.Drawing.Point(195, 87);
            this.progressBarWorking.MarqueeAnimationSpeed = 100000;
            this.progressBarWorking.Name = "progressBarWorking";
            this.progressBarWorking.Size = new System.Drawing.Size(50, 23);
            this.progressBarWorking.Step = 1;
            this.progressBarWorking.TabIndex = 1;
            // 
            // panelWaitingRoom
            // 
            this.panelWaitingRoom.Controls.Add(this.pbChair1);
            this.panelWaitingRoom.Controls.Add(this.pbChair6);
            this.panelWaitingRoom.Controls.Add(this.pbChair2);
            this.panelWaitingRoom.Controls.Add(this.pbChair3);
            this.panelWaitingRoom.Controls.Add(this.pbChair5);
            this.panelWaitingRoom.Controls.Add(this.pbChair4);
            this.panelWaitingRoom.Location = new System.Drawing.Point(18, 13);
            this.panelWaitingRoom.Name = "panelWaitingRoom";
            this.panelWaitingRoom.Size = new System.Drawing.Size(113, 192);
            this.panelWaitingRoom.TabIndex = 9;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(21, 221);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(0, 13);
            this.labelClient.TabIndex = 10;
            // 
            // formBarberShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 293);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.panelWaitingRoom);
            this.Controls.Add(this.progressBarWorking);
            this.Controls.Add(this.pbBarberChair);
            this.Controls.Add(this.pbWorkingChair);
            this.Controls.Add(this.buttonAddClient);
            this.Name = "formBarberShop";
            this.Text = "Barber Shop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formBarberShop_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbChair1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChair2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChair3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChair6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChair5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChair4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWorkingChair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBarberChair)).EndInit();
            this.panelWaitingRoom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbChair6;
        private System.Windows.Forms.PictureBox pbChair5;
        private System.Windows.Forms.PictureBox pbChair4;
        private System.Windows.Forms.PictureBox pbChair3;
        private System.Windows.Forms.PictureBox pbChair2;
        private System.Windows.Forms.PictureBox pbChair1;
        private System.Windows.Forms.Button buttonAddClient;
        private System.Windows.Forms.PictureBox pbWorkingChair;
        private System.Windows.Forms.PictureBox pbBarberChair;
        private System.Windows.Forms.ProgressBar progressBarWorking;
        private System.Windows.Forms.Panel panelWaitingRoom;
        private System.Windows.Forms.Label labelClient;
    }
}

