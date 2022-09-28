using SmartDuplicateFinder.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;


namespace SmartDuplicateFinder.Views;
/// <summary>
/// Interaction logic for FindDuplicatesView.xaml
/// </summary>
public partial class FindDuplicatesView : UserControl
{
	public FindDuplicatesView()
	{
		InitializeComponent();
		AddCommandBindings();

		Drives = new ObservableCollection<DriveViewModel>();

		var drives = DriveInfo.GetDrives().Where(d => d.IsReady).Select(d => new DriveViewModel(d));
		foreach(DriveViewModel driver in drives)
		{
			Drives.Add(driver);
		}

		DataContext = this;

	}

	public ObservableCollection<DriveViewModel> Drives { get; set; }

	private void AddCommandBindings()
	{
		//CommandBindings.Add(new CommandBinding(AppCommands.Xxxxxx, (sender, args) => OnXxxxx(args)));
		//CommandBindings.Add(new CommandBinding(AppCommands.Xxxxxx, (sender, args) => OnXxxxx()));
	}
}
