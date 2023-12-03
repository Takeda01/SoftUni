const { expect } = require("chai");
const { isOddOrEven } = require("../script")

describe(`isOddOrEven`, () => {
    it(`NumbersAreBad`, () => {
        let input = 3;
        let result = isOddOrEven(input)
        expect(result).to.be.equal(undefined)
    })

    it(`BooleanIsNotWelcome`, () => {
        let input = true;
        let result = isOddOrEven(input)
        expect(result).to.be.equal(undefined)
    })

    it(`NullIsBad`, () => {
        let input = null;
        let result = isOddOrEven(input)
        expect(result).to.be.equal(undefined)

    })
    it(`UndefinedIsBad`, () => {
        let input = undefined;
        let result = isOddOrEven(input)
        expect(result).to.be.equal(undefined)
    })

    




    it(`EvenLengthReturnsEven`,() => {
        let input = `Park`
        let result = isOddOrEven(input)
        expect(result).to.be.equal(`even`)
    })
    it(`OddLengthReturnsOdd`,() => {
        let input = `Skillet`
        let result = isOddOrEven(input)
        expect(result).to.be.equal(`odd`)
    })
})