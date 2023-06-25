function solve(arrayOfNums) {
    arrayOfNums.sort((a, b) => a - b);
    let outputArray = [];
    let length = arrayOfNums.length;

    for (let index = 0; index < length; index++) {
        if (index % 2 === 0) {
            outputArray.push(arrayOfNums.shift());  
        }
        else {
            outputArray.push(arrayOfNums.pop());
        }    
    }

    console.log(outputArray);
}

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);