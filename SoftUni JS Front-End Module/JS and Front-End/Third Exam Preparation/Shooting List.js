function shoppingList(input) {
  input.pop();
  const products = input.shift().split("!");
  const commands = input;

  commands.forEach((line) => {
    const item = line.split(" ")[1];
    const command = line.split(" ")[0];

    if (command === "Urgent") {
      if (!products.includes(item)) {
        products.splice(0, 0, item);
      }
    } else if (command === "Unnecessary") {
      if (products.includes(item)) {
        const index = products.indexOf(item);
        products.splice(index, 1);
      }
    } else if (command === "Correct") {
      const newItem = line.split(" ")[2];

      if (products.includes(item)) {
        const index = products.indexOf(item);
        products.splice(index, 1, newItem);
      }
    } else if (command === "Rearrange") {
      if (products.includes(item)) {
        const index = products.indexOf(item);
        products.splice(index, 1);
        products.push(item);
      }
    }
  });

  console.log(products.join(", "));
}

shoppingList([
  "Milk!Pepper!Salt!Water!Banana",
  "Urgent getsuga",
  "Rearrange Salt",

  "Unnecessary Grapes",
  "Correct Pepper Onion",

  "Correct Tomatoes Potatoes",
  "Go Shopping!",
]);
