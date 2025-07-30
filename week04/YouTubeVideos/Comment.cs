//this is the file comment 

using System;

public class Comment
{
    // trhis is a properties to store the names of commenters and thyer text.

    public string CommenterName { get; set; }
    public string Text { get; set; }

    // here i will create a constructor for initializing a new commennt oject.
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
    // i can Add a methode here to display the comment, but i am going to do it directement in Program.cs 
}