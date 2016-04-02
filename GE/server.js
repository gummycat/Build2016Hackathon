var port = process.env.port || 1337;
var server = require('http').createServer();
var io = require('socket.io')(server);

io.on('connection', function (socket) {
    console.log('Connection Found!');
    socket.on('event', processEvent);
    socket.on('message', function (message) {
        console.log("Message: " + message);
    })
    socket.on('disconnect', function () {
        console.log('Disconnected!');
    })
});

server.listen(port);
console.log("server is listening");