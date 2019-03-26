FROM        node:alpine

MAINTAINER  Dan Wahlin

ENV         NODE_ENV=development 
WORKDIR     /var/www
COPY        . /var/www

RUN         npm install

EXPOSE      3000

ENTRYPOINT  ["npm", "start"]