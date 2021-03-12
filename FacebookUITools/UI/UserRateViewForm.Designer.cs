namespace FacebookTools.UI
{
    public partial class UserRateViewForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label likesLabel;
            System.Windows.Forms.Label commentsLabel;
            System.Windows.Forms.Label nameLabel2;
            System.Windows.Forms.Label nameLabel3;
            System.Windows.Forms.Label nameLabel4;
            this.userRateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameLabel1 = new System.Windows.Forms.Label();
            this.likesLabel1 = new System.Windows.Forms.Label();
            this.commentsLabel1 = new System.Windows.Forms.Label();
            this.eventsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameListBox = new System.Windows.Forms.ListBox();
            this.pagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameListBox1 = new System.Windows.Forms.ListBox();
            this.nameListBox2 = new System.Windows.Forms.ListBox();
            this.imageLargePictureBox = new System.Windows.Forms.PictureBox();
            nameLabel = new System.Windows.Forms.Label();
            likesLabel = new System.Windows.Forms.Label();
            commentsLabel = new System.Windows.Forms.Label();
            nameLabel2 = new System.Windows.Forms.Label();
            nameLabel3 = new System.Windows.Forms.Label();
            nameLabel4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userRateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLargePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // userRateBindingSource
            // 
            this.userRateBindingSource.DataSource = typeof(FacebookTools.UserRate);
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(12, 9);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(49, 17);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name:";
            // 
            // nameLabel1
            // 
            this.nameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userRateBindingSource, "User.Name", true));
            this.nameLabel1.Location = new System.Drawing.Point(67, 9);
            this.nameLabel1.Name = "nameLabel1";
            this.nameLabel1.Size = new System.Drawing.Size(100, 23);
            this.nameLabel1.TabIndex = 1;
            this.nameLabel1.Text = "label1";
            // 
            // likesLabel
            // 
            likesLabel.AutoSize = true;
            likesLabel.Location = new System.Drawing.Point(12, 30);
            likesLabel.Name = "likesLabel";
            likesLabel.Size = new System.Drawing.Size(45, 17);
            likesLabel.TabIndex = 2;
            likesLabel.Text = "Likes:";
            // 
            // likesLabel1
            // 
            this.likesLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userRateBindingSource, "Likes", true));
            this.likesLabel1.Location = new System.Drawing.Point(63, 30);
            this.likesLabel1.Name = "likesLabel1";
            this.likesLabel1.Size = new System.Drawing.Size(100, 18);
            this.likesLabel1.TabIndex = 3;
            this.likesLabel1.Text = "label1";
            // 
            // commentsLabel
            // 
            commentsLabel.AutoSize = true;
            commentsLabel.Location = new System.Drawing.Point(12, 51);
            commentsLabel.Name = "commentsLabel";
            commentsLabel.Size = new System.Drawing.Size(78, 17);
            commentsLabel.TabIndex = 4;
            commentsLabel.Text = "Comments:";
            // 
            // commentsLabel1
            // 
            this.commentsLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.userRateBindingSource, "Comments", true));
            this.commentsLabel1.Location = new System.Drawing.Point(96, 51);
            this.commentsLabel1.Name = "commentsLabel1";
            this.commentsLabel1.Size = new System.Drawing.Size(100, 23);
            this.commentsLabel1.TabIndex = 5;
            this.commentsLabel1.Text = "label1";
            // 
            // eventsBindingSource
            // 
            this.eventsBindingSource.DataMember = "Events";
            this.eventsBindingSource.DataSource = this.userRateBindingSource;
            // 
            // groupsBindingSource
            // 
            this.groupsBindingSource.DataMember = "Groups";
            this.groupsBindingSource.DataSource = this.userRateBindingSource;
            // 
            // nameLabel2
            // 
            nameLabel2.AutoSize = true;
            nameLabel2.Location = new System.Drawing.Point(12, 77);
            nameLabel2.Name = "nameLabel2";
            nameLabel2.Size = new System.Drawing.Size(59, 17);
            nameLabel2.TabIndex = 6;
            nameLabel2.Text = "Groups:";
            // 
            // nameListBox
            // 
            this.nameListBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.groupsBindingSource, "Name", true));
            this.nameListBox.FormattingEnabled = true;
            this.nameListBox.ItemHeight = 16;
            this.nameListBox.Location = new System.Drawing.Point(77, 77);
            this.nameListBox.Name = "nameListBox";
            this.nameListBox.Size = new System.Drawing.Size(195, 84);
            this.nameListBox.TabIndex = 7;
            // 
            // pagesBindingSource
            // 
            this.pagesBindingSource.DataMember = "Pages";
            this.pagesBindingSource.DataSource = this.userRateBindingSource;
            // 
            // nameLabel3
            // 
            nameLabel3.AutoSize = true;
            nameLabel3.Location = new System.Drawing.Point(12, 166);
            nameLabel3.Name = "nameLabel3";
            nameLabel3.Size = new System.Drawing.Size(52, 17);
            nameLabel3.TabIndex = 8;
            nameLabel3.Text = "Pages:";
            // 
            // nameListBox1
            // 
            this.nameListBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.pagesBindingSource, "Name", true));
            this.nameListBox1.FormattingEnabled = true;
            this.nameListBox1.ItemHeight = 16;
            this.nameListBox1.Location = new System.Drawing.Point(77, 166);
            this.nameListBox1.Name = "nameListBox1";
            this.nameListBox1.Size = new System.Drawing.Size(195, 84);
            this.nameListBox1.TabIndex = 9;
            // 
            // nameLabel4
            // 
            nameLabel4.AutoSize = true;
            nameLabel4.Location = new System.Drawing.Point(15, 256);
            nameLabel4.Name = "nameLabel4";
            nameLabel4.Size = new System.Drawing.Size(55, 17);
            nameLabel4.TabIndex = 10;
            nameLabel4.Text = "Events:";
            // 
            // nameListBox2
            // 
            this.nameListBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.eventsBindingSource, "Name", true));
            this.nameListBox2.FormattingEnabled = true;
            this.nameListBox2.ItemHeight = 16;
            this.nameListBox2.Location = new System.Drawing.Point(76, 256);
            this.nameListBox2.Name = "nameListBox2";
            this.nameListBox2.Size = new System.Drawing.Size(196, 84);
            this.nameListBox2.TabIndex = 11;
            // 
            // imageLargePictureBox
            // 
            this.imageLargePictureBox.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.userRateBindingSource, "User.ImageLarge", true));
            this.imageLargePictureBox.Location = new System.Drawing.Point(202, 9);
            this.imageLargePictureBox.Name = "imageLargePictureBox";
            this.imageLargePictureBox.Size = new System.Drawing.Size(71, 65);
            this.imageLargePictureBox.TabIndex = 13;
            this.imageLargePictureBox.TabStop = false;
            // 
            // UserRateViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 345);
            this.Controls.Add(this.imageLargePictureBox);
            this.Controls.Add(nameLabel4);
            this.Controls.Add(this.nameListBox2);
            this.Controls.Add(nameLabel3);
            this.Controls.Add(this.nameListBox1);
            this.Controls.Add(nameLabel2);
            this.Controls.Add(this.nameListBox);
            this.Controls.Add(commentsLabel);
            this.Controls.Add(this.commentsLabel1);
            this.Controls.Add(likesLabel);
            this.Controls.Add(this.likesLabel1);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameLabel1);
            this.Name = "UserRateViewForm";
            this.Text = "UserRateViewForm";
            ((System.ComponentModel.ISupportInitialize)(this.userRateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageLargePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource userRateBindingSource;
        private System.Windows.Forms.Label nameLabel1;
        private System.Windows.Forms.Label likesLabel1;
        private System.Windows.Forms.Label commentsLabel1;
        private System.Windows.Forms.BindingSource eventsBindingSource;
        private System.Windows.Forms.BindingSource groupsBindingSource;
        private System.Windows.Forms.ListBox nameListBox;
        private System.Windows.Forms.BindingSource pagesBindingSource;
        private System.Windows.Forms.ListBox nameListBox1;
        private System.Windows.Forms.ListBox nameListBox2;
        private System.Windows.Forms.PictureBox imageLargePictureBox;
    }
}