using System;
using System.Windows.Forms;
using System.Drawing;

namespace FacebookTools.UI
{
    public abstract class FBListBox : Control
    {
        public static readonly int sr_BoxesInList = 5;
        public static readonly int sr_HeightProportion = FBBox.sr_HeightProportion + sr_boxesGap;
        private static readonly int sr_scrollbarWidth = 20;
        private static readonly int sr_boxesGap = 5;
        protected FBBox[] m_boxes;
        protected VScrollBar m_scrollBar;

        /// <summary>
        /// Facebook ListBox constructor.
        /// </summary>
        public FBListBox()
            : base(string.Empty, 0, 0, FBBox.sr_WidthProportion, sr_HeightProportion * sr_BoxesInList)
        {
            m_scrollBar = new VScrollBar();
            m_scrollBar.Maximum = 0;
            m_scrollBar.Minimum = 0;
            m_scrollBar.Value = 0;
            m_boxes = new FBBox[sr_BoxesInList];
            m_scrollBar.Location = new Point(0, 0);
            m_scrollBar.Size = new Size(sr_scrollbarWidth, (sr_HeightProportion * sr_BoxesInList) - sr_boxesGap);
            m_scrollBar.LargeChange = 1;
            m_scrollBar.ValueChanged += M_scrollBar_ValueChanged;
            Controls.Add(m_scrollBar);
            for (int i = 0; i < sr_BoxesInList; i++)
            {
                updateBox(i, i);
            }
        }

        /// <summary>
        /// Update the list view according to the scroll bar.
        /// </summary>
        /// <param name="i_Sender"></param>
        /// <param name="i_Args"></param>
        protected void M_scrollBar_ValueChanged(object i_Sender, EventArgs i_Args)
        {
            for (int i = 0; i < sr_BoxesInList; i++)
            {
                int index = m_scrollBar.Value + i;
                updateBox(index, i);
            }
        }

        /// <summary>
        /// Put given value in given box.
        /// </summary>
        /// <param name="i_IndexInList">The value that the scroll bar points on.</param>
        /// <param name="i_BoxIndex">The index of the box that will hold the post.</param>
        protected abstract void updateItem(int i_IndexInList, int i_BoxIndex);

        /// <summary>
        /// Client clicked on item.
        /// </summary>
        /// <param name="i_Index">Item's index.</param>
        protected abstract void itemSelected(int i_Index);

        /// <summary>
        /// Update the box in the given location.
        /// </summary>
        /// <param name="i_IndexInList">The value that the scroll bar points on.</param>
        /// <param name="i_BoxIndex">The index of the box that will hold the post.</param>
        private void updateBox(int i_IndexInList, int i_BoxIndex)
        {
            if (m_boxes[i_BoxIndex] != null)
            {
                m_boxes[i_BoxIndex].MouseClicked -= itemSelected;
                Controls.Remove(m_boxes[i_BoxIndex]);
            }

            updateItem(i_IndexInList, i_BoxIndex);
            m_boxes[i_BoxIndex].Location = new Point((int)(sr_scrollbarWidth * 1.5f), sr_HeightProportion * i_BoxIndex);
            m_boxes[i_BoxIndex].MouseClicked += itemSelected;
            m_boxes[i_BoxIndex].Index = i_BoxIndex;
            Controls.Add(m_boxes[i_BoxIndex]);
        }
    }
}
