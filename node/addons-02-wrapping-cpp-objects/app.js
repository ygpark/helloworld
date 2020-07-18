var addon = require('./build/Release/addon');

var obj = new addon.MyObject(10);
var obj = new addon.MyObject(10);


console.log( obj.plusOne() ); // 11
console.log( obj.plusOne() ); // 12
console.log( obj.plusOne() ); // 13
console.log( obj.minusOne() ); // 12
console.log( obj.minusOne() ); // 11


console.log( "string type: " + obj.getString() );
console.log( "  length: " + obj.getString().length );

console.log( "double type: " + obj.getDouble() );

console.log( "-----------------------------------");


var obj1 = addon.MyObject(10);
var obj1 = addon.MyObject(10);

console.log( obj1.plusOne() ); // 11
console.log( obj1.plusOne() ); // 12
console.log( obj1.plusOne() ); // 13
console.log( obj1.minusOne() ); // 12
console.log( obj1.minusOne() ); // 11


console.log( "string type: " + obj1.getString() );
console.log( "  length: " + obj1.getString().length );

console.log( "double type: " + obj1.getDouble() );



console.log( "-----------------------------------");
var obj2 = obj.getMyObject2();
console.log( obj2.plusOne() ); // 1
console.log( "-----------------------------------");
