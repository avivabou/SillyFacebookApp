using System.Windows.Forms;
using System.Threading;
using FacebookApp.FunniestPostLogic;
using FacebookTools.UI;

namespace FacebookApp.Forms
{
    public partial class FunniestPostForm : Form
    {
        private FBPostsList m_FBPostedItemList = null;
        private FunnyPostAnalayzer m_funnyPostAnalayzer = null;

        /// <summary>
        /// FunniestPostForm constructor.
        /// Analyze the given user funniest posts and present them.
        /// </summary>
        /// <param name="i_User">Current program user.</param>
        public FunniestPostForm()
        {
            m_funnyPostAnalayzer = new FunnyPostAnalayzer();
            InitializeComponent();
        }

        /// <summary>
        /// Updating the list of funniest posts during the calculation.
        /// </summary>
        private void showCalculation()
        {
            while (m_funnyPostAnalayzer.IsAnalayzing)
            {
                if (m_FBPostedItemList == null)
                {
                    m_FBPostedItemList = new FBPostsList(m_funnyPostAnalayzer.FunniestPosts);
                    Controls.Add(m_FBPostedItemList);
                }
                else
                {
                    m_FBPostedItemList.Posts = m_funnyPostAnalayzer.FunniestPosts;
                }
            }
        }

        /// <summary>
        /// Start analyzing and showing the progress of the funniest posts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FunniestPostForm_Shown(object sender, System.EventArgs e)
        {
            new Thread(m_funnyPostAnalayzer.CalcFunniestPostedItem).Start();
            while (!m_funnyPostAnalayzer.IsAnalayzing) 
            { 
            }
            
            new Thread(showCalculation).Start();
        }
    }
}
