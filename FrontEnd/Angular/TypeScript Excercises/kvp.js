var KeyValuePair = /** @class */ (function () {
    function KeyValuePair() {
    }
    KeyValuePair.prototype.setKeyValue = function (a, b) {
        this.key = a;
        this.value = b;
    };
    KeyValuePair.prototype.display = function () {
        console.log("key:" + this.key);
        console.log("value:" + this.value);
    };
    return KeyValuePair;
}());
var kvp = new KeyValuePair();
kvp.setKeyValue(1, "Steve");
kvp.display();
