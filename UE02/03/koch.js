// 800 wide, 800 high
var tri = {
  A : { x: 200, y: 0 },
  B : { x: 600, y: 0 },
  C : { x: 400, y: 400}
}

// Using vector.x for calculating vector.y is false, since it uses the previously calculated x
var rotation = function (vector, alpha) {
  var temp = {x: 0, y: 0}
  temp.x = vector.x
  temp.y = vector.y
  var radians = alpha * (Math.PI / 180)
  vector.x = vector.x * Math.cos(radians) - vector.y * Math.sin(radians)
  vector.y = temp.x * Math.sin(radians) + temp.y * Math.cos(radians)
}

var kochCurve = function (curve, depth) {
  if (depth == 0)
  return
  curve.forEach(function (el) {})
}

var myCurve = []
rotation(myVector, 45)
console.log(myVector)

$(document).ready(function () {
  var c = document.getElementById('canvas')
  var context = c.getContext('2d')
  context.fillStyle = '#000'

  var kochCurve = function (segments, length, depth) {
    segments.forEach(function (line) {})
  }

})
