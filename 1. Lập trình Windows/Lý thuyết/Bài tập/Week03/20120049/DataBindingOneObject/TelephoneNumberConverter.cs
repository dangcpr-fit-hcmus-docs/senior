using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataBindingOneObject
{
    public class TelephoneNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string telphoneNumber = (string)value;

            telphoneNumber = telphoneNumber.Insert(4, ".");
            telphoneNumber = telphoneNumber.Insert(8, ".");

            return telphoneNumber;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
