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
VERSIONFILE="${PACKAGE}Classic.version"
VERSION=$( cat $VERSIONFILE | tr '\n' ' ' | sed -n -E 's/^.*?"VERSION\":\{.*"MAJOR":([0-9]+?),.*?"MINOR":([0-9]+?),.*?"PATCH":([0-9]+?),.*?"BUILD":([0-9]+?).*?\}.*$/\1.\2.\3.\4/p' )
FILE=${pwd}/Archive/${PACKAGE}Classic-$VERSION${PROJECT_STATE}.zip
clean
cp $VERSIONFILE ./GameData/AirplanePlusClassic/
zip -r $FILE ./GameData/AirplanePlusClassic* -x ".*"
#zip -r $FILE ./PluginData/* -x ".*"
#zip -r $FILE ./Extras/* -x ".*"
zip $FILE INSTALL.md
zip -d $FILE "__MACOSX/*" "**/.DS_Store"
cd $pwd
