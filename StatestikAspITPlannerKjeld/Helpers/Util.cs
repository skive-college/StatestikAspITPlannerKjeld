using StatestikAspITPlannerKjeld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StatestikAspITPlannerKjeld.Helpers
{
    public class Util
    {
        public static System.Collections.ObjectModel.Collection<ResourceDictionary> MakePalette(List<ChartValues> list)
        {
            System.Collections.ObjectModel.Collection<ResourceDictionary> palette = new System.Collections.ObjectModel.Collection<ResourceDictionary>();
            foreach (ChartValues item in list)
            {
                ResourceDictionary rd = new ResourceDictionary();
                Style style = new Style(typeof(Control));
                SolidColorBrush brush = null;
                switch (item.ID)
                {
                    case 1: brush = new SolidColorBrush(Colors.LightBlue); break;
                    case 2: brush = new SolidColorBrush(Colors.DarkOrange); break;
                    case 3: brush = new SolidColorBrush(Colors.Red); break;
                    case 4: brush = new SolidColorBrush(Colors.Green); break;
                    case 5: brush = new SolidColorBrush(Colors.LightGreen); break;
                    case 6: brush = new SolidColorBrush(Colors.DarkKhaki); break;
                    case 7: brush = new SolidColorBrush(Colors.Yellow); break;
                    default: brush = new SolidColorBrush(Colors.Black); break;
                }
                style.Setters.Add(new Setter() { Property = Control.BackgroundProperty, Value = brush });
                rd.Add("DataPointStyle", style);
                palette.Add(rd);
            }
            return palette;
        }
    }
}
