FROM node:alpine

LABEL author="Dan Wahlin"

WORKDIR /var/www/codewithdan

RUN npm install -g pm2@latest

RUN mkdir -p /var/log/pm2

EXPOSE 		8080

ENTRYPOINT ["pm2", "start", "server.js","--name","codewithdan","--log","/var/log/pm2/pm2.log","--watch","--no-daemon"]


# To build:
# docker build -f docker-node-codewithdan.dockerfile --tag codewithdan_node ../

# To run:
# docker run -d -p 8080:8080 -v $(PWD):/var/www/codewithdan -w /var/www/codewithdan codewithdan_node
# docker run -d -p 8080:8080 --name codewithdan_node codewithdan_node 
