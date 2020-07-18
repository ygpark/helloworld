
/**
 * Module dependencies.
 */

var express = require('express');
var routes = require('./routes');
var user = require('./routes/user');
var untitled = require('./routes/untitled');
var http = require('http');
var path = require('path');

var app = express();

// all environments
app.set('port', process.env.PORT || 3000);
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'ejs');
app.use(express.favicon());
app.use(express.logger('dev'));
app.use(express.json());
app.use(express.urlencoded());
app.use(express.methodOverride());
app.use(app.router);
app.use(express.static(path.join(__dirname, 'public')));

// development only
if ('development' == app.get('env')) {
  app.use(express.errorHandler());
}

app.get('/', routes.index);
app.get('/untitled', untitled.get);
app.post('/untitled', untitled.post);
//app.post('/untitled', routes.untitled)
//{
    //// var templateId = data.templateId;
    //// opt파일을 손으로 열어서
    //// if (opt가 메모리에 없으면)
    ////   Template tom = OptParser::paser(opt file path);
    //// fi
    //// Template tom = OptParser::paser(opt file);
    //// Template tom = ehr.getTemplate(templateId);
    //// var result = ehr.buildcomposition(data, tom).tostring();
    //// console.log(result);
//}
app.get('/users', user.list);

http.createServer(app).listen(app.get('port'), function(){
  //ehr.init();
  console.log('Express server listening on port ' + app.get('port'));
});
