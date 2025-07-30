using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold all the video objects
        List<Video> videos = new List<Video>();

        // --- Video 1 ---
        Video video1 = new Video("C# Fundamentals Explained", "AUgustin ngoy", 1500); // 20 minutes
        video1.AddComment(new Comment("Auguslen ngoy", "Great explanation for beginners!"));
        video1.AddComment(new Comment("aulin ngoy", "Helped me understand abstraction better."));
        video1.AddComment(new Comment("Ausline ngoy", "Very clear and concise."));
        video1.AddComment(new Comment("Augulen ng", "Could you do a video on interfaces next? wow"));
        videos.Add(video1);

        // --- Video 2 ---
        Video video2 = new Video(" In searching for the boon 2025", "Wanderlust Adventures", 980); // 16 minutes 20 seconds
        video2.AddComment(new Comment("Iren ndelela", "Amazing scenery! My next vacation spot is decided."));
        video2.AddComment(new Comment("andre sabw", " i love this image!"));
        video2.AddComment(new Comment("Emanuel Ilung", "  the best one What camera do you use?"));
        videos.Add(video2);

        // --- Video 3 ---
        Video video3 = new Video("learnig C# in action", "AUST NGOY", 750); // 12 minutes 30 seconds
        video3.AddComment(new Comment("maman HElen", "My pasta turned out perfectly, thanks!"));
        video3.AddComment(new Comment("Papa salazard", "Simple and easy to follow steps."));
        video3.AddComment(new Comment("oncle Vung kapenbd", " brother Ngoy Can't wait to try this recipe!"));
        videos.Add(video3);

        // --- Video 4 (optional, but good for demonstrating the list) ---
        Video video4 = new Video("look at me as every boddy look you ", "MindBender Edu", 1800); // 30 minutes
        video4.AddComment(new Comment("Ngoyi", "the love in action, is the createst low of salvetion."));
        video4.AddComment(new Comment("Kabanga", "Finally, that is the aLL in life"));
        video4.AddComment(new Comment("Mike", "More videos like this, please!, i love it bro..."));
        videos.Add(video4);


        // Iterate through the list of videos and display their information
        Console.WriteLine("--- YouTube Videos Information ---");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            // Call the method to get the number of comments
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            // Iterate through the comments for the current video
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.CommenterName}: \"{comment.Text}\"");
            }
            Console.WriteLine(); // Add an empty line for better readability between videos
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
        }
    }
}