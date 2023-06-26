var Box = /** @class */ (function () {
    function Box() {
        this.arr = [];
    }
    Box.prototype.add = function (a) {
        this.arr.push(a);
    };
    Box.prototype.remove = function () {
        this.arr.pop();
    };
    Object.defineProperty(Box.prototype, "count", {
        get: function () {
            return this.arr.length;
        },
        enumerable: false,
        configurable: true
    });
    return Box;
}());
var box = new Box();
box.add("Pesho");
box.add("Gosho");
console.log(box.count);
box.remove();
console.log(box.count);
