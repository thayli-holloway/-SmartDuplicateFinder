﻿using SmartDuplicateFinder.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SmartDuplicateFinder.Converters;

[ValueConversion(typeof(Icons), typeof(ImageSource))]
public class GetIcon : IValueConverter
{
	public int DefaultImageSize { get; set; } = 16;

	public object Convert(object value, Type targetType, object? parameter, CultureInfo culture) 
	{
		if (targetType != typeof(ImageSource))
			return Binding.DoNothing;

		Icons icons = (Icons) value;
		int pixelSize = parameter == null ? DefaultImageSize : (int) parameter;

		ImageSource? ret = IconManager.GetIcon(icons, pixelSize);
		return ret!;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

	[DllImport("shell32.dll")]
	private static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);
}
