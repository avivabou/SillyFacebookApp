using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using FacebookTools;

namespace FacebookApp
{
	internal static class UserManager
	{
		private static readonly object sr_allPostsLocker = new object();
		private static readonly object sr_albumsLocker = new object();
		private static readonly object sr_postsLocker = new object();
		private static readonly object sr_pagesLocker = new object();
		private static readonly object sr_eventsLocker = new object();
		private static readonly object sr_groupsLocker = new object();
		private static List<PostInformation> s_allPosts = new List<PostInformation>();
		private static List<PostedItem> s_albums = new List<PostedItem>();
		private static List<PostedItem> s_posts = new List<PostedItem>();
		private static List<Page> s_pages = new List<Page>();
		private static List<Event> s_events = new List<Event>();
		private static List<Group> s_groups = new List<Group>();
		private static User s_user = null;
		private static bool s_firstInitialize = true;

		public static bool IsLoggedIn { get; private set; } = false;

		public static string UserFirstName
		{
			get
			{
				if (!IsLoggedIn)
				{
					noLoggedInUserException();
				}

				return s_user.FirstName;
			}
		}

		public static string UserProfilePictureURL
		{
			get
			{
				if (!IsLoggedIn)
				{
					noLoggedInUserException();
				}

				return s_user.PictureLargeURL;
			}
		}

		public static List<User> FriendsList
		{
			get
			{
				if (s_user == null)
				{
					noLoggedInUserException();
				}

				return new List<User>(s_user.Friends);
			}
		}

		public static List<PostInformation> AllPosts
		{
			get
			{
				if (!IsLoggedIn)
                {
					noLoggedInUserException();
                }

				lock(sr_allPostsLocker)
                {
					return new List<PostInformation>(s_allPosts);
                }
			}
		}

		public static List<PostedItem> Albums 
		{
			get
			{
				if (!IsLoggedIn)
				{
					noLoggedInUserException();
				}

				lock (sr_albumsLocker)
				{
					return new List<PostedItem>(s_albums);
				}
			}
		}

		public static List<PostedItem> Posts
        {
			get
			{
				if (!IsLoggedIn)
				{
					noLoggedInUserException();
				}

				lock (sr_postsLocker)
				{
					return new List<PostedItem>(s_posts);
				}
			}
		}

		public static List<Page> LikedPages
        {
			get
			{
				if (!IsLoggedIn)
				{
					noLoggedInUserException();
				}

				lock (sr_pagesLocker)
				{
					return new List<Page>(s_pages);
				}
			}
		}

		public static List<Event> Events
        {
			get
			{
				if (!IsLoggedIn)
				{
					noLoggedInUserException();
				}

				lock (sr_eventsLocker)
				{
					return new List<Event>(s_events);
				}
			}
		}

		public static List<Group> Groups
        {
			get
			{
				if (!IsLoggedIn)
				{
					noLoggedInUserException();
				}

				lock (sr_groupsLocker)
				{
					return new List<Group>(s_groups);
				}
			}
		}

		/// <summary>
		/// Log in to facebook and import the loged in user data.
		/// </summary>
		public static void LogIn()
		{
			if (s_firstInitialize)
			{
				FacebookService.s_CollectionLimit = 200;
				s_firstInitialize = false;
			}

			LoginResult loginResult = null;
			/// https://developers.facebook.com/docs/facebook-login/permissions#reference
			if (loginResult == null)
			{
				loginResult = FacebookService.Login(
					"196482978633067",
					"pages_show_list",
					"pages_read_engagement",
					"user_posts",
					"user_photos",
					"user_likes",
					"user_gender",
					"user_friends",
					"user_birthday");
			}

			if (!string.IsNullOrEmpty(loginResult.AccessToken))
			{
				s_user = loginResult.LoggedInUser;
				IsLoggedIn = true;
				new Thread(loadAllUserData).Start();
			}
			else
			{
				throw new ApplicationException(loginResult.ErrorMessage);
			}
		}

		/// <summary>
		/// Log out from facebook and clear the data.
		/// </summary>
		public static void LogOut()
		{
			Action logOutAction = () => { s_user = null; };
			IsLoggedIn = false;
			s_allPosts = new List<PostInformation>();
			s_albums = new List<PostedItem>();
			s_posts = new List<PostedItem>();
			s_pages = new List<Page>();
			s_events = new List<Event>();
			s_groups = new List<Group>();
			FacebookService.Logout(logOutAction);
		}

