using System;
using FacebookWrapper.ObjectModel;

namespace FacebookTools.UI
{
    public class FBBoxProxy : FBBox
    {
        private FBBox m_instance = null;

        internal override int Index 
        { 
            get
            {
                return m_instance.Index;
            }

            set
            {
                m_instance.Index = value;
            }
        }

        /// <summary>
        /// When mouse clicked on the box.
        /// </summary>
        public override event Action<int> MouseClicked;

        /// <summary>
        /// FBBoxProxy constructor using PostInformation.
        /// </summary>
        /// <param name="i_PostInformation">Post information.</param>
        public FBBoxProxy(PostInformation i_PostInformation)
        {
            string text2 = i_PostInformation.Rate != 0 ? string.Format("Rate: {0}", i_PostInformation.Rate) : string.Empty;
            m_instance = GenerateFBBox(i_PostInformation.m_Message, text2, i_PostInformation.m_ImageURL);
            m_instance.MouseClicked += m_instance_MouseClicked;
        }

        /// <summary>
        /// FBBoxProxy constructor using User.
        /// </summary>
        /// <param name="i_User">User</param>
        public FBBoxProxy(User i_User)
        {
            if (i_User != null)
            {
                string text1 = string.Format("{0} {1}", i_User.FirstName, i_User.LastName);
                string text2 = string.Format("Birthday: {0}", i_User.Birthday);
                m_instance = GenerateFBBox(text1, text2, i_User.PictureLargeURL);
            }
            else
            {
                m_instance = GenerateFBBox(null, null);
            }

            m_instance.MouseClicked += m_instance_MouseClicked;
        }

        /// <summary>
        /// Apply box action when it clicked.
        /// </summary>
        /// <param name="i_Index">Box index.</param>
        private void m_instance_MouseClicked(int i_Index)
        {
            if (MouseClicked != null)
            {
                MouseClicked.Invoke(i_Index);
            }
        }

        /// <summary>
        /// Generate FBBox.
        /// </summary>
        /// <param name="i_Text1">Label1.</param>
        /// <param name="i_Text2">Label2.</param>
        /// <param name="i_ImageURL">Image.</param>
        /// <returns>FBBox that matches the given data.</returns>
        public static FBBox GenerateFBBox(string i_Text1, string i_Text2, string i_ImageURL = null)
        {
            FBBox Box;
            if (i_ImageURL == null)
            {
                Box = new FBTextBox(i_Text1, i_Text2);
            }
            else
            {
                Box = new FBPictureTextBox(i_Text1, i_Text2, i_ImageURL);
            }

            return Box;
        }

        /// <summary>
        /// Throws NotImplementedException.
        /// </summary>
        protected override void fitLabels()
        {
            /// Will never be called since the constructor of the proxy doesn't use the base constructor,
            /// where there is the only call to this method.
            throw new NotImplementedException();
        }
    }
}