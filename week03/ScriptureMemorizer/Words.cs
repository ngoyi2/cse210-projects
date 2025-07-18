using System;

public class Word
{
    private string _texte;
    private bool _isHiden;

    // okey now lets create a consstractors

    public Word(string text) // 01
    {
        _texte = text;
        _isHiden = false; // i put this fallse to imitialise when words are not hiden
    }

    // This a propety that helps us to check if the word is hiden
    // This a propety that helps us to get the text of the word

    public bool IsHiden
    {
        get { return _isHiden; }
    }

    // this others Methodes

    public void Hide()
    {
        _isHiden = true; // this will hide the word 
    }

    public void Show()
    {
        _isHiden = false; // this will show the word
    }

    public string GetDisplayText()
    {  // so if the texte is hiden thenm return underscores maching word length  if not it return word it self.
        return _isHiden ? new string('_', _texte.Length) : _texte;
    }

}