#!/bin/bash
# https://github.com/frodenas/docker-mongodb/blob/master/Dockerfile

# Initialize first run
if [[ -e /.firstrun ]]; then
    echo "Running entrypoint.sh"
    /mongo_scripts/entrypoint.sh
    
        
    echo "Scheduling backup CRON job for 13:00"
    cat <(crontab -l) <(echo "00 13 * * * /mongo_scripts/backup_job.sh") | crontab -
    
    echo "Scheduling backup CRON job for 1:00"
    cat <(crontab -l) <(echo "00 01 * * * /mongo_scripts/backup_job.sh") | crontab -
    
    # * * * * * CRON job time to be executed
    # - - - - -
    # | | | | |
    # | | | | ----- Day of week (0 - 7) (Sunday=0 or 7)
    # | | | ------- Month (1 - 12)
    # | | --------- Day of month (1 - 31)
    # | ----------- Hour (0 - 23)
    # ------------- Minute (0 - 59)

    
    echo "Running first_run.sh"
    /mongo_scripts/first_run.sh
fi

# Start MongoDB
echo "Starting MongoDB..."
/usr/bin/mongod --auth --bind_ip_all $@