window.addEventListener("load", solve);

function solve() {
  const inputFormats = {
    title: document.querySelector("#title"),
    description: document.querySelector("#description"),
    label: document.querySelector("#label"),
    points: document.querySelector("#points"),
    asignee: document.querySelector("#assignee"),
  };

  const buttons = {
    createTaskBtn: document.querySelector("#create-task-btn"),
    deleteTaskBtn: document.querySelector("#delete-task-btn"),
  };

  const section = document.querySelector("#tasks-section");

  const tasks = {};

  buttons.createTaskBtn.addEventListener("click", createTask);

  function createTask(e) {
    if (Object.values(inputFormats).some((input) => input.value === "")) {
      return;
    }

    const task = {
      id: `task-${Object.values(tasks).length + 1}`,
      title: inputFormats.title.value,
      description: inputFormats.description.value,
      label: inputFormats.label.value,
      points: Number(inputFormats.points.value),
      asignee: inputFormats.asignee.value,
    };

    tasks[task.id] = task;

    const article = createElement("article", null, ["task-card"], task.id);
    createElement(
      "div",
      task.label,
      ["task-card-label", task.label.toLowerCase()],
      null,
      article
    );
    createElement("h3", task.title, ["task-card-title"], null, article);
    createElement(
      "p",
      task.description,
      ["task-card-description"],
      null,
      article
    );
    createElement("div", `Estimated at ${task.points} pts`, ["task-card-points"], null, article);
    createElement("div", `Assigned to ${task.asignee}`, ["task-card-assignee"], null, article);
    
    section.appendChild(article);
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
