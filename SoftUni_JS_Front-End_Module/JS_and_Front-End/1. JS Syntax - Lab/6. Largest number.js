function solve(...arr) {
    arr.sort(function(a, b) {
        return b - a;
    })

    console.log(`The largest number is ${arr[0]}.`);
}

solve(3, 10, 20, 4);