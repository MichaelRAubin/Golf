using System;
using System.Collections.Generic;
using System.Linq;
using Golf.Interfaces;

namespace Golf.Models
{
    public class App : IApp
    {
        Boolean active = true;
        public Course ActiveCourse { get; set; }
        public List<Player> Players { get; set; }
        public List<Course> Courses { get; set; }


        public void DisplayCourses()
        {
            Console.WriteLine("1. Freedom 9 Hole Executive\n2. Sandtrap 9 Hole Putt Putt\n3. Water Hazard 9 Hole Challenge Course");
        }

        public void DisplayPlayerResults()
        {
            int bestScore = 8000;
            string winnerName = "";
            foreach (Player n in Players)
            {
                // for (int i = 0; i < Players.Count; i++)
                // {
                int playScore = n.Scores.Sum();

                if (playScore < bestScore)
                {
                    bestScore = playScore;
                    winnerName = n.Name;
                }
                Console.Write($"Player {n.Name} score is {playScore}\n");
                // }
            }
            Console.WriteLine($"Winner is {winnerName}!!!");
        }

        public void Greeting()
        {
            Console.WriteLine("Welcome to Sunnyridge Golf Course\nHome of the 2019 Boise Golf Championships!");
            Console.WriteLine(" ");
            Console.WriteLine("Please select the Course number you want to play: 1,2, or 3");
            Console.WriteLine(" ");
        }

        public void Run()
        {
            Greeting();
            while (active)
            {
                DisplayCourses();
                SelectCourse();
            }
            SetPlayers();
            Console.Clear();
            Console.WriteLine("The lowest Score Wins!\nAre You ready to play?\nPress any key to continue");
            Console.ReadLine();
            for (int i = 1; i <= ActiveCourse.Holes.Count; i++)
            {
                Console.Clear();
                foreach (Player n in Players)
                {
                    Console.Write(n.Name + " " + "Hole" + " " + i + ":");
                    string playerScore = Console.ReadLine();
                    Int32.TryParse(playerScore, out int s);
                    n.Scores.Add(s);
                }
            }
            Console.Clear();
            DisplayPlayerResults();
        }

        public void SelectCourse()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    ActiveCourse = Courses[0];
                    active = false;
                    Console.WriteLine($"Thanks for choosing {ActiveCourse.Name}");
                    break;

                case "2":
                    ActiveCourse = Courses[1];
                    active = false;
                    Console.WriteLine($"Thanks for choosing {ActiveCourse.Name}");
                    break;

                case "3":
                    ActiveCourse = Courses[2];
                    active = false;
                    Console.WriteLine($"Thanks for choosing {ActiveCourse.Name}");
                    break;

                default:
                    Console.WriteLine("Not a valid Selection");
                    break;
            }
        }

        public void SetPlayers()
        {
            int i;
            Console.Write("Please enter the number of players: ");
            string playNum = Console.ReadLine();
            Int32.TryParse(playNum, out int p);
            for (i = 0; i < p; i++)
            {
                Console.Write("Enter Player Name: ");
                string name = Console.ReadLine();
                Player n = new Player(name);
                Players.Add(n);
            }
        }

        public void Setup()
        {
            Course course1 = new Course("Freedom 9 Hole Execuive");
            Course course2 = new Course("Sandtrap 9 Hole Putt Putt");
            Course course3 = new Course("Water Hazard 9 Hole Challenge Course");

            Hole par3 = new Hole(3);
            Hole par4 = new Hole(4);
            Hole par5 = new Hole(5);

            course1.Holes.Add(par3);
            course1.Holes.Add(par4);
            course1.Holes.Add(par3);
            course1.Holes.Add(par4);
            course1.Holes.Add(par5);
            course1.Holes.Add(par3);
            course1.Holes.Add(par4);
            course1.Holes.Add(par4);
            course1.Holes.Add(par3);

            course2.Holes.Add(par4);
            course2.Holes.Add(par3);
            course2.Holes.Add(par5);
            course2.Holes.Add(par4);
            course2.Holes.Add(par3);
            course2.Holes.Add(par3);
            course2.Holes.Add(par5);
            course2.Holes.Add(par4);
            course2.Holes.Add(par3);

            course3.Holes.Add(par3);
            course3.Holes.Add(par4);
            course3.Holes.Add(par4);
            course3.Holes.Add(par5);
            course3.Holes.Add(par3);
            course3.Holes.Add(par4);
            course3.Holes.Add(par3);
            course3.Holes.Add(par4);
            course3.Holes.Add(par3);

            Courses.Add(course1);
            Courses.Add(course2);
            Courses.Add(course3);

        }

        public App()
        {
            Players = new List<Player>();
            Courses = new List<Course>();

        }

    }
}