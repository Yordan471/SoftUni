function solve(numArr, rotations) {
    for (let rotation = 0; rotation < rotations; rotation++) {
        let number = numArr.shift();
        numArr.splice(numArr.length, 0, number);
    }

    let output = numArr.join(' ');
    console.log(output);
}

solve([51, 47, 32, 61, 21], 2);
solve([32, 21, 61, 1], 4);