using System;
using System.Windows.Forms;
using FacebookWrapper;

namespace FacebookApp.Forms
{
	public partial class formLogIn : Form
	{
		/// <summary>
		/// Login form constructor.
		/// </summary>
		public formLogIn()
		{
			InitializeComponent();
			FacebookService.s_CollectionLimit = 200;
		}

		/// <summary>
		/// Log in if not connected, otherwise log out.
		/// </summary>
		/// <param name="i_Sender">Sender.</param>
		/// <param name="i_EventArgs">Event args.</param>
		private void btnLogIn_Click(object i_Sender, EventArgs i_EventArgs)
		{
			if (!UserManager.IsLoggedIn)
            {
				logIn();
			}
			else
            {
				UserManager.LogOut();
				this.Close();
			}
		}

		/// <summary>
		/// Try to connect facebook, than release the feature buttons.
		/// </summary>
		private void logIn()
		{
			UserManager.LogIn();
			picProfilePicture.LoadAsync(UserManager.UserProfilePictureURL);
			lblUserName.Text = UserManager.UserFirstName;
			lblUserName.Visible = true;
			btnFindMatch.Enabled = true;
			btnFunniestPost.Enabled = true;
			btnLogIn.Text = "Log out!";
		}

		/// <summary>
		/// Open 'Find Match' feature.
		/// </summary>
		/// <param name="i_Sender">Sender.</param>
		/// <param name="i_EventArgs">Event args.</param>
		private void btnFindMatch_Click(object i_Sender, EventArgs i_EventArgs)
        {
			FindMatchForm findMatchForm = new FindMatchForm();
			findMatchForm.ShowDialog();
        }

		/// <summary>
		/// Open 'Funniest post' feature.
		/// </summary>
		/// <param name="i_Sender">Sender.</param>
		/// <param name="i_EventArgs">Event args.</param>
		private void btnFunniestPost_Click(object i_Sender, EventArgs i_EventArgs)
        {
			FunniestPostForm funniestPostForm = new FunniestPostForm();
			funniestPostForm.ShowDialog();
        }
    }
}