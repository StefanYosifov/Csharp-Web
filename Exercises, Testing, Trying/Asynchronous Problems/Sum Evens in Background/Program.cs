

long sum = 0;
Task.Run(() =>
{
    for (long i = 0; i < 1000000000; i ++)
    {
        if (i % 2 == 0)
        {
            sum += i;
        }
    }
});

while (true)
{
    string command = Console.ReadLine();
    if (command == "show")
    {
        Console.WriteLine(sum);
    }
}
