using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Planetgram.Converters
{
    public class FollowersCountToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Int32 followersNumber = Int32.Parse(value.ToString());
                //Black
                if (followersNumber == 0)
                    return new SolidColorBrush(Colors.Black);
                //White
                else if (followersNumber >= 1 && followersNumber < 100)
                    return new SolidColorBrush(Colors.White);
                //Poor
                else if (followersNumber >= 100 && followersNumber <= 1000)
                    return new SolidColorBrush(Color.FromRgb(157, 157, 157));
                //Rare
                else if (followersNumber >= 1000 && followersNumber <= 10000)
                    return new SolidColorBrush(Color.FromRgb(0, 112, 221));
                //Epic
                else if (followersNumber >= 10000 && followersNumber <= 100000)
                    return new SolidColorBrush(Color.FromRgb(163, 53, 238));
                //Legendary
                else if (followersNumber >= 100000 && followersNumber <= 1000000)
                    return new SolidColorBrush(Color.FromRgb(255, 128, 0));
                //Artifact
                else if (followersNumber >= 1000000)
                    return new SolidColorBrush(Color.FromRgb(230, 204, 128));
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
