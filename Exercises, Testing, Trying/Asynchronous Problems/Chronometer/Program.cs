IChronometer.IChronometer chronometer = new Chronometer.Chronometer();


var command = Console.ReadLine();
while (command != "exit")
{
    if (command == "start")
    {
        Task.Run(chronometer.Start);
    }
    else if (command == "stop")
    {
        chronometer.Stop();
    }
    else if (command == "lap")
    {
        var lap = chronometer.Lap();
        Console.WriteLine(lap);
    }
    else if (command == "laps")
    {
        var laps = chronometer.Laps;
        if (laps.Count > 0)
        {
            Console.WriteLine(string.Join(", ", laps));
        }
        else
        {
            Console.WriteLine("You don't have any laps");
        }
    }
    else if (command == "reset")
    {
        chronometer.Reset();
    }
    else if (command == "time")
    {
        Console.WriteLine(chronometer.GetTime);
    }

    command = Console.ReadLine();
}

chronometer.Stop();