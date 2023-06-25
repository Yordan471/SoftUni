function solve(arrayOfnames) {
    let number = 1;
    
    
    arrayOfnames.sort();
    arrayOfnames.forEach(element => {
        console.log(`${number++}.${element}`)
    });
}

solve(["John","Bob","Christina","Ema"]);