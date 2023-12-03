const { expect } = require("chai");
const { lookupChar } = require("../script")

describe(`LookUpChar_String`, () => {
    it(`NumbersAreBad`, () => {
        let input = 3;
        let result = lookupChar(input,3)
        expect(result).to.be.equal(undefined)
    })

    it(`BooleanIsNotWelcome`, () => {
        let input = true;
        let result = lookupChar(input,2)
        expect(result).to.be.equal(undefined)
       
    })

    it(`NullIsBad`, () => {
        let input = null;
        let result = lookupChar(input,7)
        expect(result).to.be.equal(undefined)

    })
    it(`UndefinedIsBad`, () => {
        let input = undefined;
        let result = lookupChar(input,2)
        expect(result).to.be.equal(undefined)
    })
})




describe(`LookUpChar_Index`, () => {
    it(`StringsAreBad`, () => {
        let input = 'g';
        let result = lookupChar(`ggf`,input)
        expect(result).to.be.equal(undefined)
    })

    it(`BooleanIsNotWelcome`, () => {
        let input = true;
        let result = lookupChar(`ggf`,input)
        expect(result).to.be.equal(undefined)
       
    })

    it(`NullIsBad`, () => {
        let input = null;
        let result = lookupChar(`ggf`,input)
        expect(result).to.be.equal(undefined)

    })
    it(`UndefinedIsBad`, () => {
        let input = undefined;
        let result = lookupChar(`ggf`,input)
        expect(result).to.be.equal(undefined)
    })
})

describe(`LookUpChar_IncorrectIndex`, () => {
    it(`biggerIndex`, () => {
        let input = 24;
        let result = lookupChar(`Skillet`, input)
        expect(result).to.be.equal("Incorrect index")
    })

    it(`indexWithStringLength`, () => {
        let input = 5;
        let result = lookupChar(`Joder`,input)
        expect(result).to.be.equal("Incorrect index")

    })

    it(`NegativeIndex`, () => {
        let input = -3;
        let result = lookupChar(`Bulgaria`,input)
        expect(result).to.be.equal("Incorrect index")


    })
    it(`UndefinedIsBad`,() => {
        let input = undefined;
        let result = lookupChar(`Bulgaria`,input)
        expect(result).to.be.equal(undefined)

    })
})


describe(`LookUpChar_Possitive-Outcome`, () => {
    it(`RightInputWorks`, () => {
        let string = `Kotka`;
        let index = 2;
        let result = lookupChar(string,index)
        expect(result).to.be.equal(`t`)
    })
})


