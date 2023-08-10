function solve() {
  const departBtn = document.querySelector("#depart");
  const arriveBtn = document.querySelector("#arrive");
  const infoBox = document.querySelector("#info .info");

  let busStopInfo = {
    name: "",
    next: "depot",
  };

  function depart() {
    fetch(`http://localhost:3030/jsonstore/bus/schedule/${busStopInfo.next}`)
      .then((res) => res.json())
      .then((busStop) => {
        busStopInfo = busStop;
        departBtn.disabled = true;
        arriveBtn.disabled = false;
        infoBox.textContent = `Next stop ${busStopInfo.name}`;
      }).catch(() => {
        departBtn.disabled = false;
        arriveBtn.disabled = false;
        infoBox.textContent = `Error`;
      })
  }

  async function arrive() {
    departBtn.disabled = true;
    arriveBtn.disabled = true;
    infoBox.textContent = `Arrive stop ${busStopInfo.name}`;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();
