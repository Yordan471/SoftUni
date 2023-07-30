function solve(num) {
    const array = ['A', 'T', 'C', 'G', 'T', 'T', 'A', 'G', 'G', 'G'];
    const copyArray = ['A', 'T', 'C', 'G', 'T', 'T', 'A', 'G', 'G', 'G'];
    let count = 1;

    for (let index = 0; index < num; index++) {
        if (count === 1) {
            console.log(`**${copyArray.shift()}${copyArray.shift()}**`)
        }
        else if (count === 2) {
            console.log(`*${copyArray.shift()}--${copyArray.shift()}*`);
        }
        else if (count === 3) {
            console.log(`${copyArray.shift()}----${copyArray.shift()}`);
        }  
    }
}

solve(4);