#!/bin/bash
APP_ENV=${APP_ENV}

configFile=/etc/redis.$APP_ENV.conf

if [[ -r $configFile ]] ; then
     . "$configFile"
else
     echo "configFile not found or not readable."
     exit 1
fi

#for testing only:
echo "$name"
echo "$pass"