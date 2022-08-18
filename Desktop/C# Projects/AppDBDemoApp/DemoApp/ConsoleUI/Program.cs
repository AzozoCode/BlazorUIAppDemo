using DemoLibrary;

Console.Write("Enter your First Name: ");
string? firstname = Console.ReadLine();

Console.Write("Enter your Last Name: ");
string? lastname = Console.ReadLine();

string fullname =  Library.JoinName(firstname, lastname);

Console.WriteLine($"Hello {fullname}");

