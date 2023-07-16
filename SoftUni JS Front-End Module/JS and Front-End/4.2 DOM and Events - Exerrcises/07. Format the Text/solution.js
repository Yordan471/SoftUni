function solve() {
  const textAreaContent = document.querySelector("#input").value.split(".");
  textAreaContent.pop();


  while (textAreaContent.length > 0) {
    const p = document.createElement("p");
    p.textContent = textAreaContent
      .splice(0, 3)
      .map((text) => text.trim())
      .join(".");

      p.textContent += ".";
    document.querySelector("#output").appendChild(p);
  }
}
