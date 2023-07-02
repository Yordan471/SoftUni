function solve(firstName, lastName, age) {
    let person = {};

    person.firstName = firstName;
    person.lastName = lastName;
    person.age = age;

    return person;
}

const person = solve('Peter', "Pan", '20');

person.forEach(element => console.log(element));

    

solve("Peter", "Pan", "20");