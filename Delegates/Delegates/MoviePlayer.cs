using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Delegates
{
    public class MoviePlayer
    {
        public Movie CurrentMovie { get; set; }

        // a delegate type is a name for a function with a particular signature 
        // (return value and parameters)
        public delegate void MovieFinishedHandler();


        // This is an event member, every event has a delegate type to indicate what kind of functions
        // can be subscribed to the event.
        // "there will be a MovieFinished event, and you can subscribe to it
        //  with any MovieFinishedHandler, i.e., and void-return, zeroparam function."
        public event MovieFinishedHandler MovieFinished;

        // Action type is for void-returning functions
        // For Action the type parameters are all the parameters of the functions
        // Func type is for all other functipons
        // For Func, the last type parameter is for the return type.
        public event Action<string> DiscEjected;

        public bool Play()
        {
            Thread.Sleep(3000);

            // fire event
            //if (MovieFinished != null)
            //{
            //    MovieFinished();
            //}
            // ?. is a special operator called the null-coalescing operator
            // if the thing to the left of it is null, it simply returns null.
            // if the thing to the left is not null, it will behave like .

            // ?? is the null-coalescing operator
            // a ?? b, that means, return a, unless it's null, in which case return b.

            MovieFinished?.Invoke();
            // this calls all event subscribers

            DiscEjected?.Invoke(CurrentMovie.ToString());
            return true;
        }



    }
}
