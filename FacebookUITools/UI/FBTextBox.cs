using System.Drawing;
using System.Windows.Forms;

namespace FacebookTools.UI
{
    public class FBTextBox : FBBox
    {
        /// <summary>
        /// Building the UI of the controller.
        /// </summary>
        internal FBTextBox(string i_Text1, string i_Text2)
            : base()
        {
            m_label1.Text = i_Text1;
            m_label2.Text = i_Text2;
        }

        /// <summary>
        /// Fit labels proportions.
        /// </summary>
        protected override void fitLabels()
        {
            m_label1.Location = new Point((int)(sr_WidthProportion * 0.05f), (int)(sr_HeightProportion * 0.05f));
            m_label1.Size = new Size((int)(sr_WidthProportion * 0.9f), (int)(sr_HeightProportion * 0.60f));
            m_label2.Location = new Point(m_label1.Location.X, (int)(sr_HeightProportion * 0.60f));
            m_label1.Size = new Size((int)(sr_WidthProportion * 0.9f), (int)(sr_HeightProportion * 0.30f));
        }
    }
}
