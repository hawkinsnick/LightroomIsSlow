using System.Diagnostics;using System.Windows;using System.Windows.Controls;using LightroomIsSlow.Core.Models;using LightroomIsSlow.Core.Sessions;using LightroomIsSlow.Windows.Health;using LightroomIsSlow.Windows.Inventory;using LightroomIsSlow.Windows.Processes;using LightroomIsSlow.Windows.Telemetry;
namespace LightroomIsSlow.App;
public partial class MainWindow:Window
{
 readonly WindowsLightroomProcessDetector detector=new(); CancellationTokenSource? cts; Task? recording; string? sessionPath;
 public MainWindow(){InitializeComponent();Loaded+=(_,_)=>Refresh();}
 void Refresh(){var p=detector.Detect().FirstOrDefault();DetectionText.Text=p is null?"Lightroom is not running yet.":"Ready — "+p.Product+" detected ("+p.ProcessName+").";}
 async void Record_Click(object sender,RoutedEventArgs e){
  if(cts is not null){cts.Cancel();RecordButton.IsEnabled=false;StatusText.Text="Finishing recording and analyzing…";try{if(recording is not null)await recording;}catch(OperationCanceledException){}cts=null;RecordButton.Content="Start Recording";RecordButton.IsEnabled=true;StatusText.Text=$"Recording saved. Session folder: {sessionPath}";return;}
  var p=detector.Detect().FirstOrDefault();if(p is null){MessageBox.Show("Please open Lightroom first, then click Start Recording.","Lightroom not detected");Refresh();return;}
  var id=DateTimeOffset.UtcNow.ToString("yyyyMMddTHHmmssZ");sessionPath=Path.GetFullPath(Path.Combine("sessions",id));var label=((ComboBoxItem)Workload.SelectedItem).Content?.ToString();
  var meta=new SessionMetadata{SessionId=id,SchemaVersion="1.0",AppVersion="pre-1.0",StartedUtc=DateTimeOffset.UtcNow,SampleInterval=TimeSpan.FromSeconds(1),LightroomProcess=p,WorkloadLabel=label,System=new WindowsSystemInventoryProvider().Capture(),WindowsHealth=new WindowsHealthProvider().Capture()};
  cts=new CancellationTokenSource();var rec=new SessionRecorder(new WindowsTelemetryCollector(p));recording=rec.RecordAsync(meta,"sessions",TimeSpan.FromHours(8),cts.Token);RecordButton.Content="Stop & Analyze";StatusText.Text="Recording. Reproduce the slowdown in Lightroom, then click Stop & Analyze.";
 }
 void Refresh_Click(object sender,RoutedEventArgs e)=>Refresh();
 void OpenSessions_Click(object sender,RoutedEventArgs e){Directory.CreateDirectory("sessions");Process.Start(new ProcessStartInfo(Path.GetFullPath("sessions")){UseShellExecute=true});}
}
