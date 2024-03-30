namespace PracticeFindingNotesOnTheGuitar;

public class NoteOnString
{
    private readonly char[] _Notes = ['F', 'C', 'G', 'D', 'A', 'E', 'B'];
    private readonly char[] _GuitarStrings = ['E', 'B', 'G', 'D', 'A'];
    private readonly Random _Random = new();

    private readonly HashSet<Tuple<char, char>> _History = new();
    private const int MaxHistory = 1000;
    
    public NoteAndString GetNext()
    {
        if (_History.Count > MaxHistory)
        {
            _History.Clear();
        }
        
        NoteAndString next;
        do
        {
            next = GetNextInner();
        } while (SkipResult(next));

        _History.Add(next.HashKey);

        return next;
    }

    private bool SkipResult(NoteAndString next)
    {
        if (next.IsIdentical)
        {
            return true;
        }

        if (_History.Contains(next.HashKey))
        {
            return true;
        }

        return false;
    }
    
    private NoteAndString GetNextInner()
    {
        var noteIndex = _Random.Next(0, _Notes.Length);
        var note = _Notes[noteIndex];
        
        var guitarStringIndex = _Random.Next(0, _GuitarStrings.Length);
        var guitarString = _GuitarStrings[guitarStringIndex];

        return new NoteAndString(note, guitarString);
    }
}

public class NoteAndString
{
    public char Note { get; }
    public char GuitarString { get; }
    public Tuple<char,char> HashKey { get; }

    public bool IsIdentical => Note == GuitarString;

    public NoteAndString(char note, char guitarString)
    {
        Note = note;
        GuitarString = guitarString;
        HashKey = new Tuple<char, char>(note, guitarString);
    }
}