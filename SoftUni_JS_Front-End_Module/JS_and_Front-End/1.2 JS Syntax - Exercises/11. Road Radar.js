function solve(speed, area) {
    let output = '';
    let overspeed = 0;
    let isInDriveSpeedLimit = true;

    if (area === `motorway`) {
        if (speed > 130 && speed <= 150) {
            overspeed = speed - 130;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 130 - speeding`);
        } 
        else if (speed > 150 && speed <= 170) {
            overspeed = speed - 130;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 130 - excessive speeding`)
        }
        else if (speed > 170) {
            overspeed = speed - 130;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 130 - reckless driving`)
        }
        else {
            console.log(`Driving ${speed} km/h in a 130 zone`);
        }      
    }
    else if (area === `interstate`) {
        if (speed > 90 && speed <= 110) {
            overspeed = speed - 90;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 90 - speeding`);
        } 
        else if (speed > 110 && speed <= 130) {
            overspeed = speed - 90;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 90 - excessive speeding`)
        }
        else if (speed > 130) {
            overspeed = speed - 90;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 90 - reckless driving`)
        }
        else {
            console.log(`Driving ${speed} km/h in a 90 zone`);
        }      
    }
    else if (area === `city`) {
        if (speed > 50 && speed <= 70) {
            overspeed = speed - 50;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 50 - speeding`);
        } 
        else if (speed > 70 && speed <= 90) {
            overspeed = speed - 50;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 50 - excessive speeding`)
        }
        else if (speed > 90) {
            overspeed = speed - 50;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 50 - reckless driving`)
        }
        else {
            console.log(`Driving ${speed} km/h in a 50 zone`);
        }      
    }
    else if (area === `residential`) {
        if (speed > 20 && speed <= 40) {
            overspeed = speed - 20;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 20 - speeding`);
        } 
        else if (speed > 40 && speed <= 60) {
            overspeed = speed - 20;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 20 - excessive speeding`)
        }
        else if (speed > 60) {
            overspeed = speed - 20;
            console.log(`The speed is ${overspeed} km/h faster than the allowed speed of 20 - reckless driving`)
        }
        else {
            console.log(`Driving ${speed} km/h in a 20 zone`);
        }      
    }
}

solve (180, `city`);
solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');
