function solve(text) {
    let object = JSON.parse(text);
    let entries = Object.entries(object);

    for (const [key, value] of entries) {
        console.log(`${key}: ${value}`);
    }
}

solve('{"name": "George", "age": 40, "town": "Sofia"}');