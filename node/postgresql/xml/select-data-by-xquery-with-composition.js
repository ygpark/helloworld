var fs = require('fs');
var pg = require('pg');
//or native libpq bindings
//var pg = require('pg').native

var conString = "postgres://postgres:123@localhost/postgres";
var xdata = fs.readFileSync('data/composition.xml', 'utf-8');

/**
 * @brief XML형식의 파일을 타겟으로 XQuery하기
 *
 */
function test1()
{
    var client = new pg.Client(conString);
    client.connect(function(err) {
        if(err) {
            return console.error('could not connect to postgres', err);
        }
        var query = "SELECT (xpath('//mydefns:terminology_id', " +
                            "'" + xdata + "', " +
                            "ARRAY[ARRAY['mydefns', 'http://schemas.openehr.org/v1']])); ";

        client.query(query, function(err, result) {
            console.log("--------------------------------------------------");
            console.log("- test1: XML형식의 파일을 타겟으로 XQuery하기");
            console.log("--------------------------------------------------");
            if(err) {
                return console.error('error running query', err);
            }
            console.log(result);
            client.end();
        });
    });
}

/**
 * @brief Database의 Table을 타겟으로 XQuery하기
 *
 */
function test2()
{
    var client = new pg.Client(conString);
    client.connect(function(err) {
        if(err) {
            return console.error('could not connect to postgres', err);
        }
        var query = "SELECT (xpath('//mydefns:terminology_id', " +
                            "xdata, " +
                            "ARRAY[ARRAY['mydefns', 'http://schemas.openehr.org/v1']]))" +
                        "FROM xml_table;";

        client.query(query, function(err, result) {
            console.log("--------------------------------------------------");
            console.log("- test2: Database의 Table을 타겟으로 XQuery하기");
            console.log("--------------------------------------------------");
            if(err) {
                return console.error('error running query', err);
            }
            console.log(result);
            client.end();
        });
    });
}

test1();
test2();
