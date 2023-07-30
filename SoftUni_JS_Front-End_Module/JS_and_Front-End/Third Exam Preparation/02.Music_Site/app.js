window.addEventListener("load", solve);

function solve() {
  const inputFields = {
    Genre: document.querySelector("#genre"),
    Name: document.querySelector("#name"),
    Author: document.querySelector("#author"),
    Date: document.querySelector("#date"),
  };

  addBtn = document.querySelector("#add-btn");

  addBtn.addEventListener("click", addSong);

  function addSong() {
    if (Object.values(inputFields).some((input) => input.value === "")) {
       console.log("BAD");
        return;
    }

    const div = createElement("div", null, ["hits-info"], null);
    const img = document.createElement("img");
    img.src =".../static/img/img.png";
    div.appendChild(img);
    createElement("h2", `Genre: ${inputFields.Genre}`, [], null, div);
    createElement("h2" `Name: ${inputFields.Name}`, [], null, div);
    createElement("h2", `Author: ${inputFields.Author}`, [], null, div);
    createElement("h3", `Date: ${inputFields.Date}`, [], null, div);
    createElement("button", "Save song", ["save-btn"], null, div);
    createElement("button", "Like song", ["like-btn"], null, div);
    createElement("button", "Delete song", ["delete-btn"], null, div);

    document.querySelector("#all-hits-container").appendChild(div);
  }

  function createElement(type, textContent, classes, id, parent) {
    const element = document.createElement(type);
    
    if (textContent) {
      element.textContent = textContent;
    }

    if (classes && classes.length > 0) {
      element.classList.add(...classes);
    }

    if (id) {
      element.setAttribute("id", id);
    }

    if (parent) {
      parent.appendChild(element);
    }

    return element;
  }
}
