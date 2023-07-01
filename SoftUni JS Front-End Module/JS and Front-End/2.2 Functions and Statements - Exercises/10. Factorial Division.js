function solve(firstNum, secondNum) {
    let factorialFirstNum = 1;

    for (let index = 1; index <= firstNum; index++) {
        factorialFirstNum *= index; 
    }

    let factorialSecondNum = 1;

    for (let index = 1; index <= secondNum; index++) {
        factorialSecondNum *= index;
    }

    const output = factorialFirstNum / factorialSecondNum;

    console.log(`${output.toFixed(2)}`);
}

solve(5, 2);
solve(6, 2);
