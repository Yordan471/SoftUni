function solve(number, array) {
    let slicedArray = array.slice(0, number);
    let reversedArray = slicedArray.reverse();

    let output = '';

    for (let index = 0; index < reversedArray.length; index++) {
        
        output += ` ${reversedArray[index]}`;
    }

    console.log(output);
}

solve(3, [10, 20, 30, 40, 50]);