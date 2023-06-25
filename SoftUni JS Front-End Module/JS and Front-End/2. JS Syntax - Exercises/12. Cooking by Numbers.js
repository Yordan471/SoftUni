function solve(number, ...operations) {
    while (operations.length > 0) {
        number = Number(number);

        switch (operations[0]) {
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number = number - (number * 0.2);
                break;
        }

        operations.shift();
        console.log(number);
    }
}


solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');