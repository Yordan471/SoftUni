function solve(number) {
    let sum = 0;
    const digits = String(number).split('').map(Number);
    sum = digits.reduce((partialSum, a) => partialSum + a, 0);
    

    console.log(sum);
}

solve(2345);