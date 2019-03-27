FROM        nginx:alpine
LABEL       author="Your Name"
WORKDIR     /usr/share/nginx/html
COPY        . /usr/share/nginx/html

# Could do "COPY . ." as well since working directory is set

EXPOSE      80
CMD         ["nginx", "-g", "daemon off;"]