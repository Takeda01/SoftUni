const { expect } = require("chai")
const { mathEnforcer } = require("../script")

describe(`mathEnforcer`, () =>{
    describe(`addfive`,() => {
        it(`NonNumIsUnacceptable`, () => {
         let result =   mathEnforcer.addFive(`strike`)
         expect(result).to.be.equal(undefined)
         it(`addFive_ShouldWork_Successfully2`, () => {          
            let number = 0.05;          
            let result = mathEnforcer.addFive(number);
            expect(result).to.be.closeTo(5.05, 0.01);
        })

        })
        it(`UndefinedIsUnacceptable`, () =>{
            let result =   mathEnforcer.addFive(undefined)
         expect(result).to.be.equal(undefined)
        })
        it(`NullIsUnacceptable`, () =>{
            let result =   mathEnforcer.addFive(null)
         expect(result).to.be.equal(undefined)
        })
        it(`NumberInputIsValid`, () =>{
        let result = mathEnforcer.addFive(5)
         expect(result).to.be.equal(10)
        })
        it(`AddFiveWorksWithFloat`, () =>  {
            let result = mathEnforcer.addFive(0.05)
            expect(result).to.be.closeTo(5.05,0,01)
        })
        it(`AddFiveWorksWithNegativeVlues`, () => {
            let result = mathEnforcer.addFive(-9)
            expect(result).to.be.equal(-4)
        })
      

    })


    describe(`subtractTen`, () => {
        it(`NonNumIsUnacceptable-10`, () => {
            let result =   mathEnforcer.subtractTen(`strike`)
            expect(result).to.be.equal(undefined)
   
           })
           it(`UndefinedIsUnacceptable+-10`, () =>{
               let result =   mathEnforcer.subtractTen(undefined)
            expect(result).to.be.equal(undefined)
           })
           it(`NullIsUnacceptable-10`, () =>{
               let result =   mathEnforcer.subtractTen(null)
            expect(result).to.be.equal(undefined)
           })
           it(`NumberInputIsValid-10`, () =>{
           let result = mathEnforcer.subtractTen(15)
            expect(result).to.be.equal(5)
           })
           it(`SubtractTenWorksWithFloat`, () => {
            let result = mathEnforcer.subtractTen(15.05)
            expect(result).to.be.closeTo(5.05, 0.01);
           })
           it(`SubtractTenWorksWithNegativeValues`, () => {
            let result = mathEnforcer.subtractTen(-10)
            expect(result).to.be.equal(-20)
           })

           

    })

    describe(`sum`, () => {
        it(`NonNumIsUnacceptableFirst`, () => {
            let result =   mathEnforcer.sum(`strike`,5)
            expect(result).to.be.equal(undefined)
   
           })
           it(`UndefinedIsUnacceptableFirst`, () =>{
               let result =   mathEnforcer.sum(undefined,5)
            expect(result).to.be.equal(undefined)
           })
           it(`NullIsUnacceptableFirst`, () =>{
               let result =   mathEnforcer.sum(null,5)
            expect(result).to.be.equal(undefined)
           })




           it(`NonNumIsUnacceptableSecond`, () => {
            let result =   mathEnforcer.sum(5,`strike`)
            expect(result).to.be.equal(undefined)
   
           })
           it(`UndefinedIsUnacceptable`, () =>{
               let result =   mathEnforcer.sum(5,undefined)
            expect(result).to.be.equal(undefined)
           })
           it(`NullIsUnacceptable`, () =>{
               let result =   mathEnforcer.sum(5,null)
            expect(result).to.be.equal(undefined)
           })
           
          it(`SumWorksWithNumbers`, () => {
            let result =   mathEnforcer.sum(5,6)
            expect(result).to.be.equal(11)
          })
          it(`SumWorksWithFloat`, () => {
            let result = mathEnforcer.sum(5, 0.5)
            expect(result).to.equal(5.5,0.01)
          })

          it(`SumWorksWithNegative`, () => {
            let result = mathEnforcer.sum(-5,-1)
            expect(result).to.equal(-6)
          })
    })
})