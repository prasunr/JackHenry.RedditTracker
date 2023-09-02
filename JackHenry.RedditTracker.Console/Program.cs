// See https://aka.ms/new-console-template for more information

using Reddit;

Console.WriteLine("Hello, World!");
var r = new RedditClient("SgzkNQuIzBP30zPmA8nJGg",null, "fOeevmjn8FXffKH4tZRvxePTRS5g0g");
Console.WriteLine(r.Account.Me.Fullname);
Console.ReadLine();