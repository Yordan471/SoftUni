class Cat {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    meow() {
        console.log(`${this.name}, age ${this.age} says Meow`);
    }
}

function solve(inputArray) { 
    let gatherCats = [];

    for (const line of inputArray) {
        let splitedLine = line.split(' ');
        let cat = new Cat(splitedLine[0], splitedLine[1]);
        gatherCats.push(cat);
    }

    for (const animal of gatherCats) {
        animal.meow();
    }
}

solve(['Mellow 2', 'Tom 5']);