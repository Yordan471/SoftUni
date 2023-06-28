function solve(grade) {
    grade = grade.toFixed(2);

    if (grade < 3.00) {
        console.log(`Fail (${grade})`)
    }
    else if (grade >= 3.00 && grade < 3.50) {
        console.log(`Poor (${grade})`);
    }
    else if (grade >= 3.50 && grade < 4.50) {
        console.log(`Good (${grade})`);
    }
    else if (grade >= 4.50 && grade < 5.50) {
        console.log(`Very good (${grade})`);
    }
    else if (grade >= 5.50) {
        console.log(`Excellent (${grade})`);
    }
}

solve(3.33);
solve(4.50);