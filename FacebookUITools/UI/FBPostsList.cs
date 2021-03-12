using System.Drawing;
using System.Windows;

namespace FacebookTools.UI
{
    public class FBPostsList : FBListBox
    {
        private PostInformation[] m_posts;

        public PostInformation[] Posts
        {
            set
            {
                m_posts = value;
                m_scrollBar.Maximum = m_posts.Length;
                m_scrollBar.Value = 0;
                for (int i = 0; i < sr_BoxesInList; i++)
                {
                    updateItem(i, i);
                }
            }
        }

        /// <summary>
        /// Facebook PostList constructor.
        /// </summary>
        /// <param name="i_PostedItems">Post items.</param>
        public FBPostsList(PostInformation[] i_Posts)
            : base()
        {
            m_posts = i_Posts;
        }

        /// <summary>
        /// Put given post in given box.
        /// </summary>
        /// <param name="i_IndexInList">The value that the scroll bar points on.</param>
        /// <param name="i_BoxIndex">The index of the box that will hold the post.</param>
        protected override void updateItem(int i_IndexInList, int i_BoxIndex)
        {
            PostInformation currentPost = m_posts[i_IndexInList];
            FBBoxProxy fBBox = new FBBoxProxy(currentPost);
            m_boxes[i_BoxIndex] = fBBox;
        }

        /// <summary>
        /// Client clicked on item.
        /// </summary>
        /// <param name="i_Index">Item's index.</param>
        protected override void itemSelected(int i_Index)
        {
            MessageBox.Show(m_posts[i_Index].m_Message);
        }
    }
}
