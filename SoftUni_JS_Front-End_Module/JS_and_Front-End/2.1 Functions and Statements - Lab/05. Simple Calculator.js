const calculator = {
    multiply: (a, b) => a * b,
    divide: (a, b) => a / b,
    add: (a, b) => a + b,
    subtract: (a, b) => a - b,
};

function calculate(a, b, operator) {
    return calculator[operator](a, b);
}

const output = calculate(5, 5, `multiply`);
console.log(output);



