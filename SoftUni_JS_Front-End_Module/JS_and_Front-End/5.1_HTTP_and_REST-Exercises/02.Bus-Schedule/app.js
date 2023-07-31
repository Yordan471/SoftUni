function solve() {
    const departBtn = document.querySelector("#depart");
    const arriveBtn = document.querySelector("#arrive");
    const infoBox = document.querySelector("#info .info");

    function depart() {
        fetch("http://localhost:3030/jsonstore/bus/schedule/depot")
        .then((res) => res.json())
        .then((busStop) => {
            departBtn.disabled = true;
            arriveBtn.disabled = false;
            infoBox.textContent = `Next stop ${busStop.name}`
        });
    }

    async function arrive() {
        // TODO:
    }

    return {
        depart,
        arrive
    };
}

let result = solve();