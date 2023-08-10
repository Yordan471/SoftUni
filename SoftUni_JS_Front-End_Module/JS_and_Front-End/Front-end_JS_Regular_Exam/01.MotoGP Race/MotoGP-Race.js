function solve(inputInfo) {
  const numOfRiders = inputInfo.shift();
  const ridersInfo = inputInfo.slice(0, numOfRiders);
  const commands = inputInfo.slice(numOfRiders);

  const riders = [];

  ridersInfo.forEach((lineInfo) => {
    let [rider, fuelCapacity, position] = lineInfo.split("|");
    fuelCapacity = Number(fuelCapacity);
    position = Number(position);

    riders[rider] = { fuelCapacity, position };
  });

  while (commands[0] !== "Finish") {
    const commandInfo = commands.shift().split(" - ");
    const command = commandInfo[0];
    const firstRider = commandInfo[1];

    if (command === "StopForFuel") {
      const minimumFuel = Number(commandInfo[2]);
      const changedPosition = commandInfo[3];

      if (riders[firstRider].fuelCapacity < minimumFuel) {
        riders[firstRider].position = changedPosition;

        console.log(
          `${firstRider} stopped to refuel but lost his position, now he is ${changedPosition}.`
        );
      } else {
        console.log(`${firstRider} does not need to stop for fuel!`);
      }
    } else if (command === "Overtaking") {
      const secondRider = commandInfo[2];
      const firstRiderPosition = riders[firstRider].position;
      const secondRiderPosition = riders[secondRider].position;

      if (firstRiderPosition < secondRiderPosition) {
        riders[firstRider].position = secondRiderPosition;
        riders[secondRider].position = firstRiderPosition;

        console.log(`${firstRider} overtook ${secondRider}!`);
      }
    } else if (command === "EngineFail") {
      const lapsLeft = commandInfo[2];

      delete riders[firstRider];

      console.log(
        `${firstRider} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`
      );
    }
  }

  let entries = Object.entries(riders);

  for (const [rider, info] of entries) {
    console.log(`${rider}`);
    console.log(`  Final position: ${info.position}`);
  }
}

solve([
  "4",
  "Valentino Rossi|100|1",
  "Marc Marquez|90|3",
  "Jorge Lorenzo|80|4",
  "Johann Zarco|80|2",
  "StopForFuel - Johann Zarco - 90 - 5",
  "Overtaking - Marc Marquez - Jorge Lorenzo",
  "EngineFail - Marc Marquez - 10",
  "Finish",
]);
