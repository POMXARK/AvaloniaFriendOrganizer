using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace FriendOrganizer.UI.Helpers
{
    public class JoinStringConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object parameter, CultureInfo culture)
        {
            var separator = parameter as string ?? " ";
            return string.Join(separator, values);
        }

        public object[]? ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var separator = parameter as string ?? " ";
            return (value as string)?.Split(new[] { separator }, StringSplitOptions.None).Cast<object>().ToArray();
        }
    }
}
