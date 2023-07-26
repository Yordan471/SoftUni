window.addEventListener('load', solve);

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
    }
}