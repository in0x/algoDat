function sum(x) {
    if (x == 0)
      return 1
    return Math.pow(3, x) + sum(x - 1)
  }

 console.log(sum(1))