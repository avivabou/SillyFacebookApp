namespace FacebookApp.Forms
{
    public partial class FindMatchForm
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
            this.lblRemoveAFriend = new System.Windows.Forms.Label();
            this.txtFriendToRemove = new System.Windows.Forms.TextBox();
            this.lblBirth = new System.Windows.Forms.Label();
            this.numericMinYear = new System.Windows.Forms.NumericUpDown();
            this.numericMaxYear = new System.Windows.Forms.NumericUpDown();
            this.lblBirthRangeSign = new System.Windows.Forms.Label();
            this.lblTopMatches = new System.Windows.Forms.Label();
            this.numericTopMatches = new System.Windows.Forms.NumericUpDown();
            this.btnFindMatches = new System.Windows.Forms.Button();
            this.fbUsersList = new FacebookTools.UI.FBUsersRateList();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTopMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRemoveAFriend
            // 
            this.lblRemoveAFriend.AutoSize = true;
            this.lblRemoveAFriend.Font = new System.Drawing.Font("Papyrus", 19.8F);
            this.lblRemoveAFriend.Location = new System.Drawing.Point(34, 9);
            this.lblRemoveAFriend.Name = "lblRemoveAFriend";
            this.lblRemoveAFriend.Size = new System.Drawing.Size(260, 52);
            this.lblRemoveAFriend.TabIndex = 1;
            this.lblRemoveAFriend.Text = "Remove a friend:";
            // 
            // txtFriendToRemove
            // 
            this.txtFriendToRemove.Font = new System.Drawing.Font("Papyrus", 19.8F);
            this.txtFriendToRemove.Location = new System.Drawing.Point(43, 66);
            this.txtFriendToRemove.Name = "txtFriendToRemove";
            this.txtFriendToRemove.Size = new System.Drawing.Size(256, 59);
            this.txtFriendToRemove.TabIndex = 2;
            this.txtFriendToRemove.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFriendToRemove_KeyPress);
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Font = new System.Drawing.Font("Papyrus", 19.8F);
            this.lblBirth.Location = new System.Drawing.Point(34, 166);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(268, 52);
            this.lblBirth.TabIndex = 1;
            this.lblBirth.Text = "Birth year range:";
            // 
            // numericMinYear
            // 
            this.numericMinYear.Font = new System.Drawing.Font("Papyrus", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMinYear.Location = new System.Drawing.Point(45, 223);
            this.numericMinYear.Maximum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericMinYear.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericMinYear.Name = "numericMinYear";
            this.numericMinYear.Size = new System.Drawing.Size(103, 55);
            this.numericMinYear.TabIndex = 3;
            this.numericMinYear.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericMinYear.ValueChanged += new System.EventHandler(this.numericMinMaxYear_ValueChanged);
            // 
            // numericMaxYear
            // 
            this.numericMaxYear.Font = new System.Drawing.Font("Papyrus", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMaxYear.Location = new System.Drawing.Point(198, 223);
            this.numericMaxYear.Maximum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericMaxYear.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericMaxYear.Name = "numericMaxYear";
            this.numericMaxYear.Size = new System.Drawing.Size(103, 55);
            this.numericMaxYear.TabIndex = 3;
            this.numericMaxYear.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numericMaxYear.ValueChanged += new System.EventHandler(this.numericMinMaxYear_ValueChanged);
            // 
            // lblBirthRangeSign
            // 
            this.lblBirthRangeSign.AutoSize = true;
            this.lblBirthRangeSign.Font = new System.Drawing.Font("Papyrus", 19.8F);
            this.lblBirthRangeSign.Location = new System.Drawing.Point(154, 220);
            this.lblBirthRangeSign.Name = "lblBirthRangeSign";
            this.lblBirthRangeSign.Size = new System.Drawing.Size(34, 52);
            this.lblBirthRangeSign.TabIndex = 1;
            this.lblBirthRangeSign.Text = "-";
            // 
            // lblTopMatches
            // 
            this.lblTopMatches.AutoSize = true;
            this.lblTopMatches.Font = new System.Drawing.Font("Papyrus", 19.8F);
            this.lblTopMatches.Location = new System.Drawing.Point(12, 329);
            this.lblTopMatches.Name = "lblTopMatches";
            this.lblTopMatches.Size = new System.Drawing.Size(308, 52);
            this.lblTopMatches.TabIndex = 1;
            this.lblTopMatches.Text = "Amount of matches:";
            // 
            // numericTopMatches
            // 
            this.numericTopMatches.Font = new System.Drawing.Font("Papyrus", 19.8F);
            this.numericTopMatches.Location = new System.Drawing.Point(117, 386);
            this.numericTopMatches.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericTopMatches.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericTopMatches.Name = "numericTopMatches";
            this.numericTopMatches.Size = new System.Drawing.Size(103, 59);
            this.numericTopMatches.TabIndex = 3;
            this.numericTopMatches.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnFindMatches
            // 
            this.btnFindMatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(97)))), ((int)(((byte)(168)))));
            this.btnFindMatches.Font = new System.Drawing.Font("Papyrus", 19.8F);
            this.btnFindMatches.ForeColor = System.Drawing.Color.White;
            this.btnFindMatches.Location = new System.Drawing.Point(12, 473);
            this.btnFindMatches.Name = "btnFindMatches";
            this.btnFindMatches.Size = new System.Drawing.Size(314, 62);
            this.btnFindMatches.TabIndex = 4;
            this.btnFindMatches.Text = "Find Matches!";
            this.btnFindMatches.UseVisualStyleBackColor = false;
            this.btnFindMatches.Click += new System.EventHandler(this.btnFindMatches_Click);
            // 
            // fbUsersList
            // 
            this.fbUsersList.Location = new System.Drawing.Point(353, 12);
            this.fbUsersList.Name = "fbUsersList";
            this.fbUsersList.Size = new System.Drawing.Size(320, 525);
            this.fbUsersList.TabIndex = 0;
            // 
            // FindMatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(682, 553);
            this.Controls.Add(this.btnFindMatches);
            this.Controls.Add(this.numericMaxYear);
            this.Controls.Add(this.numericTopMatches);
            this.Controls.Add(this.numericMinYear);
            this.Controls.Add(this.txtFriendToRemove);
            this.Controls.Add(this.lblBirthRangeSign);
            this.Controls.Add(this.lblTopMatches);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.lblRemoveAFriend);
            this.Controls.Add(this.fbUsersList);
            this.MaximizeBox = false;
            this.Name = "FindMatchForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FindMatchForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericMinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTopMatches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRemoveAFriend;
        private System.Windows.Forms.TextBox txtFriendToRemove;
        private System.Windows.Forms.Label lblBirth;
        private System.Windows.Forms.NumericUpDown numericMinYear;
        private System.Windows.Forms.NumericUpDown numericMaxYear;
        private System.Windows.Forms.Label lblBirthRangeSign;
        private System.Windows.Forms.Label lblTopMatches;
        private System.Windows.Forms.NumericUpDown numericTopMatches;
        private System.Windows.Forms.Button btnFindMatches;
        private FacebookTools.UI.FBUsersRateList fbUsersList;
    }
}