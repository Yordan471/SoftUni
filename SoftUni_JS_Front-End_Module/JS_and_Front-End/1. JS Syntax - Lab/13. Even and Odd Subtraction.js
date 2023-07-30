function solve(input) {
    let even = 0;
    let odd = 0;

    for (let index = 0; index < input.length; index++) {
        if (input[index] % 2 === 0) {
            even += input[index];
        }
        else {
            odd += input[index];
        }
    }

    let output = even - odd;
    console.log(output);
}

solve([1,2,3,4,5,6]);
solve([3,5,7,9]);