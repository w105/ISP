using System;
using System.Media;

namespace Zadanie_1
{
    class Program
    {
        static void Main(string[] args)
        {
            SoundPlayer player = new SoundPlayer(@"banger-pluck-melody.wav");
            player.Play();
            Console.ReadKey();
        }

    }
}
