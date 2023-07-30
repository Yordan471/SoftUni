function sprintReview(input) {
  const numberOfLines = Number(input.shift());
  const asigneesInfo = input.slice(0, numberOfLines);
  const commandsInfo = input.slice(numberOfLines);

  const boardAsignees = asigneesInfo.reduce((board, info) => {
    const [asignee, taskId, title, status, estimatedPoints] = info.split(":");
    if (!board.hasOwnProperty(asignee)) {
      board[asignee] = [];
    }

    board[asignee].push({
      taskId,
      title,
      status,
      estimatedPoints: Number(estimatedPoints),
    });
    return board;
  }, {});

  const commandParser = {
    "Add New": addNewTask,
    "Change Status": changeStatus,
    "Remove Task": removeTask,
  };

  commandsInfo.forEach((line) => {
    const commandTokens = line.split(":");
    commandParser[commandTokens[0]](...commandTokens.slice(1));
  });

  const toDoTasksPoints = getTotalPointsForStatus("ToDo");
  const inProgressPoints = getTotalPointsForStatus("In Progress");
  const codeReviewPoints = getTotalPointsForStatus("Code Review");
  const donePoints = getTotalPointsForStatus("Done");

  console.log(`ToDo: ${toDoTasksPoints}pts`);
  console.log(`In Progress: ${inProgressPoints}pts`);
  console.log(`Code Review: ${codeReviewPoints}pts`);
  console.log(`Done Points: ${donePoints}pts`);

  const firstThreeStatusPoints =
    toDoTasksPoints + inProgressPoints + codeReviewPoints;

  if (donePoints >= firstThreeStatusPoints) {
    console.log("Sprint was successful!");
  } else {
    console.log(`Sprint was unsuccessful...`);
  }

  function addNewTask(asignee, taskId, title, status, estimatedPoints) {
    if (checkIfAsigneeExists(asignee)) {
      boardAsignees[asignee].push({
        taskId,
        title,
        status,
        estimatedPoints: Number(estimatedPoints),
      });
    }
  }

  function changeStatus(asignee, taskId, newStatus) {
    if (checkIfAsigneeExists(asignee) && chechTaskIdExists(asignee, taskId)) {
      const task = boardAsignees[asignee].find(
        (task) => task.taskId === taskId
      );
      task.status = newStatus;
    }
  }

  function removeTask(asignee, index) {
    index = Number(index);

    if (
      checkIfAsigneeExists(asignee) &&
      checkIfIndexIsValid(boardAsignees[asignee], index)
    ) {
      boardAsignees[asignee].splice(index, 1);
    }
  }

  function checkIfAsigneeExists(asignee) {
    const isExistring = boardAsignees.hasOwnProperty(asignee);

    if (!isExistring) {
      console.log(`Assignee ${asignee} does not exist on the board!`);
    }

    return isExistring;
  }

  function chechTaskIdExists(asignee, taskId) {
    const taskExist = boardAsignees[asignee].some((t) => 
      t.taskId === taskId
    );

    if (!taskExist) {
      console.log(`Task with ID ${taskId} does not exist for ${asignee}!`);
    }

    return taskExist;
  }

  function checkIfIndexIsValid(tasks, index) {
    const isValid = index >= 0 && index <= tasks.length;

    if (!isValid) {
      console.log(`Index is out of range!`);
    }

    return isValid;
  }

  function getTotalPointsForStatus(status) {
    return Object.values(boardAsignees).reduce((totalPoints, tasks) => {
      return (
        totalPoints +
        tasks
          .filter((t) => t.status === status)
          .map((t) => t.estimatedPoints)
          .reduce((a, b) => a + b, 0)
      );
    }, 0);
  }
}

sprintReview([
  "4",
  "Kiril:BOP-1213:Fix Typo:Done:1",
  "Peter:BOP-1214:New Products Page:In Progress:2",
  "Mariya:BOP-1215:Setup Routing:ToDo:8",
  "Georgi:BOP-1216:Add Business Card:Code Review:3",
  "Add New:Sam:BOP-1237:Testing Home Page:Done:3",
  "Change Status:Georgi:BOP-1216:Done",
  "Change Status:Will:BOP-1212:In Progress",
  "Remove Task:Georgi:3",
  "Change Status:Mariya:BOP-1215:Done",
]);
