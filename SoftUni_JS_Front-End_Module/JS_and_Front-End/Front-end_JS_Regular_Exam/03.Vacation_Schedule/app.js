const Base_URL = `http://localhost:3030/jsonstore/tasks/`;
const nameInput = document.querySelector("#name");
const numDaysInput = document.querySelector("#num-days");
const fromDateInput = document.querySelector("#from-date");
const loadVacationsButton = document.querySelector("#load-vacations");
const addVacationButton = document.querySelector("#add-vacation");
const editVacationButton = document.querySelector("#edit-vacation");
const list = document.querySelector("#list");

function attachEvents() {
  loadVacationsButton.addEventListener("click", loadTasks);
  // addVacationButton.addEventListener("click", addVacation);
  // editVacationButton.addEventListener("click", editVacation);
}

async function loadTasks() {
  const tasks = await (
    await fetch("http://localhost:3030/jsonstore/tasks/")).json();

      Ovject.values(tasks).forEach((task) => task.value = "");

      Object.values(tasks).forEach((task) => {
        const divContainer = createNewElement(
          "div",
          null,
          ["container"],
          null,
          list
        );
        createNewElement("h2", task.name, [], null, divContainer);
        createNewElement("h3", task.date, [], null, divContainer);
        createNewElement("h3", task.days, [], null, divContainer);
        createNewElement(
          "button",
          "Change",
          ["change-btn"],
          null,
          divContainer
        );
        createNewElement("button", "Done", ["done-btn"], null, divContainer);

        editVacationButton.disabled = true;
      });
}

// async function addVacation() {
//   const task = {
//     name: nameInput.value,
//     date: fromDateInput.value,
//     days: numDaysInput.value,
//   };

//   const divContainer = createNewElement("div", null, ["container"], null, list);
//   createNewElement("h2", nameInput.values, [], null, divContainer);
//   createNewElement("h3", fromDateInput.values, [], null, divContainer);
//   createNewElement("h3", numDaysInput.values, [], null, divContainer);

//   createNewElement("button", "Change", ["change-btn"], null, divContainer);
//   createNewElement("button", "Done", ["done-btn"], null, divContainer);

//   fetch("http://localhost:3030/jsonstore/tasks/", {
//     method: "POST",
//     body: JSON.stringify(task),
//   });

  

//   loadTasks();
//   nameInput.values = "";
//   fromDateInput.values = "";
//   numDaysInput.values ="";
// }

function createNewElement(type, textContent, classes, id, parent, innerHTML) {
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

attachEvents();
