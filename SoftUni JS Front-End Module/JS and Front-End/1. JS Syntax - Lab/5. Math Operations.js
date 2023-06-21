function solve(firstNum, secondNum, operation) {
    let output = 0;

    switch (operation) {
        case '+':
            output = firstNum + secondNum;
            break;
        case '-':
            output = firstNum - secondNum;
            break;
        case '*':
            output = firstNum * secondNum;
            break;
        case '/':
            output = firstNum / secondNum;
            break;
        case '%':
            output = firstNum % secondNum;
            break;
        case '**':
            output = firstNum ** secondNum;
            break;
    }

    console.log(output);
}

solve(5, 10, '-');