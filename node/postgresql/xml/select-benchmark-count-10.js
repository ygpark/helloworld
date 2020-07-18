//var fs = require('util');
var fs = require('fs');
var pg = require('pg');
//or native libpq bindings
//var pg = require('pg').native


// PostgreSQL
var conString = "postgres://postgres:123@localhost/postgres";
var xdata = fs.readFileSync('data/composition.xml', 'utf-8');

// 시간측정
var max = 10;
var count = 0;


/**
 * @brief Database의 Table을 타겟으로 XQuery하기
 *
 */
function test1()
{

    var client = new pg.Client(conString);
    client.connect(function(err) {
        if(err) {
            return console.error('could not connect to postgres', err);
        }

        var keyword = "NOUSCO-100";

        var query = "SELECT * " +
                    "   FROM xml_table" +
                    "   WHERE (xpath('/ns:data/ns:content[@archetype_node_id=\"at0006\"]/ns:name/ns:value/text()', " +
                    "       xdata, " +
                    "       ARRAY[ARRAY['ns', 'http://schemas.openehr.org/v1']]))[1]::text = '" + keyword + "'";

        console.time("query");
        for(i=0; i<max; i++)
        {
            client.query(query, function(err, result) {
                //console.log("--------------------------------------------------");
                //console.log("- Benchmark");
                //console.log("--------------------------------------------------");
                if(err) {
                    return console.error('error running query', err);
                }
                //console.log(result);
                //console.log(count);
                count++;
                if(count == max) {
                    console.log(count);
                    console.timeEnd("query");
                    client.end();
                }
            });
        }
    });
}

test1();



