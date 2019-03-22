FROM nginx:alpine

LABEL author="Dan Wahlin"

VOLUME /var/cache/nginx

# Copy custom nginx config
COPY ./.docker/config/nginx.development.conf /etc/nginx/nginx.conf

# Copy custom nginx config
COPY ./public /var/www/public

# Copy self-signing cert: https://devcenter.heroku.com/articles/ssl-certificate-self
COPY ./.certs/server.crt    /etc/nginx/server.crt
COPY ./.certs/server.key    /etc/nginx/server.key

# Copy DHE handshake and dhparam https://bjornjohansen.no/optimizing-https-nginx
COPY ./.certs/dhparam.pem   /etc/nginx/dhparam.pem

# Make cert key only available to owner (root)
RUN chmod 600 /etc/nginx/server.key

EXPOSE 80 443

ENTRYPOINT ["nginx"]
CMD ["-g", "daemon off;"]

# To build:
# docker build -f docker-nginx.dockerfile --tag danwahlin/nginx ../

# To run: 
# docker run -d -p 80:6379 --name nginx danwahlin/nginx