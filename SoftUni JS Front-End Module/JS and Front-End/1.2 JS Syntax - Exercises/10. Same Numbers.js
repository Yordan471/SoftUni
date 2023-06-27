function solve(number) {
    const strNumber = String(number);
    let isConsistent = true;

    for (let index = 1; index < strNumber.length; index++) {
        if (Number(strNumber[0]) !== Number(strNumber[index])) {
            isConsistent = false;
        }      
    }
    
    const array = strNumber.split('').map(Number);
    const sum = array.reduce((a, b) => a + b, 0);

    if (isConsistent) {
        console.log('true');
    }
    else {
        console.log(`false`);
    }

    console.log(sum);
}

solve(222222);
solve(211122);