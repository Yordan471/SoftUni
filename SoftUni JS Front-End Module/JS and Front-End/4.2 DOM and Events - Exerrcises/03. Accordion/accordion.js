function toggle() {
    const button = document.querySelector(".button");
    const content = document.querySelector("#extra");

    button.textContent = button.textContent === "More" ? "Less" : "More";
    content.style.display = content.style.display === "block" ? "none" : "block";
}