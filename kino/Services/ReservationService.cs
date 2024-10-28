using System;
using System.Collections.Generic;
using System.IO;
using Kino.Models;

namespace Kino.Services
{
    public class ReservationService
    {
        private List<Reservation> reservations = new List<Reservation>();
        private const string filePath = "reservations.txt";

        public void MakeReservation(string userEmail, string movieTitle, string showTime, List<string> seats,List<string> snacks)
        {
            reservations.Add(new Reservation
            {
                UserEmail = userEmail,
                MovieTitle = movieTitle,
                ShowTime = showTime,
                Seats = seats,
                Snacks = snacks
            });
            SaveReservations(); 
        }

        public void ShowReservations()
        {
            foreach (var reservation in reservations)
            {
                Console.WriteLine(
                    $"{reservation.UserEmail} - {reservation.MovieTitle} - {reservation.ShowTime} - Miejsca: {string.Join(", ", reservation.Seats)}");
            }
        }

        public void ShowSummary(Reservation reservation)
        {
            Console.WriteLine("Podsumowanie rezerwacji:");
            Console.WriteLine($"Film: {reservation.MovieTitle}");
            Console.WriteLine($"Godzina: {reservation.ShowTime}");
            Console.WriteLine($"Miejsca: {string.Join(", ", reservation.Seats)}");
        }

        private void SaveReservations()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var reservation in reservations)
                {
                    writer.WriteLine(
                        $"{reservation.UserEmail},{reservation.MovieTitle},{reservation.ShowTime},{string.Join(";", reservation.Seats)},{string.Join(";",reservation.Snacks)}");
                }
            }
        }
    }
}