var net = require('net');

var sockets = []; 

var server = net.createServer(function (socket) {
	sockets.push(socket);
	socket.on('data', function(d) {
		for (var i = 0; i < sockets.length; i++) {
			if (sockets[i] == socket) continue; 
			sockets[i].write(d); 
		}
	});
	
	socket.on('end', function() {
		var i = sockets.indexOf(socket); 
		sockets.splice(i, 1); 
	});
});

server.listen(1337, '127.0.0.1');