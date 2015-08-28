namespace ConsumingWebServicesClientGrpfic
{
    partial class PlayGame
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxAccessToken = new System.Windows.Forms.TextBox();
            this.textBoxGameId = new System.Windows.Forms.TextBox();
            this.textBoxPositionX = new System.Windows.Forms.TextBox();
            this.textBoxPositionY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxAccessToken
            // 
            this.textBoxAccessToken.Location = new System.Drawing.Point(212, 50);
            this.textBoxAccessToken.Name = "textBoxAccessToken";
            this.textBoxAccessToken.Size = new System.Drawing.Size(185, 20);
            this.textBoxAccessToken.TabIndex = 1;
            // 
            // textBoxGameId
            // 
            this.textBoxGameId.Location = new System.Drawing.Point(212, 100);
            this.textBoxGameId.Name = "textBoxGameId";
            this.textBoxGameId.Size = new System.Drawing.Size(185, 20);
            this.textBoxGameId.TabIndex = 2;
            // 
            // textBoxPositionX
            // 
            this.textBoxPositionX.Location = new System.Drawing.Point(212, 155);
            this.textBoxPositionX.Name = "textBoxPositionX";
            this.textBoxPositionX.Size = new System.Drawing.Size(185, 20);
            this.textBoxPositionX.TabIndex = 3;
            // 
            // textBoxPositionY
            // 
            this.textBoxPositionY.Location = new System.Drawing.Point(212, 217);
            this.textBoxPositionY.Name = "textBoxPositionY";
            this.textBoxPositionY.Size = new System.Drawing.Size(185, 20);
            this.textBoxPositionY.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Accsess token:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Position on axis Y:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Position on axis X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Game identity number:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // PlayGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 423);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPositionY);
            this.Controls.Add(this.textBoxPositionX);
            this.Controls.Add(this.textBoxGameId);
            this.Controls.Add(this.textBoxAccessToken);
            this.Controls.Add(this.button1);
            this.Name = "PlayGame";
            this.Text = "t";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxAccessToken;
        private System.Windows.Forms.TextBox textBoxGameId;
        private System.Windows.Forms.TextBox textBoxPositionX;
        private System.Windows.Forms.TextBox textBoxPositionY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}