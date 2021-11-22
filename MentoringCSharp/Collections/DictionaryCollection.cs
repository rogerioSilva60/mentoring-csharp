using MentoringCSharp.ClassAndMethods;
using System;
using System.Collections.Generic;

namespace MentoringCSharp.Collections
{
    public class DictionaryCollection
    {
        public void Execute()
        {
            var films = new Dictionary<int, string>() {
                { 1, "The Imitation Game" },
                { 2, "Interstellar" },
                { 3, "Jobs" },
                { 4, "Transcendent" },
            };

            films.Add(5, "The Theory Of Everything");
            films.Add(6, "Avatar");
            films.Add(7, "Bicentennial Man");
            films.Add(8, "The Social Network");
            

            if(films.ContainsKey(7))
            {
                Console.WriteLine(films[7]);
            }

            Console.WriteLine($"Removed? {films.Remove(8)}" );

            foreach (var key in films.Keys)
            {
                Console.WriteLine(key);
            }

            foreach (var value in films.Values)
            {
                Console.WriteLine(value);
            }

            foreach (KeyValuePair<int, string> film in films)
            {
                Console.WriteLine($"{film.Value} your key is {film.Value}");
            }

            foreach (var film in films)
            {
                Console.WriteLine($"{film.Value} your key is {film.Value}");
            }


        }
    }
}
