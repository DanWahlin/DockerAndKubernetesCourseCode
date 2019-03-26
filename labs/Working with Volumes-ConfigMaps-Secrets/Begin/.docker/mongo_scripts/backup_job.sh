#!/bin/bash
# Backup MongoDB

ROOT_USER=${MONGODB_ROOT_USERNAME}
ROOT_PASS=${MONGODB_ROOT_PASSWORD}
DB=${MONGODB_DBNAME}
BACKUP_FOLDER=/opt/backup/`date +"%Y_%m_%d__"`$DB

echo "Backing up $DB to $BACKUP_FOLDER"
/usr/bin/mongodump  --port 27017 -u $ROOT_USER -p $ROOT_PASS -d $DB --oplog -o $BACKUP_FOLDER

