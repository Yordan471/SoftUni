class Song {
  constructor(typeList, name, time) {
    this.typeList = typeList;
    this.name = name;
    this.time = time;
  }
}

function solve(input) {
  let songs = [];
  let numOfSongs = input.shift();
  let typeSong = input.pop();

  for (let index = 0; index < numOfSongs; index++) {
    let [type, name, time] = input[index].split("_");
    let song = new Song(type, name, time);
    songs.push(song);
  }

  if (typeSong === "all") {
    songs.forEach((song) => console.log(song.name));
  } else {
    let typeSong = songs.filter((song) => song.type === typeSong);
    typeSong.forEach((song) => console.log(song.name));
  }
}

solve([2, "like_Replay_3:15", "ban_Photoshop_3:48", "all"]);
