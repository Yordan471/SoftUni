function solve(fruit, weightGrams, priceKg) {
    let weightInKg = (weightGrams / 1000.);
    let price = (weightInKg * priceKg);

    console.log(`I need $${price.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80);
solve('orange', 500, 1.80);