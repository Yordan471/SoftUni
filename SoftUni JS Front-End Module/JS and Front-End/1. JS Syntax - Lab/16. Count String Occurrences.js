function solve(text, word) {
    let countWord = 0;

    let array = text.split(' ');
    for (let index = 0; index < array.length; index++) {
        if (array[index] === 'is')
        {
            countWord++;
        }       
    }

    console.log(countWord);
}

solve('This is a word and it also is a sentence','is');