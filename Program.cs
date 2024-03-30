
bool WaitForKey()
{
    Console.ReadKey(true);
    return true;
}

var notes = new[] { 'F', 'C', 'G', 'D', 'A', 'E', 'B' };
var guitarStrings = new[] { 'E', 'B', 'G', 'D', 'A' };
var random = new Random();

Console.WriteLine("Hit any key for next note or Ctrl + C to exit.");

do
{
    var noteIndex = random.Next(0, notes.Length);
    var guitarStringIndex = random.Next(0, guitarStrings.Length);
    Console.WriteLine($"Play {notes[noteIndex]} on {guitarStrings[guitarStringIndex]} string.");
} while (WaitForKey());



