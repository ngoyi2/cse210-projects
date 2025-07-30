//This class will represent a YouTube video and contain a list of `Comment` objects.

// this is a File Video.cs

using System;
using System.Collections.Generic; // Required for List<>

public class Video
{
    // Properties to track the video's details
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; } // Length in seconds

    // Private field to store the list of comments
    private List<Comment> _comments;

    // Constructor to initialize a new Video object
    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
        _comments = new List<Comment>(); // Initialize the list of comments
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to get the number of comments for this video (abstraction in action!)
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to get the list of comments (for iteration in Program.cs)
    public List<Comment> GetComments()
    {
        return _comments;
    }
}