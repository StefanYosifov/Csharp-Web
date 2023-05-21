

//int minNumber=int.Parse(Console.ReadLine());
//int maxNumber=int.Parse(Console.ReadLine());
//Thread newThread = new Thread(() => PrintNumbersInRange(minNumber, maxNumber));
//newThread.Start();
//string canIStillRequiredInput = Console.ReadLine();
//newThread.Join();
//Console.WriteLine("Finished work");

Console.WriteLine("Hi");

var firstTask = Task.Run(() =>
{
    PrintNumbersInRange(0, 10000);
});


var secondTask = Task.Run(() =>
{
    PrintNumbersInRange(10000,15000);
});


Thread thread = new Thread(()=>PrintNumbersInRange(15000,20000));
Thread thread2 = new Thread(() => PrintNumbersInRange(20000, 25000));
thread.Start();
thread2.Start();

thread.Join();
thread2.Join();



Task.WaitAll(firstTask, secondTask);


static void PrintNumbersInRange(int min, int max)
{
    for (var i = min; i <= max; i++)
    {
        Console.WriteLine(i);
    }
}