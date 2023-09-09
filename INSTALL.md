# Airplane Plus /L

Adds a collection plane parts which came from different timelines.

Previously developed and maintained by [Blackheart612](https://forum.kerbalspaceprogram.com/index.php?/profile/42741-blackheart612/) (eternal thanks for making and maintaining AP+!), currently by yours truly, [Lisias](https://forum.kerbalspaceprogram.com/index.php?/profile/187168-lisias/).

This repository is maintained (under authorisation) by Lisias.


## Installation Instructions

To install, place the GameData folder inside your Kerbal Space Program folder:

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**, including any other fork:
	+ Delete `<KSP_ROOT>/GameData/AirplanePlus`
* Extract the package's `GameData/` folder into your KSP's as follows:
	+ `<PACKAGE>/GameData/AirplanePlus ` --> `<KSP_ROOT>/AirplanePlus `
* Install the remaining dependencies
        + See below on **Dependencies**

The following file layout must be present after installation:

```
<KSP_ROOT>
	+ [GameData]
		+ [AirplanePlus]
			+ [Agencies] 
				...
			+ [FX] 
				...
			+ [Parts] 
				...
			+ [Plus] 
				...
			+ [Props] 
				...
			+ [Sounds] 
				...
			+ [Spaces] 
				...
			+ [Updates] 
				...
			* CHANGE_LOG.md
			* LICENSE
			* NOTICE
			* README.md
			* AirplanePlus.version
		+ [Firespitter]
			... 
		* ModuleManager.dll
		...
	* KSP.log
	* PastDatabase.cfg
	...
```


### Dependencies

* [Firespitter](https://github.com/snjo/Firespitter/releases) (or Firespitter Core)
	+ Hard Dependency - parts will not work without it.
	+ Not Included
* Module Manager 3.1.3 or later
	+ Soft dependency - it's possible to play without it, besides having less features available.
	+ Not Included