		/// <summary>
		/// Check if both current user and potential user interest each other.
		/// </summary>
		/// <param name="i_Potential">Potential user.</param>
		/// <returns>True if both interest each other, otherwise false.</returns>
		public static bool CheckInterest(User i_Potential)
		{
			return checkInterest(s_user, i_Potential) && checkInterest(i_Potential, s_user);
		}

		/// <summary>
		/// Check if potential user intersted the user gender.
		/// </summary>
		/// <param name="i_User">The user it gender will be checked if contained at the potential gender list.</param>
		/// <param name="i_Potential">The potential user that can be intersted user gender.</param>
		/// <returns>True if the potential interest user, otherwise false.</returns>
		private static bool checkInterest(User i_User, User i_Potential)
		{
			bool isInterested = false;
			if (i_Potential.InterestedIn != null)
			{
				foreach (User.eGender interestedIn in i_Potential.InterestedIn)
				{
					if (i_User.Gender.Equals(interestedIn))
					{
						isInterested = true;
						break;
					}
				}
			}

			return isInterested;
		}

		/// <summary>
		/// Throw exception that there is no loged in user.
		/// </summary>
		private static void noLoggedInUserException()
		{
			throw new ArgumentNullException("Can't provide this information for null, there is no loged in user.");
		}

		/// <summary>
		/// Load all user's data.
		/// </summary>
		private static void loadAllUserData()
		{
			fetchUserData();
			List<PostedItem> postedItems = s_user.Statuses.ToList<PostedItem>();
			addPostedItemCollection(postedItems);
			postedItems = s_user.Videos.ToList<PostedItem>();
			addPostedItemCollection(postedItems);
		}

		/// <summary>
		/// Fetch async all user's data.
		/// </summary>
		private static void fetchUserData()
        {
			new Thread(fetchAlbums).Start();
			new Thread(fetchPosts).Start();
			new Thread(fetchLikedPages).Start();
			new Thread(fetchEvents).Start();
			new Thread(fetchGroups).Start();
		}

		/// <summary>
		/// Fetch user's albums.
		/// </summary>
		private static void fetchAlbums()
        {
			lock (sr_albumsLocker)
			{
				foreach (Album album in s_user.Albums)
				{
					Albums.Add(album);
				}

				addPicturesAsPostedItems();
			}
		}

		/// <summary>
		/// Fetch user's posts.
		/// </summary>
		private static void fetchPosts()
        {
			lock (sr_postsLocker)
			{
				foreach (Post post in s_user.Posts)
				{
					Posts.Add(post);
					lock (sr_allPostsLocker)
					{
						AllPosts.Add(new PostInformation(post));
					}
				}
			}
		}

		/// <summary>
		/// Fetch user's liked pages.
		/// </summary>
		private static void fetchLikedPages()
		{
			lock (sr_pagesLocker)
			{
				foreach (Page page in s_user.LikedPages)
				{
					LikedPages.Add(page);
				}
			}
		}

		/// <summary>
		/// Fetch user's events.
		/// </summary>
		private static void fetchEvents()
		{
			lock (sr_eventsLocker)
			{
				foreach (Event e in s_user.Events)
				{
					Events.Add(e);
				}
			}
		}

		/// <summary>
		/// Fetch user's groups.
		/// </summary>
		private static void fetchGroups()
		{
			lock (sr_groupsLocker)
			{
				foreach (Group group in s_user.Groups)
				{
					Groups.Add(group);
				}
			}
		}

		/// <summary>
		/// Add a collection of posts to all posts list.
		/// </summary>
		/// <param name="i_PostedItems">Posted items collection.</param>
		private static void addPostedItemCollection(ICollection<PostedItem> i_PostedItems)
		{
			foreach (PostedItem item in i_PostedItems)
			{
				lock (sr_allPostsLocker)
				{
					AllPosts.Add(new PostInformation(item));
				}
			}
		}

		/// <summary>
		/// Adding all pictures to all posts list.
		/// </summary>
		private static void addPicturesAsPostedItems()
		{
			foreach (Album album in Albums)
			{
				foreach (Photo photo in album.Photos)
				{
					lock (sr_allPostsLocker)
					{
						AllPosts.Add(new PostInformation(photo));
					}
				}
			}
		}
	}
 }
