#!/bin/bash

if [ -z "$NODE_ENV" ]; then
    export NODE_ENV=development
fi

cd /var/www/codewithdan

pm2 start -x server.js --name="codewithdan" --no-daemon --watch
