

function solve(words) {
    const name = words.shift();
    let countTries = 0;
    const reversedName = name.split('').reverse().join('');
    
    while (reversedName !== words[0]) {
        countTries++;

        if (countTries === 4) {
            console.log(`User ${name} blocked!`);
            return;
        }

        console.log(`Incorrect password. Try again.`);
        words.shift();
    }

    console.log(`User ${name} logged in.`)
}

solve(['Acer','login','go','let me in','recA']);
solve(['momo','omom']);
solve(['sunny','rainy','cloudy','sunny','not sunny']);