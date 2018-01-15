module.exports = class Vector {
    constructor(x, y) {
        if (x)
            this.x = x;
        this.y = y;
    }

    static fromArray(array) {
        return new Vector(array[0], array[1]);
    }
}