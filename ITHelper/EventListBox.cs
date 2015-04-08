using cn.antontech.ITHelper.AutoActions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cn.antontech.ITHelper
{
    public class EventListBox : ListBox
    {
        private ImageList iconList;
        private System.ComponentModel.IContainer components;
    
        public EventListBox()
        {
            InitializeComponent();
            this.ItemHeight = 25;
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (this.Items.Count > 0)
            {
                ActionEventArgs item = (ActionEventArgs)this.Items[e.Index];

                // if selected, mark the background differently
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.LightSkyBlue, e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                }

                // draw some item separator
                //e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.X, e.Bounds.Y + e.Bounds.Height - 1, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height - 1);

                // draw item image
                if (item.EventType != ActionEventType.None)
                {
                    e.Graphics.DrawImage(this.iconList.Images[(int)item.EventType], e.Bounds.X + this.Margin.Left, e.Bounds.Y + this.Margin.Top, 16, 16);
                }

                // calculate bounds for title text drawing
                Rectangle titleBounds = new Rectangle(e.Bounds.X + this.Margin.Horizontal + 16,
                                                      e.Bounds.Y + this.Margin.Top,
                                                      e.Bounds.Width - this.Margin.Right - 16 - this.Margin.Horizontal,
                                                      (int)this.Font.GetHeight());

                // draw the text within the bounds
                e.Graphics.DrawString(item.Message, this.Font, Brushes.Black, titleBounds);
                //e.Graphics.DrawString(item.Name, this.Font, Brushes.Black, titleBounds, StringAlignment.Near);

                // put some focus rectangle
                e.DrawFocusRectangle();
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventListBox));
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "information.png");
            this.iconList.Images.SetKeyName(1, "error.png");
            this.iconList.Images.SetKeyName(2, "exclamation.png");
            this.iconList.Images.SetKeyName(3, "comment.png");
            // 
            // EventListBox
            // 
            this.Size = new System.Drawing.Size(120, 95);
            this.ResumeLayout(false);

        }
    }
}
