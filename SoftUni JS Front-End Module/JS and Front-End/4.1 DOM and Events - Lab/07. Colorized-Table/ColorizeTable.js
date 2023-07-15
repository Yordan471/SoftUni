function colorize() {
    const evenElements = Array.from(document.querySelectorAll("tr:nth-child(even)"));
    evenElements.forEach((element) => {
        element.style.background = "teal";
    });
}