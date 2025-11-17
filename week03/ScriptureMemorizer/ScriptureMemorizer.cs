public class ScriptureMemorizer
{
    private Reference _reference;
    private List<Word> _words =new List<Word>();
    private Random _random = new Random();

    public ScriptureMemorizer(Reference reference, string text)
    {
        _reference = reference;

        string[] parts = text.Split(" ");
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }
    public void HideRandomWords(int numberToHide)
    {
        int hiddenCount = 0;
        while (hiddenCount < numberToHide)
        {
            int index=_random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
            if  (IsCompletelyHidden())
                break;

        }
    }
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));

        return $"{referenceText}\n {wordsText}";
    }

}