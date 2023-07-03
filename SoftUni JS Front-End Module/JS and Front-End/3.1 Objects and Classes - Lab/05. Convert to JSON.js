function solve(firstName, lastName, hairColor) {
    let person = {
        firstName: firstName,
        lastName: lastName,
        hairColor: hairColor
    };

    let text = JSON.stringify(person);
    console.log(text);
}

solve('George', 'Jones', 'Brown');