var fs = require('fs');
var pg = require('pg');
//or native libpq bindings
//var pg = require('pg').native

var conString = "postgres://postgres:123@localhost/postgres";

/**
 * @brief 네임스페이스가 있는 경우
 *
 * XML 형식:
 *      <my:a xmlns:my="http://example.com">
 *          test
 *      </my:a>
 *
 * @return
 */
function test1()
{
    var client = new pg.Client(conString);

    client.connect(function(err) {
        if(err) {
            return console.error('could not connect to postgres', err);
        }

        var query = "SELECT xpath('/my:a/text()', " +
                                    "'<my:a xmlns:my=\"http://example.com\">test</my:a>', " +
                                    "ARRAY[ARRAY['my', 'http://example.com']]);";

        client.query(query, function(err, result) {
            console.log("--------------test1--------------")
            if(err) {
                return console.error('error running query', err);
            }
            console.log(result);
            client.end();
        });
    });
}

/**
 * @brief 기본 네임스페이스가 있는 경우
 *
 * XML 형식:
 *      <a xmlns="http://example.com">
 *          test
 *      </a>
 *
 * @return
 */
function test2()
{
    var client = new pg.Client(conString);

    client.connect(function(err) {
        if(err) {
            return console.error('could not connect to postgres', err);
        }

        var query = "SELECT xpath('//mydefns:b/text()', " +
                                "'<a xmlns=\"http://example.com\"><b>test</b></a>', " +
                                    "ARRAY[ARRAY['mydefns', 'http://example.com']]);";

        client.query(query, function(err, result) {
            console.log("--------------test2--------------")
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

