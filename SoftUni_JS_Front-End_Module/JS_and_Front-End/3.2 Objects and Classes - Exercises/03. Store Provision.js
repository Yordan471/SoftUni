function solve(firstArr, secondArr) {
  let products = {};

    while (firstArr.length > 0) {
    let product = firstArr.shift();
    let quantity = Number(firstArr.shift());

    if (products.hasOwnProperty(product)) {
      products[product] += Number(quantity);
      continue;
    }

    products[product] = quantity;
  }

  while (secondArr.length > 0) {
    let product = secondArr.shift();
    let quantity = Number(secondArr.shift());

    if (products.hasOwnProperty(product)) {
      products[product] += Number(quantity);
      continue;
    }

    products[product] = quantity;
  }

  let entries = Object.entries(products);

  for (const [key, value] of entries) {
     console.log(`${key} -> ${value}`);
  }
}

solve(
  ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
  ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
);
