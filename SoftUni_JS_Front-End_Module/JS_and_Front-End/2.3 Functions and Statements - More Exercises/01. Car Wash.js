function CarWash(operations) {
    let value = 0;

while (operations.length > 0) {
    switch (operations.shift()) {
        case 'soap':
            value += 10;
            break;
        case 'water':
            value *= 1.20;
            break;
        case 'vacuum cleaner':
            value *= 1.25;
            break;
        case 'mud':
            value *= 0.90;
            break;
    }
}

    console.log(`The car is ${value.toFixed(2)}% clean.`);
}

CarWash(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]);