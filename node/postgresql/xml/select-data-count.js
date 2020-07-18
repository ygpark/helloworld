var fs = require('fs');
var pg = require('pg');
//or native libpq bindings
//var pg = require('pg').native

var conString = "postgres://postgres:123@localhost/postgres";
var xdata = fs.readFileSync('data/composition.xml', 'utf-8');

var client = new pg.Client(conString);
client.connect(function(err) {
    if(err) {
        return console.error('could not connect to postgres', err);
    }
    client.query('SELECT COUNT(*) FROM xml_table;', function(err, result) {
        if(err) {
            return console.error('error running query', err);
        }
        console.log(result);
        client.end();
    });
});

