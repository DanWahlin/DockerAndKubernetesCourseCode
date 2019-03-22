** Generate a self-signing cert: **

https://devcenter.heroku.com/articles/ssl-certificate-self

openssl genrsa -des3 -passout pass:x -out server.pass.key 2048
openssl rsa -passin pass:x -in server.pass.key -out server.key
rm server.pass.key
openssl req -new -key server.key -out server.csr
openssl x509 -req -days 365 -in server.csr -signkey server.key -out server.crt

** Registering cert with nginx **

http://dracoblue.net/dev/https-nginx-with-self-signed-ssl-certificate/

** To look at certificate details **

openssl x509 -noout -text -in server.crt

** How to view hosts IPs on OSX **

dscacheutil -q host -a name cwd
