function solve(input) {
    let personInfo = {};

    for (const info of input) {
        let entries = info.split(':');
        let name = entries[0];
        let adress = entries[1];

        personInfo[name] = adress;
    }

    let sorted = Object.entries(personInfo);
    sorted.sort((a, b) => a[0].localeCompare(b[0]));

    for (const [key, value] of sorted) {
        console.log(`${key} -> ${value}`);
    }
}

solve(['Tim:Doe Crossing','Bill:Nelson Place','Peter:Carlyle Ave','Bill:Ornery Rd']);