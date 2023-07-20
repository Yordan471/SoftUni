function sprintReview(input) {
    const numberOfLines = input.shift();
    const asigneesInfo = input.slice(0, numberOfLines);
    const commandsInfo = input.slice(numberOfLines);

    const boardAsignees = asigneesInfo.reduce((board, info) => {
       const [asignee, taskId, title, status, estimatedPoints] = info.split(":");
       if (!board.hasOwnProperty(asignee)) {
          board[asignee] = [];
       }

       board[asignee].push({taskId, title, status, estimatedPoints: Number(estimatedPoints)});
       return board;
    }, {});

    const commandParser = {
        "Add New": addNewTask,
        "Change Status": changeStatus,
        "Remove Task": removeTask,
    };
}