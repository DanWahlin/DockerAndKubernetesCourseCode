const http = require('http'),
      os = require('os');

console.log("Node v2 server starting...");
var requestCount = 0;

var handler = function(request, response) {
  console.log("Request received from: " + request.connection.remoteAddress);
  if (++requestCount >= 10) {
    response.writeHead(500);
    response.end("Internal error occurred! This is pod: " + os.hostname() + "\n");
    return;
  }
  response.end("Node v2 running in a pod: " + os.hostname() + "\n");
};

var www = http.createServer(handler);
www.listen(8080);
