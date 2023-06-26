function solve(firstNum, operator, secondNum) {
    let output = 0;

    switch (operator) {
        case '+':
            output = firstNum + secondNum;
            break;
        case '-':
            output = firstNum - secondNum;
            break;
        case '/':
            output = firstNum / secondNum;
            break;
        case '*':
            output = firstNum * secondNum;
            break;
    }
    
    console.log(output.toFixed(2));
}

solve(5, '+', 10);