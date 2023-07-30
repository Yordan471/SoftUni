function subtract() {
    const firstInput = document.getElementById("firstNumber").value;
    const secondInput = document.getElementById("secondNumber").value;

    const subtractNumbers = Number(firstInput) - Number(secondInput);

    document.getElementById("result").textContent = subtractNumbers;
}