using System;
using System.Collections.Generic;
using Golf.Interfaces;

namespace Golf.Models
{
    public class App : IApp
    {
        Boolean active = true;
        public Course ActiveCourse { get; set; }
        public List<Player> Players { get; set; }
        public List<Course> Courses { get; set; }
        public List<int> Scores { get; set; } //added from player.cs, "App" would not let me inherit from "player"

        public void DisplayCourses()
        {
            Console.WriteLine("1. Freedom 9 Hole Executive\n2. Sandtrap 9 Hole Putt Putt\n3. Water Hazard 9 Hole Challenge Course");
        }

        public void DisplayPlayerResults()
        {
            //TODO need to code
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
            for (int i = 1; i < ActiveCourse.Holes.Count; i++)
            {
                Console.Clear();
                foreach (Player n in Players)
                {
                    Console.WriteLine(n.Name + " " + "Hole" + " " + i);
                    string playerScore = Console.ReadLine();
                    Int32.TryParse(playerScore, out int s);
                    Scores.Add(s);
                    int playTotal = s++; //need to check
                    Console.WriteLine($"Total Score:" + " " + "{playTotal}");//need to check
                }
            }
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
            Console.WriteLine("Please enter the number of players");
            string playNum = Console.ReadLine();
            Int32.TryParse(playNum, out int p);
            for (i = 0; i < p; i++)
            {
                Console.WriteLine("Enter Player Name: ");
                string name = Console.ReadLine();
                Player n = new Player(name);
                Players.Add(n);
                Console.WriteLine($"You added player: {name}");
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
            List<Course> Courses = new List<Course>();
            Scores = new List<int>();
        }

    }
}