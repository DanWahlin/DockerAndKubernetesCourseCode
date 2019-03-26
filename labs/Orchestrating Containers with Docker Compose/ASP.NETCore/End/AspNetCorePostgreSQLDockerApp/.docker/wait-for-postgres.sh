#!/bin/bash

set -e

host="$1"
shift
cmd="$@"

until psql -h "$host" -U "postgres" -c '\l'; do
  >&2 echo "Postgres is unavailable - sleeping"
  sleep 1
done

>&2 echo "Postgres is up - executing command"
exec $cmd

#Can call from docker-compose.yml by adding the following to dependent service    entrypoint: ./.docker/wait-for-postgres.sh postgres:5432