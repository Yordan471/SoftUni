function solve(word, text) {
    let arrayText = text.split(' ').map(word => word.toLowerCase());
    let lowerWord = word.toLowerCase();
    if (arrayText.includes(lowerWord)) {
        console.log(word);
    }
    else {
        console.log(`${word} not found!`);
    }
}

solve('javascript', 'JavaScript is the best programming language');
solve('python', 'JavaScript is the best programming language');