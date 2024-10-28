using System;
using System.Collections.Generic;
using Kino.Models;

namespace Kino.Services
{
    public class SnackService
    {
        private List<Snack> snacks = new List<Snack>
        {
            new Snack { Name = "Popcorn", Price = 10 },
            new Snack { Name = "Napój", Price = 5 }
        };

        public void ShowSnacks()
        {
            for (int i = 0; i < snacks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {snacks[i].Name} - {snacks[i].Price} PLN");
            }
        }

        public Snack GetSnack(int index)
        {
            return snacks[index];
        }

        public int GetSnacksCount()
        {
            return snacks.Count;
        }
    }
}