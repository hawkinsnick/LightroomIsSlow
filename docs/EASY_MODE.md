# Easy mode design

The normal LightroomIsSlow workflow must not require a terminal.

1. Open Lightroom.
2. Open LightroomIsSlow.
3. LightroomIsSlow detects the product automatically.
4. Optionally choose what you are doing.
5. Click **Start Recording**.
6. Reproduce the slowdown.
7. Click **Stop & Analyze**.
8. Read a plain-language result or open the session folder.

The application must tolerate missing optional counters and explain what it could not measure. It must never require users to understand PDH, ETW, JSON, process IDs, or performance-counter names.

Command-line functionality remains useful for automation, developers, and support, but it is not the primary end-user experience.
