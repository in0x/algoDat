:mod +Text.Regex.Posix

let toShrink = "AaaaddddDDDEfffxxyZZZZZ"
let pattern = "(.)\1{3,}"

toShrink =~ pattern :: String


-- string toShrink = "AaaaddddDDDEfffxxyZZZZZ";
-- string shrunk = Regex.Replace(toShrink, @"(.)\1{3,}", Match => "$1#" + Match.Value.Length + "#");
-- Console.WriteLine(shrunk + " " + toShrink.Length + " " + shrunk.Length);