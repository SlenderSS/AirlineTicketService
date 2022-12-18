using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ClientWPF.Src
{
    public static class Animation
    {
        private static int landslide = 10;
        public static void Open(this Window lastWindow, Window nextWindow)
        {
            if (Math.Abs(nextWindow.Width - lastWindow.Width) <= landslide)
            {
                nextWindow.Show();
                lastWindow.Close();
                return;
            }
            
            TemplateWindow templateWindow = new TemplateWindow(lastWindow.Left, lastWindow.Top);
            templateWindow.Width = lastWindow.Width;
            templateWindow.Show();
            lastWindow.Close();
            while(templateWindow.Width != nextWindow.Width)
            {

                if (templateWindow.Width > nextWindow.Width)
                {
                    templateWindow.Width -= landslide;
                    templateWindow.Left += landslide/2;
                }
                else if (templateWindow.Width < nextWindow.Width)
                {
                    templateWindow.Width += landslide;
                    templateWindow.Left -= landslide/2;
                }
                
                //Thread.Sleep(1);
            }
            nextWindow.Left = templateWindow.Left;
            nextWindow.Show();
            templateWindow.Close();
            
        }
    }
}
