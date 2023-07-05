
function printTownInfo(inputInfo) {
    class Town {
        constructor(town, latitude, longitude) {
            this.town = town;
            this.latitude = latitude;
            this.longtitude = longitude;
        }
    }

    let towns = [];

    for (let index = 0; index < inputInfo.length; index++) {
        let splitted = inputInfo[index].split(' | ');
        let town = splitted[0];
        let latitude = Number(splitted[1]);
        let longitude = Number(splitted[2]);

        let townObject = {
            town: town,
            latitude: latitude.toFixed(2),
            longitude: longitude.toFixed(2)
        };

        let currTown = new Town(town, latitude.toFixed(2), longitude.toFixed(2));
        towns.push(townObject);
    }

    towns.forEach((town) => console.log(town));
}

printTownInfo(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);