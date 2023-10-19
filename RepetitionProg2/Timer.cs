using System.Threading;

public class TamaTimer
{
    private static Tamagotchi currentTama;

    public TamaTimer(Tamagotchi inTama)
    {
        currentTama = inTama;
    }

    public Thread timerThread = new(TimerFunction);

    public static void TimerFunction()
    {
        while (currentTama.GetAlive())
        {
            Thread.Sleep(10000);
            currentTama.Tick();
            TimerFunction();
        }
    }
}