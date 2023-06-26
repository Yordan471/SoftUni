function calculateDistance(x1, y1, x2, y2) {
    return Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);
}

function solve(x1, y1, x2, y2) {
    const firstPointDistanceToCenter = calculateDistance(x1, y1, 0, 0);
    const isFirstDistanceValid = Number.isInteger(firstPointDistanceToCenter);

    const secondPointDistanceToCenter = calculateDistance(x2, y2, 0, 0);
    const isSecondDistanceValid = Number.isInteger(secondPointDistanceToCenter);

    const distanceBetweenPoints = calculateDistance(x1, y1, x2, y2);
    const isThirdPointValid = Number.isInteger(distanceBetweenPoints);

    console.log(fNum);
    console.log(sNum);
    console.log(tNum);
}

solve(3, 0, 0, 4);