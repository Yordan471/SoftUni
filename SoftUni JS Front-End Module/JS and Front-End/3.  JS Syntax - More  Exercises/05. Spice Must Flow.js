function solve(startingYield) {
    const miningCrewConsumption = 26;
    const dailyLoss = 10;
    let minedYield = 0;
    let daysMined = 0;

    if (startingYield < 100) {
         console.log(daysMined);
         console.log(minedYield);
         return;
    }

    while (startingYield >= 100) {
        minedYield += startingYield;
        startingYield -= dailyLoss;

        if (minedYield >= miningCrewConsumption) {
            minedYield -= miningCrewConsumption;
        }    
        
        daysMined++;
    }

    if (minedYield >= miningCrewConsumption) {
        minedYield -= miningCrewConsumption;
    } 
    
    console.log(daysMined);
    console.log(minedYield);
}

solve(100);
