var express = require('express');
var exphbs = require('express-handlebars');
var path = require('path');
var favicon = require('serve-favicon');
var logger = require('morgan');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');

var port = process.env.PORT || 3000;
var config = require('./lib/configLoader');    
var db = require('./lib/database');

var routes = require('./routes/index');
var app = express();

// view engine setup
var hbs = exphbs.create({
    extname: '.hbs',
    defaultLayout: 'masterLayout',
});
app.engine('hbs', hbs.engine);
app.set('view engine', 'hbs');
app.set('views', path.join(__dirname, 'views'));


app.use(favicon(__dirname + '/public/images/favicon.ico'));
app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

//Pass database config settings
db.init(config.databaseConfig);

app.use('/', routes);

// catch 404 and forward to error handler
app.use(function(req, res, next) {
  var err = new Error('Not Found');
  err.status = 404;
  next(err);
});

// error handlers

// development error handler
// will print stacktrace
if (app.get('env') === 'development') {
  app.use(function(err, req, res, next) {
    res.status(err.status || 500);
    res.render('error', {
      message: err.message,
      error: err
    });
  });
}

// production error handler
// no stacktraces leaked to user
app.use(function(err, req, res, next) {
  res.status(err.status || 500);
  res.render('error', {
    message: err.message,
    error: {}
  });
});

app.listen(port, function (err) {
    console.log('[%s] Listening on http://localhost:%d', app.settings.env, port);
});


//*********************************************************
//    Quick and dirty way to detect event loop blocking
//*********************************************************
var lastLoop = Date.now();

function monitorEventLoop() {
    var time = Date.now();
    if (time - lastLoop > 1000) console.error('Event loop blocked ' + (time - lastLoop));
    lastLoop = time;
    setTimeout(monitorEventLoop, 200);
}

if (process.env.NODE_ENV === 'development') {
    monitorEventLoop();
}



module.exports = app;
