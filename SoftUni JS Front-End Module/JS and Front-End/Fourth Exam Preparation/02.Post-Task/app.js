window.addEventListener("load", solve);

function solve() {
  const inputFields = {
    title: document.querySelector("#task-title"),
    category: document.querySelector("#task-category"),
    content: document.querySelector("#task-content"),
  };

  publishButton = document.querySelector("#publish-btn");
  console.log(publishButton);
  publishButton.disabled = false;
  publishButton.addEventListener("click", publishArticle);
  
  function publishArticle() {
    if (Object.values(inputFields).some((input) => input.value === "")) {
        return;
    }

    const ul = document.querySelector("#review-list");
    const li = createElement("li", null, ["rpost"], null, ul);
    const article = createElement("article", null, null, null, li);
    createElement("h4", inputFields.title.value, null, null, article);
    createElement(
      "p",
      `Category: ${inputFields.category.value}`,
      null,
      null,
      article
    );
    createElement(
      "p",
      `Content: ${inputFields.content.value}`,
      null,
      null,
      article
    );
    const editBtn = createElement("button", "Edit", ["action-btn", "edit"], null, article);
    const postBtn = createElement("button", "Post", ["action-btn", "post"], null, article);

    editBtn.addEventListener("click", editInfo) 

    Object.values(inputFields).map((input) => {
        input.value = "";
    });
  }

  function editInfo(e) {
    const article = e.currentTarget.parentElement;
    const children = article.children;
    
    inputFields.title.value = children[0].textContent;
    inputFields.category.value = children[1].textContent.split(" ")[1];
    inputFields.content.value = children[2].textContent.split(" ")[1];

    article.parentElement.remove();
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
