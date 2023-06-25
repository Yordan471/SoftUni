function solve(word, text) {
    let arrayText = text.split(' ').map(word => word.toLowerCase());
    word = word.toLowerCase();
    if (arrayText.includes(word)) {
        console.log(word);
    }
    else {
        console.log(`${word} not found!`);
    }
}

solve('javascript', 'JavaScript is the best programming language');
solve('python', 'JavaScript is the best programming language');