function solve(cityInfo) {

    let entries = Object.entries(cityInfo);

    for (const [key, value] of entries) {
        console.log(`${key} -> ${value}`);
    }
}

solve({name: "Sofia", area: 492, population: 1238438,country: "Bulgaria",postCode: "1000"
})