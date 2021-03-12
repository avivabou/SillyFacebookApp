using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace FacebookTools
{
    public class UserRate
    {
        public User User { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }

        public List<Event> Events { get; set; }

        public List<Group> Groups { get; set; }

        public List<Page> Pages { get; set; }

        public int TotalCommon { get; set; }

        /// <summary>
        /// Comparing betweein 2 UserRates.
        /// </summary>
        /// <param name="i_User1">User1</param>
        /// <param name="i_User2">User2</param>
        /// <returns>Return 1 if i_user1.Rate less then i_user2.Rate, 0 if equals and -1 otherwise.</returns>
        public static int Compare(UserRate i_User1, UserRate i_User2)
        {
            int result = 0;
            if (i_User1.TotalCommon > i_User2.TotalCommon)
            {
                result = -1;                        ///bigger should be sooner.
            }
            else if (i_User1.TotalCommon < i_User2.TotalCommon)
            {
                result = 1;                         ///smaller should be later.
            }

            return result;
        }
    }
}