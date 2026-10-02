using LightroomIsSlow.Core.Models;
namespace LightroomIsSlow.Core.Applications;
public sealed class LightroomApplicationProfile:IApplicationProfileProvider
{
 public ApplicationProfile GetProfile()=>new("adobe.lightroom","Adobe Lightroom",["Lightroom","Adobe Lightroom","LightroomCC"],[
 new(WorkloadKind.LibraryBrowsing,"Library browsing",["moderate CPU","bursty storage reads"],["sustained storage latency with queue pressure","sustained paging"]),
 new(WorkloadKind.DevelopEditing,"Develop / editing",["interactive CPU and GPU activity"],["resource pressure correlated with interaction stalls"]),
 new(WorkloadKind.Export,"Export",["sustained high CPU can be healthy","substantial storage writes can be healthy"],["low useful CPU with corroborated storage stalls","sustained paging"]),
 new(WorkloadKind.AiDenoise,"AI Denoise",["substantial GPU compute may be healthy"],["GPU or memory pressure correlated with the stall"]),
 new(WorkloadKind.CloudSync,"Cloud sync",["network activity"],["network stalls with local resource headroom"])]);
}
