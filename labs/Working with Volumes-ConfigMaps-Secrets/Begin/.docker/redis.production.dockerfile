FROM 		redis:latest

LABEL author="Dan Wahlin"

COPY        ./.docker/config/redis.production.conf /etc/redis.conf

EXPOSE      6379

ENTRYPOINT  ["redis-server", "/etc/redis.conf"]

# To build:
# docker build -f docker-redis.dockerfile --tag danwahlin/redis ../

# To run:
# docker run -d -p 6379:6379 --name redis danwahlin/redis