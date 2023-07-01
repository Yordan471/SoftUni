function GetTheSmallestNumber(...numbers) {
    numbers = numbers.sort((a, b) => a - b);
    const smallestNum = numbers[0];  

    console.log(smallestNum);
}

GetTheSmallestNumber(2, 5, 3);