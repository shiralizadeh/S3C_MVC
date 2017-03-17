var i = 0;
var str = 'This is a test';
var j = 1.5;
var isTrue = false;

console.log(i);
i++;
console.log(i);

for (var w = 0; w < 100; w++) {
    console.log(w);
}

switch (i) {
    case 1:
        break;
    default:
        break;
}

if (i == 1) {
    console.log('i is one');
}

var product = {
    ID: 1,
    Title: 'عنوان محصول',
    Count: 10
};

product.Title = 'asdsadsad';
product.User = 'sdfsdfsdf';
product.AddCount = function () {
    product.Count++;
}

for (var item in product) {
    console.log(item);
}

product.AddCount();
console.log(product.Count);


var product2 = new Object();
product2.ID = 12;
product2.Title = 'test';

var array = [1, 2, 4, 'dsfsdfsd', product];
var array = new Array();
array.push(1);
array.push(2);
array.push(4);
array.push('dasfas');

var fu = function (i, j) {
    return i + j;
};

fu(1, 2);

function CaclcAvg(a, b, c, d) {
    return (a + b + c + d) / 4;
}

CaclcAvg(1, 5, 10, 2);

//function _() {

//}

//function $() {

//}