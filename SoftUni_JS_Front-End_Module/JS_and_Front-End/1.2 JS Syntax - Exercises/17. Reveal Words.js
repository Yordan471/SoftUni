function solve(wordsArr, text) {
  let arrayText = text.split(" ");
  let arrayWords = wordsArr.split(", ");

  for (let i = 0; i < arrayWords.length; i++) {
    for (let index = 0; index < arrayText.length; index++) {
      if (
        arrayWords[i].length === arrayText[index].length &&
        arrayText[index].includes("*")
      ) {
        arrayText[index] = arrayWords[i];
      }
    }
  }

  console.log(arrayText.join(" "));
}

solve("great", "softuni is ***** place for learning new programming languages");
solve(
  "great, learning",
  "softuni is ***** place for ******** new programming languages"
);
