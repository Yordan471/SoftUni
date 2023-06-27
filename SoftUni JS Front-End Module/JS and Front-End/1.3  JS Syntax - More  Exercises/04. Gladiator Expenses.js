function solve(lostFights, helmPrice, swordPrice, shieldPrice, armorPrice) {
    let counter = 1;
    let cost = 0;
    
    while (lostFights + 1 > counter) {
        if (counter % 2 === 0) {
            cost += helmPrice;
        }

        if (counter % 3 === 0) {
            cost += swordPrice;
        }

        if (counter % 6 === 0) {
            cost += shieldPrice;
        }

        if (counter % 12 === 0) {
            cost += armorPrice;
        }

        counter++;
    }

    console.log(`Gladiator expenses: ${cost.toFixed(2)} aureus`);
}


solve(23, 12.50, 21.50, 40, 200);