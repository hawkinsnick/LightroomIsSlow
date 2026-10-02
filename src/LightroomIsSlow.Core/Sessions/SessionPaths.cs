namespace LightroomIsSlow.Core.Sessions;
public static class SessionPaths
{
 public static string DefaultRoot(){var root=Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);return Path.Combine(root,"LightroomIsSlow","Sessions");}
}
