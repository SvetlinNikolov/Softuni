function solve(num1, num2) {
  let sum = 0;

  for (i = +num1; i <= +num2; i++) {
    sum += i;
  }
  console.log(sum);
}
