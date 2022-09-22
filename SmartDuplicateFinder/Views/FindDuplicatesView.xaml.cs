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

		DataContext = this;
	}

	private void AddCommandBindings()
	{
		//CommandBindings.Add(new CommandBinding(AppCommands.Xxxxxx, (sender, args) => OnXxxxx(args)));
		//CommandBindings.Add(new CommandBinding(AppCommands.Xxxxxx, (sender, args) => OnXxxxx()));
	}
}
