var re = /ab+c/;  // 다른 표현 >> var re = new RegExp("ab+c");

var myRe = new RegExp("d(b+)d", "g");
var myArray = myRe.exec("dbdbbbdsbzcdbbdbdbbbdsbz");

console.log(myRe.lastIndex);
