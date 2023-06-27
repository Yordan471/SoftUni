function solve(startNum, endNum) {
    let output = 0;
    let string = '';
    for (let number = startNum; number <= endNum; number++) {
        output += number;
        string += `${number} `;
    }
    
    console.log(string);
    console.log(`Sum: ${output}`);
}

solve(5, 10);
solve(0, 26);