function solve(password) {
    let isLengthGood = true;
    let isOnlyOfLettersAndDigits = true;
    let hasAtleastTwoDigits = true;

    if (password.length < 6 || password.length > 10 ) {
        isLengthGood = false;
        console.log('Password must be between 6 and 10 characters');
    }
    
    let array = password.split('');

    for (let index = 0; index < array.length; index++) {

        let num = parseInt(array[index]);

        if (!(Number.isInteger(num)) && array[index].toLowerCase() === array[index].toUpperCase()) {
            isOnlyOfLettersAndDigits = false;
            console.log('Password must consist only of letters and digits');
            break;
        }
    }

    let countDigits = 0;

    for (let index = 0; index < array.length; index++) {
        let num = parseInt(array[index]);

        if (Number.isInteger(num)) {
             countDigits++;
        }
    }

    if (countDigits < 2) {
        hasAtleastTwoDigits = false;
        console.log('Password must have at least 2 digits');
    }

    if (isLengthGood &&
        isOnlyOfLettersAndDigits &&
        hasAtleastTwoDigits) {
            console.log('Password is valid');
        }
}

solve('logIn');
solve('MyPass123');
solve('Pa$s$s');