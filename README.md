# CBOT

`CBOT` is a basic IRC bot in C#.  Net code (connection, ping thread, stream setup) was graciously used from public locations around the internet.

Feel free to contribute, rip, comment, or provide feedback.  Feedback is always welcome and appreciated.

`CBOT` is being developed using Mono in Linux. 

# Building

I keep a basic bash script to simplify the build process:

`dmcs main.cs src/*.cs addons/*.cs`


# Launching

The `CBOT` binary is expecting 3 input arguments: server, port, nickname. Example: 

`./main.exe irc.freenode.net 6667 cbot-bot`


# Addons

Addons should be declared in commands.cs and added to the Input() switch.

Core variables when creating addons:
```bash
$ lineWrite = Used to write to datastream
$ serverInfo = server data (hostname, port, nickname, channel)
$ lineData[] = raw IRC string array
```

# Contributing

If you're looking to add features or fix my spaghetti, pushing to master is OK.. for the moment.