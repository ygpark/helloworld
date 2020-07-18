var fs = require('fs');
var pg = require('pg');
//or native libpq bindings
//var pg = require('pg').native

var conString = "postgres://postgres:123@localhost/postgres";
var max=10000;
var count=0;

var client = new pg.Client(conString);
client.connect(function(err) {
    if(err) {
        return console.error('could not connect to postgres', err);
    }

    for(i=1; i<=max; i++)
    {
        var xdata = fs.readFileSync('data/composition-' + i + '.xml', 'utf-8');

        client.query('INSERT INTO xml_table(xdata) VALUES (\'' + xdata +'\');', function(err, result) {
            if(err) {
                return console.error('error running query', err);
            }


            count++;
            if(count >= max) {
                client.end();
            }
        });
    }
});


