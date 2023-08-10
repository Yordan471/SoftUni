window.addEventListener("load", solve);

function solve() {
  const studenNameInput = document.querySelector("#student");
  const universityinput = document.querySelector("#university");
  const scoreInput = document.querySelector("#score");
  const nextButton = document.querySelector("#next-btn");
  const ulPreview = document.querySelector("#preview-list");
  const ulScholorship = document.querySelector("#candidates-list");

  nextButton.addEventListener("click", gettingInfo);

  function gettingInfo() {
    if (studenNameInput.value === '' ||
    universityinput.value === '' ||
    scoreInput.value === '') {
      return;
    }

    const liElement = createNewElement(
      "li",
      null,
      ["application"],
      null,
      ulPreview
    );
    const articleElement = createNewElement(
      "article",
      null,
      [],
      null,
      liElement
    );
    createNewElement("h4", studenNameInput.value, [], null, articleElement);
    createNewElement("p", `University: ${universityinput.value}`, [], null, articleElement);
    createNewElement(
      "p",
      `Score: ${scoreInput.value}`,
      [],
      null,
      articleElement
    );
    createNewElement("button", "edit", ["action-btn", "edit"], null, liElement);
    createNewElement(
      "button",
      "apply",
      ["action-btn", "apply"],
      null,
      liElement
    );

    nextButton.disabled = true;

    let studentName = studenNameInput.value;
    let universityName = universityinput.value;
    let score = scoreInput.value;

    studenNameInput.value = "";
    universityinput.value = "";
    scoreInput.value = "";

    const editBtn = document.querySelector(".edit");

    editBtn.addEventListener("click", editInfo);

    function editInfo() {
      studenNameInput.value = studentName;
      universityinput.value = universityName;
      scoreInput.value = score;

      const removeLiElement = document.querySelector(".application");
      ulPreview.removeChild(removeLiElement);
      nextButton.disabled = false;
    }

    const applyButton = document.querySelector(".apply");

    applyButton.addEventListener("click", addToScholorship);

    function addToScholorship() {
      liElement.removeChild(applyButton);
      liElement.removeChild(editBtn);
      ulScholorship.appendChild(liElement);

      nextButton.disabled = false;
    }
  }

  function createNewElement(type, textContent, classes, id, parent) {
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
