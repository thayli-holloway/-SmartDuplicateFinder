using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SmartDuplicateFinder.Converters;

[ValueConversion(typeof(string), typeof(ImageSource))]
public class LoadIcon : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (targetType != typeof(ImageSource))
			return Binding.DoNothing;

		string[] parts = ((string)parameter).Split('|');
		BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions();

		if (parts.Length == 3)
		{
			string[] size = parts[2].Split('x');
			if (size.Length == 2)
			{
				sizeOptions = BitmapSizeOptions.FromWidthAndHeight(int.Parse(size[0]), int.Parse(size[1]));
			}
			else
			{
				var hw = int.Parse(size[0]);
				sizeOptions = BitmapSizeOptions.FromWidthAndHeight(hw, hw);
			}
		}

		IntPtr hIcon = ExtractIcon(Process.GetCurrentProcess().Handle, parts[0], int.Parse(parts[1]));

		ImageSource ret = Imaging.CreateBitmapSourceFromHIcon(hIcon, Int32Rect.Empty, sizeOptions);
		return ret;
	}
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

	[DllImport("shell32.dll")]
	private static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

}
