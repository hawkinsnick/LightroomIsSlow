# Telemetry schema v0.1

All timestamps are UTC. Fields may be null when unavailable on a given endpoint or collector.

| Field | Unit | Scope |
|---|---:|---|
| timestamp_utc | ISO-8601 | sample |
| session_id | string | sample |
| lightroom_process_id | PID | sample |
| cpu_system_percent | % | system |
| cpu_lightroom_percent | % | process |
| cpu_frequency_mhz | MHz | system |
| memory_available_mb | MB | system |
| memory_commit_percent | % | system |
| memory_hard_faults_per_second | faults/s | system |
| disk_read_bytes_per_second | bytes/s | system/selected disk |
| disk_write_bytes_per_second | bytes/s | system/selected disk |
| disk_read_latency_ms | ms | system/selected disk |
| disk_write_latency_ms | ms | system/selected disk |
| disk_queue_depth | requests | system/selected disk |
| gpu_3d_percent | % | system/GPU engine |
| gpu_compute_percent | % | system/GPU engine |
| gpu_vram_used_mb | MB | GPU |
| network_receive_bytes_per_second | bytes/s | system |
| network_send_bytes_per_second | bytes/s | system |

## Provenance requirement
Future schema revisions should attach collector/source metadata so any conclusion can be traced back to how a measurement was obtained.
