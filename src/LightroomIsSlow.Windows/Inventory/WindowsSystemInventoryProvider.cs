using System.Management;using System.Runtime.InteropServices;using LightroomIsSlow.Core.Abstractions;using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Windows.Inventory;
public sealed class WindowsSystemInventoryProvider:ISystemInventoryProvider
{
 public SystemInventory Capture()=>new(){MachineName=Environment.MachineName,OsDescription=RuntimeInformation.OSDescription,OsArchitecture=RuntimeInformation.OSArchitecture.ToString(),LogicalProcessorCount=Environment.ProcessorCount,TotalPhysicalMemoryBytes=L("Win32_ComputerSystem","TotalPhysicalMemory"),Gpus=S("Win32_VideoController","Name"),Disks=S("Win32_DiskDrive","Model")};
 static IReadOnlyList<string>S(string c,string p){try{using var q=new ManagementObjectSearcher($"SELECT {p} FROM {c}");return q.Get().Cast<ManagementObject>().Select(x=>x[p]?.ToString()).Where(x=>!string.IsNullOrWhiteSpace(x)).Cast<string>().ToArray();}catch{return[];}} static long L(string c,string p){try{using var q=new ManagementObjectSearcher($"SELECT {p} FROM {c}");var v=q.Get().Cast<ManagementObject>().FirstOrDefault()?[p];return v is null?0:Convert.ToInt64(v);}catch{return 0;}}
}
