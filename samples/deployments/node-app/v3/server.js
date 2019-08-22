const http = require('http'),
      os = require('os');

console.log("Node v3 server starting...");
var requestCount = 0;

var handler = function(request, response) {
  console.log("Request received from: " + request.connection.remoteAddress);
  if (++requestCount >= 5) {
    response.writeHead(500);
    response.end("Some internal error has occurred! This is pod " + os.hostname() + "\n");
    return;
  }
  response.end("Node v3 running in a pod: " + os.hostname() + "\n");
};

var www = http.createServer(handler);
www.listen(8080);