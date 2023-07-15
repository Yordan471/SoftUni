function sumTable() {
    const prices = Array.from(document.querySelectorAll("td:nth-child(even)"));
    prices.pop();

    const sum = prices.reduce((acc, curr) => {
       return acc + Number(curr.textContent);
    }, 0);

    document.getElementById("sum").textContent = sum;
}