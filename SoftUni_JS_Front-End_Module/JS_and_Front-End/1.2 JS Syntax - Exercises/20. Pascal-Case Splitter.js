function solve(string) {
    let text = string.split(/(?=[A-Z])/);
    console.log(text.join(', '));
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');