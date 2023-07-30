function PrintCharactersInBetween(firstChar, secondChar) {
    let firstCharNumber = firstChar.charCodeAt();
    let secondCharNumber = secondChar.charCodeAt();
    let numArray = [firstCharNumber, secondCharNumber].sort((a, b) => a - b);
    let charArray = [];

    for (let index = numArray[0]; index < numArray[1] - 1; index++) {
        charArray.push(String.fromCharCode(index + 1));
    }

    const output = charArray.join(' ');

    console.log(output);
}

PrintCharactersInBetween('C', '#');