function solve(number) {
    let sumDivisors = 0;

    for (let index = 1; index <= number / 2; index++) {
        if (number % index === 0) {
            sumDivisors += index;
        }
    }

    if (number === sumDivisors) {
        console.log('We have a perfect number!');
    }
    else {
        console.log("It's not so perfect.");
    }
}

solve(6);
solve(28);
solve(1236498);