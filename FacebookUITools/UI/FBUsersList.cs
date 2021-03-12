using FacebookWrapper.ObjectModel;

namespace FacebookTools.UI
{
    public class FBUsersRateList : FBListBox
    {
        private UserRate[] m_usersList;

        public UserRate[] Users 
        { 
            set
            {
                m_usersList = value;
                usersArrayChanged();
            }
        }

        /// <summary>
        /// Facebook UserList constructor.
        /// </summary>
        public FBUsersRateList()
            : base()
        {
        }

        /// <summary>
        /// Show the reactions of the user at the chosen box.
        /// </summary>
        /// <param name="i_BoxIndex">Box index.</param>
        private void showUserInformation(int i_BoxIndex)
        {
            UserRate chosen = m_usersList[m_scrollBar.Value + i_BoxIndex];
            string title = string.Format(
                                         "{0} {1}: (Total reactions: {2})", 
                                         chosen.User.FirstName,
                                         chosen.User.LastName,
                                         chosen.TotalCommon);
            UserRateViewForm viewForm = new UserRateViewForm(chosen);
            viewForm.Text = title;
            viewForm.ShowDialog();
        }

        /// <summary>
        /// Update the list if the users array changed.
        /// </summary>
        private void usersArrayChanged()
        {
            m_scrollBar.Maximum = m_usersList.Length - sr_BoxesInList;
            m_scrollBar.Value = 0;
            M_scrollBar_ValueChanged(null, null);
        }

        /// <summary>
        /// Synching the review sub-list with the scroll bar.
        /// </summary>
        /// <param name="i_IndexInList">The index that the scroll bar is on.</param>
        /// <param name="i_BoxIndex">The index of the box the user should be placed.</param>
        protected override void updateItem(int i_IndexInList, int i_BoxIndex)
        {
            User user = null;
            if (m_usersList != null)
            {
                user = m_usersList[i_IndexInList].User;
            }
            
            FBBoxProxy fBBox = new FBBoxProxy(user);
            m_boxes[i_BoxIndex] = fBBox;
        }

        /// <summary>
        /// Show user information when mouse click on some box.
        /// </summary>
        /// <param name="i_Index">Selected box.</param>
        protected override void itemSelected(int i_Index)
        {
            showUserInformation(i_Index);
        }
    }
}
