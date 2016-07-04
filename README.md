# CBOT

`CBOT` is a basic IRC bot in C#.  Net code (connection, ping thread, stream setup) was graciously used from public locations around the internet.

Feel free to contribute, rip, comment, or provide feedback.  Feedback is always welcome and appreciated.

# Adding Commands

Addons should be declared in commands.cs and added to the Input() switch.

Core variables when creating addons:
```bash
$ lineWrite = Used to write to datastream
$ serverInfo = server data (hostname, port, nickname, channel)
$ lineData[] = raw IRC string array
```

