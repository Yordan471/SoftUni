

function personelNumber(inputInfo) {
    class Person {
        constructor(name) {
          this.name = name;
        }
      }

  let people = [];

  for (let index = 0; index < inputInfo.length; index++) {
    let [name] = inputInfo[index].split(",");
    let person = new Person(name);
    people.push(person);
  }

  people.forEach((person) =>
    console.log(
      `Name: ${person.name} -- Personal Number: ${person.name.length}`
    )
  );
}

personelNumber(['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal'  ])
