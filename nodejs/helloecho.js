var net = require('net');

var server = net.createServer(function (socket) {
  socket.write('Echo server\r\n');
  
  socket.on('data', function (data) { 
	socket.write(data);
  });
});

server.listen(1337, '127.0.0.1');