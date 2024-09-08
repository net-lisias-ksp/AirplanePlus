#!/usr/bin/env bash

# see http://redsymbol.net/articles/unofficial-bash-strict-mode/
set -euo pipefail
IFS=$'\n\t'
source ./CONFIG.inc

clean() {
	rm -fR $FILE
	if [ ! -d Archive ] ; then
		mkdir Archive
	fi
}

pwd=$(pwd)
FILE=${pwd}/Archive/${PACKAGE}Experimental-$VERSION${PROJECT_STATE}.zip
clean
cat "GameData/AirplanePlus/AirplanePlus.version" | sed 's/"Airplane Plus \/L"/"Airplane Plus \/L Experimental"/g' > "GameData/AirplanePlusExperimental/AirplanePlusExperimental.version"
zip -r $FILE ./GameData/AirplanePlusExperimental* -x ".*"
#zip -r $FILE ./PluginData/* -x ".*"
#zip -r $FILE ./Extras/* -x ".*"
zip $FILE INSTALL.md
zip -d $FILE "__MACOSX/*" "**/.DS_Store"
cd $pwd
