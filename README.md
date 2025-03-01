# The Isle | EVRIMA Server Manager
Windows based server manager for running the isle evrima servers and managing them as you wish. Unfortunatekly the dev's of this game seem to have no care in the world for people spinning up unoffical servers and wanting to maintain and enjoy them. I made this tool for folks that want to do exactly that.
## Features
* Automated requirement installs outside of the server binary
* Game settings adjustments with the ability to restart the server after
  * The server wipes config if changes made while server is running (dev feature I'd guess)
* User management - [Uses SteamID64](https://steamid.io/)
  * Admin Users
  * VIP Users
  * Whitelist Users
* Togglable resource monitor via the GUI
* Scheduled RCON tasks within the manager itself
* Automated update checking for the manager as well as game server
* Customizable install locations for game server (defaults to manager directory)
* Server console direct into the manager console box
* Customizable alerts based on entries the server console outputs during runtime

## Possible Upcoming Features
* Dino storage - ability to save dino's per player once safely logged out
* Web based management system for deploying and managing multiple server instances running the manager
  * Optimzed manager stubs for web based deployments
  * Linux manager stub
* Linux manager standlaone - console app of course
* You're always welcome to submit ideas in the Issues tab - no guarantees on the ideas though, unless you code and make a PR to review and test

## Notice of included DLL files
For whatever reason the dev's have not included all of the required files in the dedicated server. I've copied the DLL's from a local install of Steam on a server I run. There is a setting in the main menu to NOT use the included DLLs if you don't trust it.
Hashes for the libraries included in the project (SHA256)
* steamclient.dll
  * 9a10906c763f60b2faa7147c5fbe487feb4d9d0dbb27fb40d31b9514e33b6373
  * https://www.virustotal.com/gui/file/9a10906c763f60b2faa7147c5fbe487feb4d9d0dbb27fb40d31b9514e33b6373
* steamclient64.dll
  * 0182bde8c78d8ae3c71889ba8a00ac5eddec70e25f71f8278caff25f0802ec31
  * https://www.virustotal.com/gui/file/0182bde8c78d8ae3c71889ba8a00ac5eddec70e25f71f8278caff25f0802ec31
* tier0_s.dll
  * 94bde3852aeacffc62ac10285cbba8862818166049ddaafaae5b7b1ed607e11e
  * https://www.virustotal.com/gui/file/94bde3852aeacffc62ac10285cbba8862818166049ddaafaae5b7b1ed607e11e
* tier0_s64.dll
  * 87b2d5cd0f667d8f72468ffd146dcf2aebdf7e65db575c04ffe6a4df9c1f1850
  * https://www.virustotal.com/gui/file/87b2d5cd0f667d8f72468ffd146dcf2aebdf7e65db575c04ffe6a4df9c1f1850
* vstdlib_s.dll
  * e0cf4a281918514f8d193c158948842b2ce5759e0066976f03b4d99c1f605e6f
  * https://www.virustotal.com/gui/file/e0cf4a281918514f8d193c158948842b2ce5759e0066976f03b4d99c1f605e6f
* vstdlib_s64.dll
  * f6cc0560b02e2bd5ee55a5d870761c333d4038ade3a8790578461ed20bd21ce7
  * https://www.virustotal.com/gui/file/f6cc0560b02e2bd5ee55a5d870761c333d4038ade3a8790578461ed20bd21ce7
  
This will obviously be an annoying thing to update as Valve updates these libraries but I'll do my best to maintain it.

## Donations - if you want
* Help with code would be nice
* Eth - 0xd101B9E05441518eE7E849C7709cbb2e9DfaEb96

## Notice of time dedicated to project
Just to be completely transparent - this is PURELY a side project. I work fulltime as well as volunteer alot of time for county work. I do not guarentee this will be maintained as quickly as game and Steam updates. Thankfully the dev's for The Isle push updates infrequently so that's kind of a plus.
