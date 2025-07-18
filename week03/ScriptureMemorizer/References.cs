using System;
using System.Diagnostics.Contracts;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse; // this is optional, used for ranges

    // lets create a  constructor for sigle verses like luk 8:16-19 
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0; // this shows that ther is not end verses
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book; 
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}