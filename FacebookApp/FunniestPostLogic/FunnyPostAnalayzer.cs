using System.Collections;
using System.Collections.Generic;
using System.Text;
using FacebookTools;

namespace FacebookApp.FunniestPostLogic
{
    public class FunnyPostAnalayzer
    {
        private static readonly int sr_showTop = 5;
        private readonly object m_arrayLocker = new object();
        private List<PostInformation> m_allPosts;
        private PostInformation[] m_funniestPosts;
        private int m_smallestTopRate = 0;

        public PostInformation[] FunniestPosts 
        { 
            get
            {
                lock (m_arrayLocker)
                {
                    return (PostInformation[])m_funniestPosts.Clone();
                }
            }
        }

        public bool IsAnalayzing { get; private set; } = false;

        /// <summary>
        /// FunnyPostAnalayzer constructor.
        /// </summary>
        public FunnyPostAnalayzer()
        {
            m_allPosts = UserManager.AllPosts;
            m_funniestPosts = new PostInformation[sr_showTop];
            m_smallestTopRate = m_funniestPosts[0].Rate;
            for (int i = sr_showTop; i < sr_showTop * 2; i++)
            {
                m_funniestPosts[i] = m_allPosts[i];
            }
        }

        /// <summary>
        /// Rate the funniest posted item.
        /// </summary>
        /// <param name="i_Top">Top funny posts to return.</param>
        /// <returns>Array of the top funniest posts.</returns>
        public void CalcFunniestPostedItem()
        {
            IsAnalayzing = true;
            ratePostedItems();
            m_allPosts.Clear();
            IsAnalayzing = false;
        }

        /// <summary>
        /// Rate how funny is the post.
        /// </summary>
        private void ratePostedItems()
        {
            for (int i = 0; i < m_allPosts.Count; i++)
            {
                string[] comments = m_allPosts[i].Comments;
                foreach (string comment in comments)
                {
                    m_allPosts[i].Rate += getLaughedLength(comment);
                }

                if (m_allPosts[i].Rate > m_smallestTopRate)
                {
                    lock (m_arrayLocker)
                    {
                        updateFunniestPosts(m_allPosts[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Return how long was the laughing. (every חחח is 1 point)
        /// </summary>
        /// <param name="i_Comment">The comment.</param>
        /// <param name="i_Score">Start value of calculating score.</param>
        /// <returns>The amount of times that "חחח" apeared.</returns>
        private int getLaughedLength(string i_Comment, int i_Score = 0)
        {
            Encoding hebrewEncoding = Encoding.GetEncoding("Windows-1255");
            byte[] hebrewLaugh = hebrewEncoding.GetBytes("חחח");
            string laugh = hebrewEncoding.GetString(hebrewLaugh);
            if (i_Comment.Contains(laugh))
            {
                i_Comment = i_Comment.Substring(i_Comment.IndexOf(laugh) + 3);
                i_Score = getLaughedLength(i_Comment, i_Score + 1);
            }

            return i_Score;
        }

        /// <summary>
        /// Update the currently funniest posts.
        /// </summary>
        /// <param name="i_PostInformation">New top funny post.</param>
        private void updateFunniestPosts(PostInformation i_PostInformation)
        {
            for (int i = sr_showTop - 1; i >= 0; i--)
            {
                if (m_funniestPosts[i].Rate <= i_PostInformation.Rate)
                {
                    if (i == 0)
                    {
                        m_funniestPosts[i] = i_PostInformation;
                    }
                    else
                    {
                        m_funniestPosts[i] = m_funniestPosts[i - 1];
                    }
                }
                else if (i < sr_showTop - 1)
                {
                    m_funniestPosts[i + 1] = i_PostInformation;
                }
                else
                {
                    break;
                }
            }

            m_smallestTopRate = m_funniestPosts[sr_showTop - 1].Rate;
        }
    }
}
