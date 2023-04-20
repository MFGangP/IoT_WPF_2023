using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WP05_bikeshop.Logics
{
    internal class MyConverter : IValueConverter
    {
        // 대상에 표현할 때 값을 변환(OneWay)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.Parse(value.ToString()) + " km/h";
        }
        // 대상 값이 바뀌어 원본(소스)의 값을 변환해서 표현(TwoWay)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.Parse(value.ToString()) * 3;
        }
    }
}
