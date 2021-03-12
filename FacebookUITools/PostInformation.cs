using System.Collections.Generic;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace FacebookTools
{
    public class PostInformation
    {
        internal string m_ImageURL = null;
        internal string m_Message;
        private string[] m_comments;

        public int Rate { get; set; }

        public bool ContainsPicture
        {
            get
            {
                return m_ImageURL != null;
            }
        }

        public string[] Comments
        {
            get
            {
                return m_comments;
            }
        }

        /// <summary>
        /// PostInformation constructor.
        /// </summary>
        /// <param name="i_PostedItem">Any posted item.</param>
        public PostInformation(PostedItem i_PostedItem)
        {
            m_Message = i_PostedItem.Message;
            getPostImageURL(i_PostedItem);
            importComments(i_PostedItem.Comments.ToList());
        }

        /// <summary>
        /// If post is picture or video - import it imageURL.
        /// </summary>
        /// <param name="i_PostedItem">The post.</param>
        private void getPostImageURL(PostedItem i_PostedItem)
        {
            if (i_PostedItem is Video)
            {
                m_ImageURL = (i_PostedItem as Video).PictureURL;
            }
            else if (i_PostedItem is Photo)
            {
                m_ImageURL = (i_PostedItem as Photo).PictureNormalURL;
            }
        }

        /// <summary>
        /// Keeps the comments as strings.
        /// </summary>
        /// <param name="i_Comments">The comments.</param>
        private void importComments(List<Comment> i_Comments)
        {
            m_comments = new string[i_Comments.Count];
            for (int i = 0; i < i_Comments.Count; i++)
            {
                m_comments[i] = i_Comments[i].Message;
            }
        }

        /// <summary>
        /// Compare between posts rate.
        /// </summary>
        /// <param name="i_Post1">Post1</param>
        /// <param name="i_Post2">Post2</param>
        /// <returns>Return 1 if post1 rate is lower then post2, 0 if equals, -1 otherwise.</returns>
        public static int Compare(PostInformation i_Post1, PostInformation i_Post2)
        {
            int comparsion = 0;
            if (i_Post1.Rate > i_Post2.Rate)
            {
                comparsion = -1;
            }
            else if (i_Post1.Rate < i_Post2.Rate)
            {
                comparsion = 1;
            }

            return comparsion;
        }
    }
}
