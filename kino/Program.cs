using System;
using System.Collections.Generic;
using Kino.Models;
using Kino.Services;

namespace Kino
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicjalizacja serwisów
            UserService userService = new UserService();
            MovieService movieService = new MovieService();
            ReservationService reservationService = new ReservationService();
            SnackService snackService = new SnackService();

            // Pętla główna programu
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== System Rezerwacji Kinowych ===");
                Console.WriteLine("1. Zaloguj się");
                Console.WriteLine("2. Zarejestruj się");
                Console.WriteLine("3. Wyjście");
                Console.Write("Wybierz opcję: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    Console.ReadKey();
                    continue;
                }

                if (choice == 3) break;

                string email = string.Empty;
                if (choice == 1)
                {
                    // Logowanie użytkownika
                    Console.Write("Podaj email: ");
                    email = Console.ReadLine();
                    Console.Write("Podaj hasło: ");
                    string password = Console.ReadLine();

                    if (userService.Login(email, password))
                    {
                        Console.WriteLine("Zalogowano pomyślnie!");
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowy email lub hasło.");
                        Console.ReadKey();
                        continue;
                    }
                }
                else if (choice == 2)
                {
                    // Rejestracja użytkownika
                    Console.Write("Podaj email: ");
                    email = Console.ReadLine();
                    Console.Write("Podaj hasło: ");
                    string password = Console.ReadLine();

                    userService.Register(email, password);
                    Console.WriteLine("Zarejestrowano pomyślnie!");
                }

                // Wybór filmu
                Console.Clear();
                Console.WriteLine("=== Wybór Filmu ===");
                movieService.ShowMovies();
                Console.Write("Wybierz film: ");
                int movieChoice;
                if (!int.TryParse(Console.ReadLine(), out movieChoice) || movieChoice < 1 || movieChoice > movieService.GetMoviesCount())
                {
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    Console.ReadKey();
                    continue;
                }
                Movie selectedMovie = movieService.GetMovie(movieChoice - 1);

                // Wybór godziny seansu
                Console.Clear();
                Console.WriteLine("=== Wybór Godziny Seansu ===");
                for (int i = 0; i < selectedMovie.ShowTimes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {selectedMovie.ShowTimes[i]}");
                }
                Console.Write("Wybierz godzinę seansu: ");
                int showTimeChoice;
                if (!int.TryParse(Console.ReadLine(), out showTimeChoice) || showTimeChoice < 1 || showTimeChoice > selectedMovie.ShowTimes.Count)
                {
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    Console.ReadKey();
                    continue;
                }
                string selectedShowTime = selectedMovie.ShowTimes[showTimeChoice - 1];

                // Wybór miejsc
                Console.Clear();
                Console.WriteLine("=== Wybór Miejsc ===");
                Console.Write("Podaj numery miejsc (oddzielone przecinkami): ");
                string seatsInput = Console.ReadLine();
                List<string> seats = new List<string>(seatsInput.Split(','));

                // Dodanie przekąsek
                List<string> selectedSnacks = new List<string>();
                Console.Clear();
                Console.WriteLine("Czy chcesz dodać przekąski? (tak/nie)");
                string snackChoice = Console.ReadLine();
                if (snackChoice.ToLower() == "tak")
                {
                    snackService.ShowSnacks();
                    Console.Write("Wybierz przekąskę: ");
                    int snackIndex;
                    if (!int.TryParse(Console.ReadLine(), out snackIndex) || snackIndex < 1 || snackIndex > snackService.GetSnacksCount())
                    {
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        Console.ReadKey();
                        continue;
                    }
                    Snack selectedSnack = snackService.GetSnack(snackIndex - 1);
                    // Dodaj przekąski do rezerwacji
                    selectedSnacks.Add(selectedSnack.Name);
                }

                // Tworzenie rezerwacji
                reservationService.MakeReservation(email, selectedMovie.Title, selectedShowTime, seats, selectedSnacks);

                // Podsumowanie rezerwacji
                Reservation reservation = new Reservation
                {
                    UserEmail = email,
                    MovieTitle = selectedMovie.Title,
                    ShowTime = selectedShowTime,
                    Seats = seats,
                    Snacks = selectedSnacks 
                };
                reservationService.ShowSummary(reservation);

                // Pożegnanie użytkownika
                Console.WriteLine("Dziękujemy za skorzystanie z naszego systemu!");
                Console.ReadKey();
            }
        }
    }
}