using System;
using System.Drawing;
using System.Windows.Forms;

namespace FacebookTools.UI
{
    public abstract class FBBox : Control
    {
        internal static readonly int sr_WidthProportion = sr_imageSize * 4;
        internal static readonly int sr_HeightProportion = (int)(1.25f * sr_imageSize);
        protected static readonly int sr_imageSize = 80;
        protected static readonly Color sr_fbNaturalColor = Color.FromArgb(66, 103, 178);
        protected static readonly Color sr_fbMouseHoverColor = Color.FromArgb(156, 178, 206);
        protected Label m_label1, m_label2;

        internal virtual int Index { get; set; } = 0;

        /// <summary>
        /// When mouse clicked on the box.
        /// </summary>
        public virtual event Action<int> MouseClicked;

        /// <summary>
        /// FBBox constructor.
        /// </summary>
        protected FBBox()
            : base(string.Empty, 0, 0, sr_WidthProportion, sr_HeightProportion)
        {
            BackColor = sr_fbNaturalColor;
            setLabels();
            MouseEnter += FBBox_MouseEnter;
            MouseLeave += FBBox_MouseLeave;
            MouseClick += FBBox_MouseClick;
        }

        /// <summary>
        /// Apply box action when it clicked.
        /// </summary>
        /// <param name="i_Sender">Sender.</param>
        /// <param name="i_EventArgs">Mouse event args.</param>
        internal virtual void FBBox_MouseClick(object i_Sender, MouseEventArgs i_EventArgs)
        {
            if (MouseClicked != null)
            {
                MouseClicked.Invoke(Index);
            }
        }

        /// <summary>
        /// Restore the controller visible when mouse is leaving.
        /// </summary>
        /// <param name="i_Sender"></param>
        /// <param name="i_Args"></param>
        internal virtual void FBBox_MouseLeave(object i_Sender, EventArgs i_Args)
        {
            BackColor = sr_fbNaturalColor;
            Cursor = Cursors.Default;
        }

        /// <summary>
        /// Mark the controller when mouse is on it.
        /// </summary>
        /// <param name="i_Sender"></param>
        /// <param name="i_Args"></param>
        internal virtual void FBBox_MouseEnter(object i_Sender, EventArgs i_Args)
        {
            BackColor = sr_fbMouseHoverColor;
            Cursor = Cursors.Hand;
        }
      
        /// <summary>
        /// Adding labels to the box.
        /// </summary>
        private void setLabels()
        {
            m_label1 = new Label();
            m_label2 = new Label();
            m_label1.AutoSize = true;
            m_label2.AutoSize = true;
            fitLabels();
            Controls.Add(m_label1);
            Controls.Add(m_label2);
        }

        /// <summary>
        /// Fit labels proportions.
        /// </summary>
        protected abstract void fitLabels();
    }
}