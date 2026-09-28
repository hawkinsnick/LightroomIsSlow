# Collector coverage

## Implemented
- Lightroom process discovery
- Lightroom process CPU utilization
- System CPU utilization via Windows system times
- Physical memory available
- Commit/page-file utilization
- Stable one-second session scheduler

## Required before 1.0
- Hard-fault rate
- Physical-disk read/write throughput
- Physical-disk latency and queue depth
- Network receive/send throughput
- GPU engine utilization
- Dedicated/shared GPU memory
- Hardware inventory and metric provenance

Unavailable metrics remain null; null must never be interpreted as zero.
