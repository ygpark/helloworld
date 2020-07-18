var rint = require('./rint');

rint.timer.on('tick', function(){
    console.log('emited tick event');
});
