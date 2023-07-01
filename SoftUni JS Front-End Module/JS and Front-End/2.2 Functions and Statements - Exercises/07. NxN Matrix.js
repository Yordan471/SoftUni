function solve(number) {
    for (let firstIndex = 0; firstIndex < number; firstIndex++) {
        let matrix = '';

        for (let secondIndex = 0; secondIndex < number; secondIndex++) {
            matrix += `${number.toString()} `;     
        }

        console.log(matrix);
    }
}

solve(3);