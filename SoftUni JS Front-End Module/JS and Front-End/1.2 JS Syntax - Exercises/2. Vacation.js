function solve(numOfPeople, type, day) {
    let price = 0;

    if (type === 'Students') {
        if (day === 'Friday') {
            price = numOfPeople * 8.45;
        }
        else if (day === 'Saturday') {
            price = numOfPeople * 9.80;
        }
        else if (day === 'Sunday') {
            price = numOfPeople * 10.46;
        }
    }
    else if (type === 'Business') {
        if (day === 'Friday') {
            price = numOfPeople * 10.90;
        }
        else if (day === 'Saturday') {
            price = numOfPeople * 15.60;
        }
        else if (day === 'Sunday') {
            price = numOfPeople * 16;
        }
    }
    else if (type === 'Regular') {
        if (day === 'Friday') {
            price = numOfPeople * 15;
        }
        else if (day === 'Saturday') {
            price = numOfPeople * 20;
        }
        else if (day === 'Sunday') {
            price = numOfPeople * 22.50;
        }
    }

    if (type === 'Students') {
        if (numOfPeople >= 30) {
            price *= 0.85;
        }
    }
    else if (type === 'Business') {
        if (numOfPeople >= 100) {
            price = price - (10 * price);
        }
    }
    else if (type === 'Regular') {
        if (numOfPeople >= 10 && numOfPeople <= 20) {
            price *= 0.95;
        }
    }

    let actualPrice = price.toFixed(2);

    console.log(`Total price: ${actualPrice}`);
}

solve(30, 'Students', 'Sunday');
solve(40, 'Regular', 'Saturday');