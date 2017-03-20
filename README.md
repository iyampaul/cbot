# CBOT

`CBOT` is a basic IRC bot written in C#.  

Feel free to contribute, rip, comment, whatever. 

# Compiling

I keep a basic bash script to simplify the build process:

`mcs main.cs src/*.cs addons/*.cs`

# Launching

The `CBOT` binary is expecting 3 input arguments: server, port, nickname. Example: 

`./main.exe irc.freenode.net 6667 cbot-bot`

# Authentication/Authorization

There's a basic authentication system build into `CBOT`. The auth key is printed to console and (at the moment) only changes when the bot is loaded.

To authenticate with the bot, messages it using "-auth key-hash" to have your nickname added to the authorization list.  This will unlock the other commands.

For the moment you must re-authenticate each time the bot is loaded.  There is no object permanence. 

# Addons

Addons should be declared in commands.cs and added to the Input() switch.  Some day this will be improved.

Core variables when creating addons:
```bash
$ lineWrite = Used to write to datastream
$ serverInfo = server data (hostname, port, nickname, channel)
$ lineData[] = raw IRC string array
```

# Contributing

If you're looking to add features or fix my spaghetti, pushing to master is OK.. for the moment.