function solve(...chars) {   

    chars = chars.reverse();
    let string = `${chars[0]} ` + `${chars[1]} ` + `${chars[2]}`;

    console.log(string);
}

solve('a', 'b', 'c');