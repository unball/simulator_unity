#!/bin/bash

# Remove tar.gz file if it exists
tarball="unball_simulator.tar.gz"
if [ -f "$tarball" ]
then
    echo "Removing Previous version of unball.tar.gz file"
    rm "unball_simulator.tar.gz"
fi

# Download latest version from Google Drive
wget -O "unball_simulator.tar.gz" "https://drive.google.com/uc?export=download&id=0BwlvQGynHcxZTTdPUnF3dGR0MlE"

# Ectract downloaded version, overwriting files
tar -xzf "unball_simulator.tar.gz" --overwrite
