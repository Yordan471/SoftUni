function addItem() {
    const value = document.getElementById("newItemText").value;
    const element = document.createElement("li");

    element.textContent = value;

    document.getElementById("items").appendChild(element);
}