function solve(number) {
    if (number === 100) {
        console.log('100% Complete!');
        return;
    }

    const firstDigit = parseInt(number / 10);
    const prcntgSymbol = '%'.repeat(firstDigit);
    const dots = '.'.repeat(10 - firstDigit);

    console.log(`${number}% [${prcntgSymbol}${dots}]`);
}

solve(30);
solve(50);
solve(100);