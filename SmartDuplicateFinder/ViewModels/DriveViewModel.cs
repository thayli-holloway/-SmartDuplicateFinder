using System.IO;

namespace SmartDuplicateFinder.ViewModels;

public class DriveViewModel
{
	public DriveViewModel(DriveInfo driveInfo)
	{
		DriveInfo = driveInfo;
		Name = $"{DriveInfo.VolumeLabel} ({DriveInfo.Name[..^1]})";
	}

	public string Name { get; protected set; }
	public DriveInfo DriveInfo { get; private set; }
}
