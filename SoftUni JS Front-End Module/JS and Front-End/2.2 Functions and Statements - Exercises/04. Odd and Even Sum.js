function SumOddAndEvenNums(number) {
    let stringNum = number.toString().split('');
    let evenSum = 0;
    let oddSum = 0;

    for (let index = 0; index < stringNum.length; index++) {
        if (parseInt(stringNum[index]) % 2 === 0) {
            evenSum += parseInt(stringNum[index]);
        }
        else {
            oddSum += parseInt(stringNum[index]);
        }
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

SumOddAndEvenNums(1000435);