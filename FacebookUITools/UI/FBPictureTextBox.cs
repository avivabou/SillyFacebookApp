using System.Drawing;
using System.Windows.Forms;

namespace FacebookTools.UI
{
    public class FBPictureTextBox : FBBox
    {
        private PictureBox m_pictureBox;

        /// <summary>
        /// FBPictureTextBox constructor.
        /// </summary>
        /// <param name="i_Text1">Text in label1.</param>
        /// <param name="i_Text2">Text in label2.</param>
        /// <param name="i_ImageURL">Image URL.</param>
        internal FBPictureTextBox(string i_Text1, string i_Text2, string i_ImageURL)
            : base()
        {
            m_label1.Text = i_Text1;
            m_label2.Text = i_Text2;
            addImage(i_ImageURL);
        }

        /// <summary>
        /// Add picture box with the given Image.
        /// </summary>
        /// <param name="i_ImageURL">Image URL.</param>
        private void addImage(string i_ImageURL)
        {
            m_pictureBox = new PictureBox();
            m_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            m_pictureBox.Size = new Size(sr_imageSize, sr_imageSize);
            m_pictureBox.BackColor = Color.White;
            int pictureStart = sr_imageSize / 8;
            m_pictureBox.Location = new Point(pictureStart, pictureStart);
            Controls.Add(m_pictureBox);
            m_pictureBox.LoadAsync(i_ImageURL);
        }

        /// <summary>
        /// Fit labels proportions.
        /// </summary>
        protected override void fitLabels()
        {
            int pictureStart = sr_imageSize / 8;
            int labelStartX = (int)(sr_imageSize * 1.5f);
            m_label1.Location = new Point(labelStartX, pictureStart);
            m_label2.Location = new Point(labelStartX, (pictureStart + sr_imageSize) / 2);
        }
    }
}
