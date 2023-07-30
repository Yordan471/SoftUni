function sum(numOne, numTwo) {
    return numOne + numTwo;
}

function subtract(numOne, numTwo, numThree) {
    const output = sum(numOne, numTwo) - numThree;

    return output;
}

subtract(23, 6, 10);