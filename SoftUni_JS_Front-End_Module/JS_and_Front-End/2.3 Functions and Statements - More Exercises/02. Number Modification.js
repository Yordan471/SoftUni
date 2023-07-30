function solve(number) {
  const arrayOfNumbers = number.toString().split("").map(Number);

    while (arrayOfNumbers.reduce((sumTotal, currValue) => sumTotal + currValue, 0) /
    arrayOfNumbers.length < 5) {
        arrayOfNumbers.push(9);
        number += '9';
    }

    console.log(number);
}

solve(5835);
solve(101);
