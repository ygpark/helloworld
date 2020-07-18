exports.timer = new process.EventEmitter();

setInterval(function(){
    //tick이벤트 발생
    exports.timer.emit('tick');
}, 1000);
