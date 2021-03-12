using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using FacebookTools;

namespace FacebookApp.LetsLoveLogic
{
    public class PotentialMatchManager
    {
        private List<User> m_potentialFriendsForMatch;
        private FriendsRate m_friendsRate;

        /// <summary>
        /// PotentialMatchManager constructor.
        /// </summary>
        /// <param name="i_User">The user to search his potential matches.</param>
        public PotentialMatchManager()
        {
            m_potentialFriendsForMatch = UserManager.FriendsList;
            m_friendsRate = new FriendsRate(m_potentialFriendsForMatch);
            m_friendsRate.FilterByGenderInterest = true;
        }

        /// <summary>
        /// Filter a friend by it name.
        /// </summary>
        /// <param name="i_UserName">User name to filter.</param>
        public void FilterSpecificFriend(string i_UserName)
        {
            m_friendsRate.FilterUserName(i_UserName);
        }

        /// <summary>
        /// Filter friends by years range.
        /// </summary>
        /// <param name="i_minBirthYear">Minimum year of birth.</param>
        /// <param name="i_maxBirthYear">Maximum year of birth.</param>
        public void FilterByAgeRange(int i_minBirthYear, int i_maxBirthYear)
        {
            m_friendsRate.FilterBirthyear(i_minBirthYear, i_maxBirthYear);
        }

        /// <summary>
        /// Get best matches.
        /// </summary>
        /// <param name="i_Top">Amount of the highest matches to return.</param>
        /// <returns>Array of the best matches</returns>
        public UserRate[] GetBestMatches(int i_Top = 5)
        {
            UserRate[] userRates = new UserRate[i_Top];
            int index = 0;
            foreach (UserRate rate in m_friendsRate)
            {
                if (index >= i_Top)
                {
                    break;
                }

                userRates[index] = rate;
                index++;
            }

            return userRates;
        }
    }
}