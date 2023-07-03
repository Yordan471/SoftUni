function solve(array) {
    let schedule = {};

    for (const info of array) {
        let entries = info.split(' ');
        let weekday = entries[0];
        let name = entries[1];

        if (schedule.hasOwnProperty(weekday)) {
            console.log(`Conflict on ${weekday}!`);
            continue;
        }

        schedule[weekday] = name;
        
        console.log(`Scheduled for ${weekday}`);         
        }

        for (const key in schedule) {
            console.log(`${key} -> ${schedule[key]}`);
        }
    }

    solve(['Monday Peter','Wednesday Bill','Monday Tim','Friday Tim']);