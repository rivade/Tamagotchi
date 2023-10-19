System.Console.WriteLine("Name your tamagotchi:");
Tamagotchi tamagotchi = new(Console.ReadLine());

TamaTimer timer = new(tamagotchi);
timer.timerThread.Start();

while (tamagotchi.GetAlive())
{
    Console.Clear();
    tamagotchi.Draw();
    tamagotchi.Actions();
}