$(document).ready(function () {
  function Triangle (A, B, C) {
    this.A = A
    this.B = B
    this.C = C
  }

  function middlePoint (first, second) {
    return {x: ((first.x + second.x) / 2), y: ((first.y + second.y) / 2)}
  }

  function sierpinski (triangles, depth) {
    if (depth == 0)
    return
    triangles.forEach(function (t) {
      var mAB = middlePoint(t.A, t.B),
        mAC = middlePoint(t.A, t.C),
        mBC = middlePoint(t.B, t.C)
      triangles.push(new Triangle(t.A, mAB, mAC),
        new Triangle(mAB, t.B, mBC),
        new Triangle(mAC, mBC, t.C))
    })
    sierpinski(triangles, depth - 1)
  }

  function sum(x) {
    if (x == 0)
      return 1
    return Math.pow(3, x) + sum(x - 1)
  }

  function sierpinski_new (triangles, depth) {
    if (depth == 0)
    return
    for (var i = sum(depth - 1); i < triangles.length; i++) {
      var t = triangles[i] 
      var mAB = middlePoint(t.A, t.B),
        mAC = middlePoint(t.A, t.C),
        mBC = middlePoint(t.B, t.C)
      triangles.push(new Triangle(t.A, mAB, mAC),
        new Triangle(mAB, t.B, mBC),
        new Triangle(mAC, mBC, t.C))
    }
    sierpinski(triangles, depth - 1)
  }

  // 3 ^ depth
  function draw (triangle) {
    triangle.forEach(function (t) {
      context.beginPath()
      context.stroke()
      context.moveTo(t.A.x, t.A.y)
      context.lineTo(t.B.x, t.B.y)
      context.stroke()
      context.lineTo(t.C.x, t.C.y)
      context.stroke()
      context.moveTo(t.A.x, t.A.y)
      context.lineTo(t.C.x, t.C.y)
      context.stroke()
    })
  }

  var c = document.getElementById('canvas')
  var context = c.getContext('2d')
  context.fillStyle = '#000'
  context.lineWidth = 0.5

  //var elements = []
  var el_more = []
  //elements.push(new Triangle({x: 600, y: 1000}, {x: 1400, y: 1000}, {x: 1000, y: 350}))
  el_more.push(new Triangle({x: 600, y: 1000}, {x: 1400, y: 1000}, {x: 1000, y: 350}))
  //sierpinski(elements, 6)
  sierpinski_new(el_more, 7)
  //console.log(elements.length)
  console.log(el_more.length)
  draw(el_more)

})
