using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RunasGui
{
    public class RunasObjectListBox : ListBox
    {
        public RunasObjectListBox()
        {
            this.ItemHeight = 25;
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (this.Items.Count > 0)
            {
                RunasObject item = (RunasObject)this.Items[e.Index];
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
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.X, e.Bounds.Y + e.Bounds.Height - 1, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height - 1);

                // draw item image
                try
                {
                    if (File.Exists(item.ExeFile))
                    {
                        Icon appIcon = Icon.ExtractAssociatedIcon(item.ExeFile);
                        e.Graphics.DrawImage(appIcon.ToBitmap(), e.Bounds.X + this.Margin.Left, e.Bounds.Y + this.Margin.Top, 16, 16);
                    }

                }
                catch
                {

                }

                // calculate bounds for title text drawing
                Rectangle titleBounds = new Rectangle(e.Bounds.X + this.Margin.Horizontal + 16,
                                                      e.Bounds.Y + this.Margin.Top,
                                                      e.Bounds.Width - this.Margin.Right - 16 - this.Margin.Horizontal,
                                                      (int)this.Font.GetHeight());

                // draw the text within the bounds
                e.Graphics.DrawString(item.Name, this.Font, Brushes.Black, titleBounds);
                //e.Graphics.DrawString(item.Name, this.Font, Brushes.Black, titleBounds, StringAlignment.Near);

                // put some focus rectangle
                e.DrawFocusRectangle();
            }
        }
    }
}
