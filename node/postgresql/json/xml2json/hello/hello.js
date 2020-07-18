var parser = require('xml2json');

var xml = "<foo>hello NOUSCO</foo>";
var json = parser.toJson(xml);

console.log(json);
