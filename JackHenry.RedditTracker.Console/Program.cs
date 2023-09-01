// See https://aka.ms/new-console-template for more information

using Reddit;

Console.WriteLine("Hello, World!");
var r = new RedditClient("SgzkNQuIzBP30zPmA8nJGg");
Console.WriteLine(r.Account.Me.);
Console.ReadLine();