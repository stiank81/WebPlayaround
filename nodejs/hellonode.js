var http = require('http');
http.createServer(function (req, res) {
  res.writeHead(200, {'Content-Type': 'text/plain'});
  res.end('<div style="background: red"><h1>Hello Node!</h1></div>\n');
}).listen(1337, '127.0.0.1');
console.log('Server running at http://127.0.0.1:1337/');