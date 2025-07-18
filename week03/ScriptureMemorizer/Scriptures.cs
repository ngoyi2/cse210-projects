using System;
using System.Collections.Generic;
using System.Linq; // now that this is used for .Tolist(), .Tocount(), .where() etc ...

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random; // this one is for generating numbers here.

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random(); //it Initialise Random

        // we need to convert or Parse the text in words

        string[] rawWords = text.Split(new char[] {',', '.', ';', ':', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string rawWord in rawWords)
        {
           _words.Add(new Word(rawWord)); 
        } 
    }

    public void HideRandomWords(int count)
    {
    // this get of words that are not steel not yet hiden
    List<Word> availableWords = _words.Where(w => !w.IsHiden).ToList();
       if (availableWords.Count == 0)
        {
        return; // here all words are already hiden, and nothing to show or to do
        }

    // this shows  how many words to hide but dont hide more than availble.
      int wordsTohide = Math.Min(count, availableWords.Count);
       for (int i = 0; i < wordsTohide; i++)
       {
        //This serlect a random word from the availblewords 
        int indexTohide = _random.Next(0, availableWords.Count);
        availableWords[indexTohide].Hide();

        // we remoove the hiden word in from the availablewords list
        // we don't try to hid it again in this same call.
        availableWords.RemoveAt(indexTohide);
       }
    }
    
    public string GetDisplayText()
    {
        string fullText = string.Join("", _words.Select(w => w.GetDisplayText()));
    return $"{_reference.GetDisplayText()} {fullText}";

    }

    public bool IsCompletelyhiden()
    {
    // this one check if all words are hiden 

    return _words.All(w => w.IsHiden);
    // if i need to do this 
    //foreach (Word word in _words)
    //    if (!word.IsHiden)
     //   {
      //      return false // to find at list one word
       // }
    //return true; // here all words are hiden
    }
    

}
    
