namespace FacebookApp.Forms
{
    public partial class formLogIn
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
            this.picProfilePicture = new System.Windows.Forms.PictureBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnFindMatch = new System.Windows.Forms.Button();
            this.btnFunniestPost = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // picProfilePicture
            // 
            this.picProfilePicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picProfilePicture.Location = new System.Drawing.Point(12, 12);
            this.picProfilePicture.Name = "picProfilePicture";
            this.picProfilePicture.Size = new System.Drawing.Size(160, 160);
            this.picProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProfilePicture.TabIndex = 0;
            this.picProfilePicture.TabStop = false;
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Location = new System.Drawing.Point(12, 178);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(160, 40);
            this.btnLogIn.TabIndex = 1;
            this.btnLogIn.Text = "Log In Facebook";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Mistral", 42F);
            this.lblWelcome.Location = new System.Drawing.Point(206, 12);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(334, 77);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFindMatch
            // 
            this.btnFindMatch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(97)))), ((int)(((byte)(168)))));
            this.btnFindMatch.Enabled = false;
            this.btnFindMatch.ForeColor = System.Drawing.Color.White;
            this.btnFindMatch.Location = new System.Drawing.Point(220, 178);
            this.btnFindMatch.Name = "btnFindMatch";
            this.btnFindMatch.Size = new System.Drawing.Size(160, 40);
            this.btnFindMatch.TabIndex = 1;
            this.btnFindMatch.Text = "Secret Admire!";
            this.btnFindMatch.UseVisualStyleBackColor = false;
            this.btnFindMatch.Click += new System.EventHandler(this.btnFindMatch_Click);
            // 
            // btnFunniestPost
            // 
            this.btnFunniestPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(185)))), ((int)(((byte)(181)))));
            this.btnFunniestPost.Enabled = false;
            this.btnFunniestPost.ForeColor = System.Drawing.Color.White;
            this.btnFunniestPost.Location = new System.Drawing.Point(386, 178);
            this.btnFunniestPost.Name = "btnFunniestPost";
            this.btnFunniestPost.Size = new System.Drawing.Size(160, 40);
            this.btnFunniestPost.TabIndex = 1;
            this.btnFunniestPost.Text = "Funniest Post!";
            this.btnFunniestPost.UseVisualStyleBackColor = false;
            this.btnFunniestPost.Click += new System.EventHandler(this.btnFunniestPost_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Mistral", 42F);
            this.lblUserName.Location = new System.Drawing.Point(209, 89);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(334, 77);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "userName";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUserName.Visible = false;
            // 
            // formLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(552, 239);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnFunniestPost);
            this.Controls.Add(this.btnFindMatch);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.picProfilePicture);
            this.MaximizeBox = false;
            this.Name = "formLogIn";
            this.Text = "Welcome";
            ((System.ComponentModel.ISupportInitialize)(this.picProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picProfilePicture;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnFindMatch;
        private System.Windows.Forms.Button btnFunniestPost;
        private System.Windows.Forms.Label lblUserName;
    }
}