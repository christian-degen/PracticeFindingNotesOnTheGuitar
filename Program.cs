using PracticeFindingNotesOnTheGuitar;

bool WaitForKey()
{
    Console.ReadKey(true);
    return true;
}

Console.WriteLine("Press any key for next note or Ctrl + C to exit.");

var noteOnString = new NoteOnString();

do
{
    var next = noteOnString.GetNext();
    Console.WriteLine($"Play {next.Note} on {next.GuitarString} string.");
} while (WaitForKey());



