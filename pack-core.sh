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
FILE=${pwd}/Archive/${PACKAGE}Core-$VERSION${PROJECT_STATE}.zip
echo $FILE
clean
cp ./AirplanePlusCore.version ./GameData/AirplanePlus/
zip $FILE ./GameData/AirplanePlus/AirplanePlusCore.version -x ".*"
rm  ./GameData/AirplanePlus/AirplanePlusCore.version

zip $FILE ./GameData/AirplanePlus/LICENSE.* -x ".*"
zip $FILE ./GameData/AirplanePlus/NOTICE -x ".*"
zip $FILE ./GameData/AirplanePlus/README.md -x ".*"
zip $FILE ./GameData/AirplanePlus/KNOWN_ISSUES.md -x ".*"
zip $FILE ./GameData/AirplanePlus/Plugins/* -x ".*"
#zip -r $FILE ./PluginData/* -x ".*"
#zip -r $FILE ./Extras/* -x ".*"
zip $FILE INSTALL.md
zip -d $FILE "__MACOSX/*" "**/.DS_Store"
cd $pwd
