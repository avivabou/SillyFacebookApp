using System.Windows.Forms;

namespace FacebookTools.UI
{
    public partial class UserRateViewForm : Form
    {
        public UserRateViewForm(UserRate userRate)
        {
            InitializeComponent();
            userRateBindingSource.DataSource = userRate;
            eventsBindingSource.DataSource = userRate.Events;
            groupsBindingSource.DataSource = userRate.Groups;
            pagesBindingSource.DataSource = userRate.Pages;
        }
    }
}
