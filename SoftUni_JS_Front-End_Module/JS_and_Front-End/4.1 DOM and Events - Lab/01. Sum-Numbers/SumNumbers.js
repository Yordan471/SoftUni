function calc() {
    const numOneInput = document.getElementById('num1').value;
    const numTwoInput = document.getElementById('num2').value;

    const sum = Number(numOneInput) + Number(numTwoInput);

    document.getElementById('sum').value = sum;
}
