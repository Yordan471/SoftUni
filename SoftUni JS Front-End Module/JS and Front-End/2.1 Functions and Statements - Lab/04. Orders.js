


function calculate(product, quantity) {
    const products = {
        coffee: 1.50,
        water: 1.00,
        coke: 1.40,
        snacks: 2.00,
    }

    const price = products[product] * quantity;
    console.log(price.toFixed(2));
}

calculate('water', 5);

