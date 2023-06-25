const { expect } = require("chai");
const { numberOperations } = require("./03. Number Operations_Resources (1)");

describe(`NumberOperations`, () => {
  describe(`PowNumber`, () => {
    it(`ItReturnsPowedNum`, () => {
      let result = numberOperations.powNumber(2);

      expect(result).equals(4);
    });

    it(`NegativeIsOk`, () => {
        let result = numberOperations.powNumber(-2);

      expect(result).equals(4);
    })
  });

  describe(`NumberChecker`, () => {
    it(`TheParserWorks`, () => {
      let result = numberOperations.numberChecker(`5`);

      expect(result).equals("The number is lower than 100!");
    });

    it(`GreaterString`, () => {
      let result = numberOperations.numberChecker(`120`);
      expect(result).equals("The number is greater or equal to 100!");
    });

    it(`LowNumbersWork`, () => {
      let result = numberOperations.numberChecker(6);
      expect(result).equals("The number is lower than 100!");
    });

    it(`GreaterNumbersWork`, () => {
      let result = numberOperations.numberChecker(100);
      expect(result).equals("The number is greater or equal to 100!");
    });
    it(`100StringIsOk`, () => {
        let result = numberOperations.numberChecker(`100`);
        expect(result).equals("The number is greater or equal to 100!");
      });
    

    it(`100IsoK`, () => {
        let result = numberOperations.numberChecker(120);
      expect(result).equals("The number is greater or equal to 100!");
    })

    it(`NegqativeInputWorks`,()=>{
        let result = numberOperations.numberChecker(-120);
        expect(result).equals("The number is lower than 100!");
    } )

    it(`NaNIsBad`, () => {
      try {
        numberOperations.numberChecker(NaN);
      } catch (error) {
        expect(error.message).equals("The input is not a number!");
      }
    });
    it(`UndefinedIsBad`, () => {
      try {
        numberOperations.numberChecker(undefined);
      } catch (error) {
        expect(error.message).equals("The input is not a number!");
      }
    });

    it(`BooleanIsBad`, () => {
      try {
        numberOperations.numberChecker(false);
      } catch (error) {
        expect(error.message).equals("The input is not a number!");
      }
    });

    it(`ArrayIsBad`, () => {
      try {
        numberOperations.numberChecker([]);
      } catch (error) {
        expect(error.message).equals("The input is not a number!");
      }
    });

    it(`ObjectIsBad`, () => {
      try {
        numberOperations.numberChecker({});
      } catch (error) {
        expect(error.message).equals("The input is not a number!");
      }
    });

    describe(`SumArrays`, () => {
      it(`SumArray`, () => {
        let result = numberOperations.sumArrays([1, 23, 4, 5, 6], [2, 3, 44]);
        
        expect(result).to.deep.equal([3, 26, 48, 5, 6]);
      });

      it(`LastIndexes`, () => {
        let result = numberOperations.sumArrays([1, 23, 4, 5, 6,1], [2, 3, 44,0,2]);
        expect(result[5]).equals(1)
      })
    });
  });
});
