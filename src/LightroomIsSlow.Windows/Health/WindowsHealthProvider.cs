using System.Management;using Microsoft.Win32;using LightroomIsSlow.Core.Abstractions;using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Windows.Health;
public sealed class WindowsHealthProvider:IPlatformHealthProvider
{
 public PlatformHealthSnapshot Capture()
 {
  var warnings=new List<string>();var free=DriveFree();var pending=Pending();var update=LatestUpdate();var power=Power();
  if(free is <10)warnings.Add("System drive has less than 10% free space.");
  if(pending==true)warnings.Add("Windows indicates that a reboot is pending.");
  return new(){Platform=PlatformKind.Windows,CapturedUtc=DateTimeOffset.UtcNow,OsName=Reg(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion","ProductName"),OsVersion=Reg(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion","DisplayVersion"),OsBuild=Reg(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion","CurrentBuildNumber"),LastBootUtc=Boot(),PendingRestart=pending,LatestInstalledUpdateUtc=update.date,InstalledUpdateCount=update.count,PowerMode=power,SystemDriveFreePercent=free,SecurityState=new Dictionary<string,string?>{{"defender_realtime",Defender("RealTimeProtectionEnabled")?.ToString()},{"defender_antivirus",Defender("AntivirusEnabled")?.ToString()}},Warnings=warnings};
 }
 static string? Reg(string k,string n){try{return Registry.LocalMachine.OpenSubKey(k)?.GetValue(n)?.ToString();}catch{return null;}}
 static DateTimeOffset? Boot(){try{using var q=new ManagementObjectSearcher("SELECT LastBootUpTime FROM Win32_OperatingSystem");var v=q.Get().Cast<ManagementObject>().FirstOrDefault()?["LastBootUpTime"]?.ToString();return v is null?null:new DateTimeOffset(ManagementDateTimeConverter.ToDateTime(v));}catch{return null;}}
 static (DateTimeOffset? date,int? count) LatestUpdate(){try{using var q=new ManagementObjectSearcher("SELECT InstalledOn FROM Win32_QuickFixEngineering");var dates=q.Get().Cast<ManagementObject>().Select(x=>x["InstalledOn"]?.ToString()).Select(x=>DateTimeOffset.TryParse(x,out var d)?d:(DateTimeOffset?)null).Where(x=>x.HasValue).Select(x=>x!.Value).ToArray();return(dates.Length==0?null:dates.Max(),dates.Length);}catch{return(null,null);}}
 static bool? Pending(){try{return Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update\RebootRequired") is not null||Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\RebootPending") is not null;}catch{return null;}}
 static double? DriveFree(){try{var root=Path.GetPathRoot(Environment.SystemDirectory);var d=new DriveInfo(root!);return d.TotalSize==0?null:d.AvailableFreeSpace*100d/d.TotalSize;}catch{return null;}}
 static string? Power(){try{using var q=new ManagementObjectSearcher(@"root\cimv2\power","SELECT ElementName FROM Win32_PowerPlan WHERE IsActive=True");return q.Get().Cast<ManagementObject>().FirstOrDefault()?["ElementName"]?.ToString();}catch{return null;}}
 static bool? Defender(string prop){try{using var q=new ManagementObjectSearcher(@"root\SecurityCenter2",$"SELECT {prop} FROM AntiVirusProduct");var v=q.Get().Cast<ManagementObject>().FirstOrDefault()?[prop];return v is null?null:Convert.ToBoolean(v);}catch{return null;}}
}
