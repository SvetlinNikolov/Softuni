function myFunction(a, b, c) {
    let sumLenght = 0;
    let averageLength = 0;

    let firstArgLen = a.length;
    let secondArgLen = b.length;
    let thirdArgLen = c.length;

    sumLenght = firstArgLen + secondArgLen + thirdArgLen;

    averageLength = Math.floor(sumLenght / 3);

    console.log(sumLenght);
    console.log(averageLength);

}
