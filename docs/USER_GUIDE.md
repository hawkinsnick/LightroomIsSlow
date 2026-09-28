# LightroomIsSlow — User Guide

This guide is written for Lightroom users. You do not need to know programming or Windows performance counters.

## Before you begin

LightroomIsSlow currently remains a **pre-1.0 testing project**. The final end-user Windows package is still being validated.

When an official downloadable build is available, it will appear on the **Releases** page of this GitHub repository.

## What you will do

A useful test has three simple parts:

**Start recording → make Lightroom do the slow thing → stop and analyze.**

The recording is useful only if it includes the period when you actually experienced the problem.

## 1. Download LightroomIsSlow

Go to this repository's Releases page and choose the newest stable Windows release.

Download only a release published by this repository. Do not download LightroomIsSlow executables from third-party download sites.

If there is no Windows package in Releases yet, the project is not ready for this non-technical installation path.

## 2. Extract the package

If the download is a ZIP file:

1. Open your Downloads folder.
2. Right-click the downloaded ZIP.
3. Choose **Extract All**.
4. Open the extracted folder.

Do not run the program from inside the ZIP.

## 3. Start Lightroom

Open **Lightroom Classic** or **Adobe Lightroom desktop** normally.

Open the catalog/photos and get ready to reproduce the problem you want to investigate.

Examples include:
- Library or grid browsing feels sluggish.
- Develop/Edit becomes unresponsive.
- Import is unusually slow.
- Export takes longer than expected.
- Preview generation is slow.
- AI Denoise or masking is slow.
- Panorama/HDR work is slow.
- Lightroom cloud activity appears stalled.

## 4. Start recording

Launch LightroomIsSlow from the extracted folder.

Confirm that it identifies the Lightroom application you are testing, then start a recording.

For a useful diagnostic session, avoid deliberately starting unrelated heavy workloads such as games, benchmarks, large file copies, or video rendering unless that interference is itself what you want to investigate.

## 5. Reproduce the slowdown

Use Lightroom normally and perform the operation that feels slow.

Try to capture enough of the operation to show both normal behavior and the slowdown. A few minutes is generally more useful than a few seconds.

## 6. Stop recording

Stop the LightroomIsSlow recording after the problem has occurred.

The application creates a session containing normalized performance measurements and session metadata.

## 7. Analyze

Run the analysis for the session.

A finding should explain:
- **what was observed;**
- **how strong the evidence is;**
- **what evidence supports the finding;**
- **what evidence argues against it;** and
- **what investigation or action follows from that evidence.**

LightroomIsSlow may also report **No endpoint constraint established** or **Insufficient evidence**. Those are intentional results. The application should not invent a bottleneck merely because Lightroom felt slow.

## Understanding results

### Storage pressure

This means multiple storage measurements support the conclusion that storage behavior coincided with the slowdown. A drive being “100% active” by itself is not enough.

### Memory pressure

This requires evidence such as low available memory together with paging/fault activity. High RAM usage alone is not automatically a problem.

### CPU saturation

Sustained CPU utilization may be relevant, but some Lightroom operations—especially exports—can legitimately use as much CPU as possible. The workload matters.

### GPU pressure

GPU utilization and GPU-memory behavior are considered where Windows exposes usable telemetry and where the Lightroom workload makes GPU activity relevant.

### No endpoint constraint established

The collected endpoint telemetry did not establish CPU, memory, storage, network, or GPU pressure sufficient to explain the problem. It does not mean you imagined the slowdown.

### Insufficient evidence

The recording was too short, incomplete, or lacked the measurements necessary to support a defensible conclusion.

## Privacy

The project is designed to diagnose resource behavior, not inspect your photographs.

Diagnostic telemetry should not contain:
- image contents;
- Lightroom catalog contents;
- Adobe passwords;
- cloud authentication tokens.

Before sharing a diagnostic package during pre-release testing, you may inspect its JSON files with Notepad if you want to see exactly what was recorded.

## Reporting a problem

When reporting a bug, include:
- LightroomIsSlow version;
- whether you used Lightroom Classic or Lightroom desktop;
- Lightroom version if known;
- what operation you were performing;
- what felt slow;
- whether the problem happens consistently;
- the diagnostic session/report when you are comfortable sharing it.

Do **not** upload photographs, Lightroom catalogs, passwords, or other private material.

## Current limitation

Until the repository publishes a packaged Windows release, the simple download-and-double-click path described above is a **target workflow**, not yet an available release. Developers can build the current source using the instructions in the main README.
