using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var moviePlayer = new MoviePlayer
            {
                CurrentMovie = Movie.StarWars4
            };

            MoviePlayer.MovieFinishedHandler handler = EjectDisc;

            // subscribe to an event
            moviePlayer.MovieFinished += handler;

            // unsubscribe to an event
            //moviePlayer.MovieFinished -= handler;
            moviePlayer.MovieFinished += EjectDisc;
            moviePlayer.MovieFinished += () =>
            {
                Console.WriteLine("handle event with block-body lambda.");
            };

            // with expression body, you can only put one line in
            moviePlayer.MovieFinished += () => Console.WriteLine("expression body");

            moviePlayer.DiscEjected += s => Console.WriteLine($"Ejecting {s}");

            Console.WriteLine("Playing movie...");

            moviePlayer.Play();

            Console.ReadLine();
        }

        private static void FuncAndAction()
        {
            Func<string, string, int> func = (s1, s2) => s1.Length + s2.Length;
            Action<string, string, int> action = (s1, s2, i) => Console.WriteLine(s1 + s2 + i);
        }
        public static void EjectDisc()
        {
            Console.WriteLine("Ejecting disc.");
        }
    }
}
