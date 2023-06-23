function solve(number) {
    for (let index = 1; index <= 10; index++) {
        let multiplication = number * index;

        console.log(`${number} X ${index} = ${multiplication}`);      
    }
}

solve(5);
