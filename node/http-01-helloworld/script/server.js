var http = require('http');
var fs = require('fs');
var ejs = require('ejs');

http.createServer(function (req, res) {
    fs.readFile('index.html', 'utf8', function(error, data) {
        res.writeHead(200, {'Content-Type': 'text/html'});
        res.end(ejs.render(data));
        //res.end('');
    });
}).listen(8080, function() {
    console.log("Server Running at http://localhost:8080");
});
