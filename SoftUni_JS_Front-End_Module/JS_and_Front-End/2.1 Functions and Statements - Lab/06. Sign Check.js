function solve(numOne, numTwo, numThree) {
    const array = [numOne, numTwo, numThree];
    let counter = 0;

    for (let index = 0; index < array.length; index++) {
        if (array[index] < 0) {
            counter++;
        }
    }

    if (counter === 0 || counter === 2) {
        console.log(`Positive`);
    }
    else {
        console.log(`Negative`);
    }
}

solve(-6, -12, 14);
solve(-1, -2, -3);