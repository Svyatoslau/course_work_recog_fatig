// See https://aka.ms/new-console-template for more information
while (true)
{
    Console.WriteLine("Do you have fatig?  0 - no, 1 -yes. ");

    int score = int.Parse(Console.ReadLine());

    
    string path = @"C:\Users\lvvm2\source\repos\FatigStatus\FatigStatus\evaluate_fatig.csv";

    
    DateTime now = DateTime.Now;
    string text = $"{now.Day}-{now.Month}-{now.Year};{now.TimeOfDay};{score}\n";

    //Console.WriteLine(text);

    File.AppendAllText(path, text);
}