
while (true)
{
    string command=Console.ReadLine();
    if (command == "show")
    {
        Console.WriteLine(SumInRange());
    } 
}



static long SumInRange()
{
    return Task.Run(() =>
    {
        long sum = 0;
        for (int i = 0; i <= 100000; i += 2)
        {
            sum += i;
        }
        return sum;
    }).Result;
}