using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cn.antontech.ITHelper
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageListBox : ResizableListBox
    {
        private const int m_MainTextOffset = 30;
        private Font m_HeadingFont;
        private ImageList IconList;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MessageListBox()
        {
            InitializeComponent();
            this.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_HeadingFont = new Font(this.Font, FontStyle.Bold);
            this.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.MeasureItemHandler);
        }


        /// <summary>
        /// Windows-Init.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageListBox));
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // IconList
            // 
            this.IconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconList.ImageStream")));
            this.IconList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconList.Images.SetKeyName(0, "");
            this.IconList.Images.SetKeyName(1, "");
            this.IconList.Images.SetKeyName(2, "");
            this.IconList.Images.SetKeyName(3, "");
            this.ResumeLayout(false);

        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }

            m_HeadingFont.Dispose();

            base.Dispose(disposing);
        }

        #region overrides
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            ParseMessageEventArgs item;
            Rectangle bounds = e.Bounds;
            Color TextColor = System.Drawing.SystemColors.ControlText;

            item = (ParseMessageEventArgs)Items[e.Index];

            //draw selected item background
            if (e.State == DrawItemState.Selected)
            {
                using (Brush b = new SolidBrush(System.Drawing.SystemColors.Highlight))
                {
                    // Fill background;
                    e.Graphics.FillRectangle(b, e.Bounds);
                }
                TextColor = System.Drawing.SystemColors.HighlightText;
            }

            //draw image
            if (item.MessageType != ParseMessageType.None)
                IconList.Draw(
                    e.Graphics,
                    bounds.Left + 1,
                    bounds.Top + 2,
                    (int)item.MessageType);

            using (SolidBrush TextBrush = new SolidBrush(TextColor))
            {
                //draw Headline
                e.Graphics.DrawString(
                    item.LineHeader,
                    m_HeadingFont,
                    TextBrush,
                    bounds.Left + IconList.ImageSize.Width + 5,
                    bounds.Top + IconList.ImageSize.Height - m_HeadingFont.Height);

                //draw main text
                int LinesFilled = 0,
                    CharsFitted = 0,
                    top;

                // Draw layout, 2 times the offset (left & right)
                Size oneLine = new Size(this.Width - m_MainTextOffset * 2, this.Font.Height);

                StringBuilder sbTextToDraw = new StringBuilder(item.MessageText);
                string strLineToDraw;
                int index1 = 0,
                    index2, index2New;
                top = bounds.Top + IconList.ImageSize.Height + 2;

                while (sbTextToDraw.Length > 0)
                {
                    // Break string into more lines when an end-of-line character is found
                    if ((index2 = sbTextToDraw.ToString().IndexOf('\n')) > 0)
                    {
                        strLineToDraw = sbTextToDraw.ToString(index1, index2 - index1);
                        index2New = index2 + 1;
                    }
                    else
                    {
                        index2 = sbTextToDraw.Length;
                        index2New = index2;
                        strLineToDraw = sbTextToDraw.ToString();
                    }

                    e.Graphics.MeasureString(
                        strLineToDraw,
                        this.Font,
                        oneLine,
                        StringFormat.GenericDefault,
                        out CharsFitted,
                        out LinesFilled);

                    // There's no knowledge about words, so just don't split words up if possible
                    if (CharsFitted < index2)
                    {
                        int index = strLineToDraw.LastIndexOf(' ', CharsFitted - 1, CharsFitted);
                        if (index != -1)
                            index2New = index + 1;
                        else
                            index2New = CharsFitted;
                        strLineToDraw = sbTextToDraw.ToString(index1, index2New - index1);
                    }

                    // Draw the text
                    e.Graphics.DrawString(
                        strLineToDraw,
                        this.Font,
                        TextBrush,
                        bounds.Left + m_MainTextOffset,
                        top);

                    // Adjust top
                    top += this.Font.Height;

                    // Next line
                    sbTextToDraw = sbTextToDraw.Remove(index1, index2New);
                }

                sbTextToDraw = null;
                strLineToDraw = null;
            }
        }


        private void MeasureItemHandler(object sender, MeasureItemEventArgs e)
        {
            int MainTextHeight;
            ParseMessageEventArgs item;
            item = (ParseMessageEventArgs)Items[e.Index];
            int LinesFilled, CharsFitted;

            // Draw layout, 2 times the offset (left & right)
            Size sz = new Size(this.Width - m_MainTextOffset * 2, this.Font.Height);

            StringBuilder sbTextToDraw = new StringBuilder(item.MessageText);
            string strLineToDraw;
            int index1 = 0,
                index2,
                index2New,
                lines = 0;

            while (sbTextToDraw.Length > 0)
            {
                // Break string into more lines when an end-of-line character is found
                if ((index2 = sbTextToDraw.ToString().IndexOf('\n')) > 0)
                {
                    strLineToDraw = sbTextToDraw.ToString(index1, index2 - index1);
                    index2New = index2 + 1;
                }
                else
                {
                    index2 = sbTextToDraw.Length;
                    index2New = index2;
                    strLineToDraw = sbTextToDraw.ToString();
                }

                e.Graphics.MeasureString(
                    strLineToDraw,
                    this.Font,
                    sz,
                    StringFormat.GenericDefault,
                    out CharsFitted,
                    out LinesFilled);

                // There's no knowledge about words, so just don't split words up if possible
                if (CharsFitted < index2)
                {
                    int index = strLineToDraw.LastIndexOf(' ', CharsFitted - 1, CharsFitted);
                    if (index != -1)
                        index2New = index + 1;
                    else
                        index2New = CharsFitted;
                }

                lines += LinesFilled;
                sbTextToDraw = sbTextToDraw.Remove(index1, index2New);
            }

            sbTextToDraw = null;
            strLineToDraw = null;

            MainTextHeight = lines * this.Font.Height;

            e.ItemHeight = IconList.ImageSize.Height + MainTextHeight + 4;
            e.ItemWidth = sz.Width;
        }
        #endregion
    }

}
