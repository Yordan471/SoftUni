function solve(x1, y1, x2, y2) {
    let fNum = Math.sqrt(Math.pow(x2 -x1) + Math.pow(0 - 0));
    let sNum = Math.sqrt(Math.pow(0 -0) + Math.pow(y2 - y1));
    let tNum = Math.sqrt(Math.pow(x2 -x1) + Math.pow(y2 - y1));

    console.log(fNum);
    console.log(sNum);
    console.log(tNum);
}

solve(3, 0, 0, 4);