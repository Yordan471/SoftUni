function solve(cityName, population, treasury) {
    return {
        cityName,
        population,
        treasury,
    
        taxRate: 10,
    
        collectTaxes: () => Math.floor(city.population * taxRate),
        applyGrowth: (percentage) => city.population += Math.floor(city.population * percentage),
        applyRecession: (percentage) => city.treasury -= Math.floor(city.treasury * percentage),
    };
}

console.log(solve('Tortuga', 7000, 15000));

