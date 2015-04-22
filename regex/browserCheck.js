var mozRegex = new RegExp('[Mm]ozilla\/[4-6]') //is js support
var mozLikeReg = '/[Gg]ecko/' //is W3C Dom support
var msReg = '/MSIE.((5\.[5-9])|([6-9]|1[0-9]))/' //same
var w3cReg = '/W3C_/' //W3C validation 


var mozHeader = "User-Agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_0)"
var ieHeader = "blubb blubb MSIE 5.8 blubb blubb"

var matches = mozRegex.match(mozHeader)	
console.log(matches)

// Line 1 any upper or lower case variant of Mozilla/4-6 (MSIE also sets this value)
// Line 3 any upper or lower case variant of the Gecko browser -> Firefox, Netscape 6, 7 and now 8 
// Line 4  MSIE 5.5 (or greater) OR MSIE 6 - 19 
// Line 5 checks for W3C_ in any part of the line.  W3C validation services CSS or HTML/XHTML 
