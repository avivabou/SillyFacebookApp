using System;
using System.Drawing;
using System.Windows.Forms;
using FacebookTools;
using FacebookApp.LetsLoveLogic;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.Forms
{
    public partial class FindMatchForm : Form
    {
        private PotentialMatchManager m_matchManager;

        /// <summary>
        /// FindMatchForm constructor.
        /// </summary>
        /// <param name="i_user">Current program user.</param>
        public FindMatchForm()
        {
            m_matchManager = new PotentialMatchManager();
            InitializeComponent();
            numericMaxYear.Maximum = DateTime.Today.Year;
            numericMinYear.Maximum = DateTime.Today.Year;
            Size = new Size(280, Size.Height);
        }

        /// <summary>
        /// Calculating bets match when it button clicked.
        /// </summary>
        /// <param name="i_Sender">Sender.</param>
        /// <param name="i_EventArgs">Events args.</param>
        private void btnFindMatches_Click(object i_Sender, EventArgs i_EventArgs)
        {
            m_matchManager.FilterByAgeRange((int)numericMinYear.Value, (int)numericMaxYear.Value);
            UserRate[] users = m_matchManager.GetBestMatches((int) numericTopMatches.Value);
            fbUsersList.Users = users;
            Size = new Size(540, Size.Height);
        }

        /// <summary>
        /// Remove the given friend name from the list when pressed "ENTER" in the text box.
        /// </summary>
        /// <param name="i_Sender">Sender.</param>
        /// <param name="i_EventArgs">Events args.</param>
        private void txtFriendToRemove_KeyPress(object i_Sender, KeyPressEventArgs i_EventArgs)
        {
             if (i_EventArgs.KeyChar.Equals('\r'))
            {
                m_matchManager.FilterSpecificFriend(txtFriendToRemove.Text);
                txtFriendToRemove.Text = string.Empty;
            }
        }

        /// <summary>
        /// Bounding the min/max numeric values where min can't be bigger then max and vice verse.
        /// </summary>
        /// <param name="i_Sender">Sender.</param>
        /// <param name="i_EventArgs">Events args.</param>
        private void numericMinMaxYear_ValueChanged(object i_Sender, EventArgs i_EventArgs)
        {
            numericMinYear.Maximum = numericMaxYear.Value;
            numericMaxYear.Minimum = numericMinYear.Value;
        }
    }
}
