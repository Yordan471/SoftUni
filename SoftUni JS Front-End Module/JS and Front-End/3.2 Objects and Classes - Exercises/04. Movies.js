function solve(inputInfo) {
  let moviesInfo = [];

  while (inputInfo.length > 0) {
    let commandString = inputInfo.shift();

    if (commandString.includes("addMovie")) {
      let name = commandString.split("addMovie ")[1];
      moviesInfo.push({
        name,
        date: null,
        director: null,
      });
    } else if (commandString.includes("directedBy")) {
      let name = commandString.split(" directedBy ")[0];
      let director = commandString.split(" directedBy ")[1];
      let movieNameExists = moviesInfo.find((m) => m.name === name);

      if (movieNameExists) {
        movieNameExists.director = director;
      }
    } else if (commandString.includes("onDate")) {
      let [name, date] = commandString.split(" onDate ");
      movieNameExists = moviesInfo.find((m) => m.name === name);

      if (movieNameExists) {
        movieNameExists.date = date;
      }
    }
  }

  console.log(JSON.stringify(moviesInfo));
}

solve([
  "addMovie Fast and Furious",
  "addMovie Godfather",
  "Inception directedBy Christopher Nolan",
  "Godfather directedBy Francis Ford Coppola",
  "Godfather onDate 29.07.2018",
  "Fast and Furious onDate 30.07.2018",
  "Batman onDate 01.08.2018",
  "Fast and Furious directedBy Rob Cohen",
]);
