var readline = require('readline');

var rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout
});

rl.question("Enter a char\n", function(answer) {
  console.log(answer.charCodeAt(0));
  rl.close();
});
