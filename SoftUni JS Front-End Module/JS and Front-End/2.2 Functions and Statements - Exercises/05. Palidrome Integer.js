function PalidromeOrNot(numbers) {
    for (let index = 0; index < numbers.length; index++) {
        let reverseNumber = numbers[index]
        .toString()
        .split('')
        .reverse()
        .join('');

        if (numbers[index] === parseInt(reverseNumber)) {
            console.log(true);
        }
        else {
            console.log(false);
        }
    }
}

PalidromeOrNot([123, 323, 421, 121]);