FROM        nginx:alpine
LABEL       author="Dan Wahlin"
WORKDIR     /usr/share/nginx/html
COPY        . .

EXPOSE      80
CMD         ["nginx", "-g", "daemon off;"]