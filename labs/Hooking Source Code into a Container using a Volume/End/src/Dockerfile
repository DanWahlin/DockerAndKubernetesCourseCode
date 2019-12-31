FROM        nginx:alpine
LABEL       author="Your Name"
WORKDIR     /usr/share/nginx/html
COPY        . /usr/share/nginx/html

# Could do "COPY . ." as well since working directory is set

EXPOSE      80
CMD         ["nginx", "-g", "daemon off;"]

# Run using: docker run –d -p 8080:80 -v [currentWorkingDirectory]:/usr/share/nginx/html nginx:alpine
