using System;
using System.Collections.Generic;
using System.Linq;

namespace WolfIsland
{
    public class SimulationEngine
    {
        public int GridSize { get; private set; }
        public List<Rabbit> Rabbits { get; private set; }
        public List<Predator> Predators { get; private set; }

        public List<string> EventLog { get; private set; } = new List<string>();

        private Random rnd = new Random();

        public SimulationEngine(int gridSize)
        {
            GridSize = gridSize;
            Rabbits = new List<Rabbit>();
            Predators = new List<Predator>();
        }

        // створює початкову популяцію кроликів та вовків
        public void InitializePopulation()
        {
            Rabbits.Clear();
            Predators.Clear();
            EventLog.Clear();
            EventLog.Add("🌍 Світ створено");

            for (int i = 0; i < 10; i++) Rabbits.Add(new Rabbit(rnd.Next(GridSize), rnd.Next(GridSize))); //10 кроликів
            for (int i = 0; i < 15; i++) Predators.Add(new Predator(rnd.Next(GridSize), rnd.Next(GridSize), false)); //15 вовків
            for (int i = 0; i < 12; i++) Predators.Add(new Predator(rnd.Next(GridSize), rnd.Next(GridSize), true)); //12 вовчиць
        }

        // виконує один крок симуляції: рух, розмноження, взаємодія
        public void PerformStep(int step)
        {
            EventLog.Clear();
            int preRabbits = Rabbits.Count;
            int prePredators = Predators.Count;

            // рух кроликів та їх розмноження
            int rabbitsBorn = 0; 
            List<Rabbit> newRabbits = new List<Rabbit>();
            foreach (var r in Rabbits)
            {
                MoveRandomly(r);
                // розмноження кроликів
                if (rnd.NextDouble() < 0.2 && (Rabbits.Count + newRabbits.Count) < 200) //ліміт 200 кроликів
                {
                    newRabbits.Add(new Rabbit(r.X, r.Y));
                    rabbitsBorn++;
                }
            }
            Rabbits.AddRange(newRabbits);
            if (rabbitsBorn > 0) EventLog.Add($"[{step}] 🐰 +{rabbitsBorn} кроликів");

            // рух хижаків
            foreach (var p in Predators)
            {
                var targetRabbit = Rabbits.FirstOrDefault(r => Math.Abs(r.X - p.X) <= 1 && Math.Abs(r.Y - p.Y) <= 1);
                if (targetRabbit != null)
                {
                    p.X = targetRabbit.X;
                    p.Y = targetRabbit.Y;
                }
                else
                {
                    bool movedToFemale = false;
                    if (!p.IsFemale)
                    {
                        var targetFemale = Predators.FirstOrDefault(f => f.IsFemale && Math.Abs(f.X - p.X) <= 1 && Math.Abs(f.Y - p.Y) <= 1);
                        if (targetFemale != null)
                        {
                            p.X = targetFemale.X;
                            p.Y = targetFemale.Y;
                            movedToFemale = true;
                        }
                    }
                    if (!movedToFemale) MoveRandomly(p);
                }
            }

            // взаємодія хижаків та кроликів, а також розмноження хижаків
            List<Predator> newCubs = new List<Predator>();

            // групування хижаків за їхніми координатами
            var groupedPredators = Predators.GroupBy(p => new { p.X, p.Y });

            foreach (var group in groupedPredators)
            {
                int x = group.Key.X;
                int y = group.Key.Y;

                // шукаю кроликів лише в цій конкретній локації
                var cellRabbits = Rabbits.Where(r => r.X == x && r.Y == y).ToList();
                var cellPredators = group.ToList();

                // логіка полювання
                foreach (var p in cellPredators)
                {
                    if (cellRabbits.Count > 0)
                    {
                        Rabbits.Remove(cellRabbits[0]);
                        cellRabbits.RemoveAt(0);
                        p.Energy = Math.Min(p.Energy + 1.0, 5.0);
                    }
                    else
                    {
                        p.Energy -= 0.1;
                    }
                }

                // логіка розмноження хижаків 
                if (cellRabbits.Count == 0)
                {
                    var males = cellPredators.Where(p => !p.IsFemale && p.Energy >= 0.3).ToList();
                    var females = cellPredators.Where(p => p.IsFemale && p.Energy >= 0.3).ToList();
                    int pairs = Math.Min(males.Count, females.Count);

                    for (int i = 0; i < pairs; i++)
                    {
                        males[i].Energy -= 0.15;
                        females[i].Energy -= 0.15;
                        var cub = new Predator(x, y, rnd.NextDouble() > 0.5) { Energy = 0.3 };
                        newCubs.Add(cub);
                    }
                }
            }

            // видалення загиблих хижаків
            int deadCount = Predators.Count(p => p.Energy <= 0.001);
            Predators.RemoveAll(p => p.Energy <= 0.001);
            if (deadCount > 0) EventLog.Add($"[{step}] 💀 -{deadCount} хижаків загинуло");

            if (newCubs.Count > 0)
            {
                EventLog.Add($"[{step}] 🐺 +{newCubs.Count} вовченят");
                Predators.AddRange(newCubs);
            }
        }

        private void MoveRandomly(Animal a)
        {
            a.X = Math.Max(0, Math.Min(GridSize - 1, a.X + rnd.Next(-1, 2)));
            a.Y = Math.Max(0, Math.Min(GridSize - 1, a.Y + rnd.Next(-1, 2)));
        }
    }
}