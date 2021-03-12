using System.Collections.Generic;
using System.Linq;
using System.Collections;
using FacebookWrapper.ObjectModel;
using FacebookTools;

namespace FacebookApp.LetsLoveLogic
{
    public class FriendsRate : IEnumerable<UserRate>
    {
        private Dictionary<User, UserRate> m_friendsRate = null;
        private HashSet<string> m_filteredNames = new HashSet<string>();
        private int m_filterMinYear = 0;
        private int m_filterMaxYear = int.MaxValue;

        public bool FilterByGenderInterest { get; set; } = true;

        /// <summary>
        /// FriendsRate constructor.
        /// </summary>
        /// <param name="i_user">The searcher user.</param>
        /// <param name="i_Friends">User friends list.</param>
        public FriendsRate(List<User> i_Friends)
        {
            m_friendsRate = new Dictionary<User, UserRate>();
            foreach (User friend in i_Friends)
            {
                m_friendsRate[friend] = new UserRate { Likes = 0, Comments = 0, TotalCommon = 0, User = friend };
            }

            buildFriendsRate();
        }

        /// <summary>
        /// Itterator of UserRate.
        /// </summary>
        /// <returns>Current UserRate itteration.</returns>
        public IEnumerator<UserRate> GetEnumerator()
        {
            List<UserRate> friendsOrderedRate = m_friendsRate.Values.ToList();
            friendsOrderedRate.Sort(UserRate.Compare);
            for (int i = 0; i < friendsOrderedRate.Count; i++)
            {
                /// Filters
                User current = friendsOrderedRate[i].User;
                if (FilterByGenderInterest && !UserManager.CheckInterest(current))
                {
                    continue;
                }

                if (m_filteredNames.Contains(current.UserName))
                {
                    continue;
                }

                int birthyear = getBirthYear(current);
                if (birthyear < m_filterMinYear || birthyear > m_filterMaxYear)
                {
                    continue;
                }

                /// Next best unfilttered
                yield return friendsOrderedRate[i];
            }
        }

        /// <summary>
        /// Itterator of UserRate.
        /// </summary>
        /// <returns>Current UserRate itteration.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Filter user names for itterator.
        /// </summary>
        /// <param name="i_UserName">User name to filter.</param>
        public void FilterUserName(string i_UserName)
        {
            m_filteredNames.Add(i_UserName);
        }

        /// <summary>
        /// Filter birth year for itterator.
        /// </summary>
        /// <param name="i_MinYear">Minimum birth year.</param>
        /// <param name="i_MaxYear">Maximum birth year.</param>
        public void FilterBirthyear(int i_MinYear, int i_MaxYear)
        {
            m_filterMinYear = i_MinYear;
            m_filterMaxYear = i_MaxYear;
        }

        /// <summary>
        /// Clear itterator filters.
        /// </summary>
        public void ClearAllFilters()
        {
            m_filteredNames.Clear();
            m_filterMinYear = 0;
            m_filterMaxYear = int.MaxValue;
            FilterByGenderInterest = false;
        }

        /// <summary>
        /// Investigate facebook the user's friends activity and rate them.
        /// </summary>
        private void buildFriendsRate()
        {
            ratePosts(UserManager.Posts);
            ratePosts(UserManager.Albums);
            ratePhotos();
            rateEvents();
            rateGroups();
            ratePages();
        }

        /// <summary>
        /// Rate friends whose liked the same pages as the user.
        /// </summary>
        private void ratePages()
        {
            foreach (Page page in UserManager.LikedPages)
            {
                foreach (User friend in m_friendsRate.Keys)
                {
                    if (friend.LikedPages.Contains(page))
                    {
                        if (m_friendsRate[friend].Pages == null)
                        {
                            m_friendsRate[friend].Pages = new List<Page>();
                        }

                        m_friendsRate[friend].Pages.Add(page);
                        m_friendsRate[friend].TotalCommon++;
                    }
                }
            }
        }

        /// <summary>
        /// Rate friends whose join the same events as the user.
        /// </summary>
        private void rateEvents()
        {
            foreach (Event userEvent in UserManager.Events)
            {
                List<User> friendsInEvent = (List<User>)userEvent.AttendingUsers.Intersect(m_friendsRate.Keys);
                foreach (User friend in friendsInEvent)
                {
                    if (m_friendsRate[friend].Events == null)
                    {
                        m_friendsRate[friend].Events = new List<Event>();
                    }

                    m_friendsRate[friend].Events.Add(userEvent);
                    m_friendsRate[friend].TotalCommon++;
                }
            }
        }

        /// <summary>
        /// Rate friends whose join the same groups as the user.
        /// </summary>
        private void rateGroups()
        {
            foreach (Group group in UserManager.Groups)
            {
                List<User> friendsInGroup = (List<User>)group.Members.Intersect(m_friendsRate.Keys);
                foreach (User friend in friendsInGroup)
                {
                    if (m_friendsRate[friend].Groups == null)
                    {
                        m_friendsRate[friend].Groups = new List<Group>();
                    }

                    m_friendsRate[friend].Groups.Add(group);
                    m_friendsRate[friend].TotalCommon++;
                }
            }
        }

        /// <summary>
        /// Rate friends activity on user photos.
        /// </summary>
        private void ratePhotos()
        {
            foreach (Album album in UserManager.Albums)
            {
                ratePosts(album.Photos.ToList<PostedItem>());
            }
        }

        /// <summary>
        /// Rate friends activity on user posts.
        /// </summary>
        /// <param name="i_postedItems">Posts collection.</param>
        private void ratePosts(ICollection<PostedItem> i_postedItems)
        {
            foreach (PostedItem post in i_postedItems)
            {
                ratePost(post);
            }
        }

        /// <summary>
        /// Rate friend who's like\comment on user post.
        /// </summary>
        /// <param name="i_postedItem">A post to check the activity on.</param>
        private void ratePost(PostedItem i_postedItem)
        {
            foreach (User user in i_postedItem.LikedBy)
            {
                if (m_friendsRate.ContainsKey(user))
                {
                    UserRate update = m_friendsRate[user];
                    update.Likes++;
                    update.TotalCommon++;
                    m_friendsRate[user] = update;
                }
            }

            foreach (Comment comment in i_postedItem.Comments)
            {
                if (m_friendsRate.ContainsKey(comment.From))
                {
                    UserRate update = m_friendsRate[comment.From];
                    update.Comments++;
                    update.TotalCommon++;
                    m_friendsRate[comment.From] = update;
                }
            }
        }

        /// <summary>
        /// Get birth year of the user as integer.
        /// </summary>
        /// <param name="i_user">The user.</param>
        /// <returns>Birth year of the user.</returns>
        private int getBirthYear(User i_user)
        {
            return int.Parse(i_user.Birthday.Substring(i_user.Birthday.Length - 4));
        }
    }
}