import Text.Regex.Posix

textMoz, patternMoz, textIE, patternIE :: String 

textMoz = "User-Agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_10_0)"
patternMoz = "[Mm]ozilla/[4-6].0" -- JS Support
textIE = "User-Agent: Mozilla/4.0(compatible; MSIE.7.0b, Windows NT 6.0)"
patternIE = "MSIE.((5.[5-9])|([6-9]|1[0-9]))" -- W3C Dom Support

validate :: String -> String -> String
validate x y = (y =~ x :: String)

main :: IO ()
main = putStrLn $ validate patternMoz textMoz 

		
		
