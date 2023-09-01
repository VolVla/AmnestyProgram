using System;
using System.Collections.Generic;
using System.Linq;

namespace AmnestyProgram
{
    internal class Program
    {
        static void Main()
        {
            ProgramAmnesty programAmnesty = new ProgramAmnesty();
            ConsoleKey exitButton = ConsoleKey.Enter;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Для начало работы нажмите на любую клавишу");
                Console.ReadKey();
                Console.Clear();
                programAmnesty.AmnestyCriminal();
                Console.WriteLine($"\nВы хотите выйти из программы?Нажмите {exitButton}.\nДля продолжение работы нажмите любую другую клавишу");

                if (Console.ReadKey().Key == exitButton)
                {
                    Console.WriteLine("Вы вышли из программы");
                    isWork = false;
                }

                Console.Clear();
            }
        }
    }

    class ProgramAmnesty
    {
        private string _crime = "Антиправительственное";
        private List<Criminal> _criminals;

        public ProgramAmnesty() 
        {
            _criminals = new List<Criminal>
            {
                new Criminal("Petrov Alexand Vladimirovich ", "Саботаж"),
                new Criminal("Vladimir Nicolai Antonovich", "Антиправительственное"),
                new Criminal("Antonov Vladislav Petrovich", "Взяточнество"),
                new Criminal("Valeri Valeri Alexandrovich", "Антиправительственное"),
                new Criminal("Ivanov Ivan Gvozdikov", "Лоббизм")
            };
        }

        public void AmnestyCriminal() 
        {
            Console.WriteLine("Преступники до амнистии"); 
            ShowCriminal(_criminals);
            var filteredCriminal = _criminals.Where(criminal => criminal.Crime != _crime);
            _criminals = filteredCriminal.ToList();
            Console.WriteLine("\nВ нашей великой стране Арстоцка произошла амнистия!\nВсех людей, заключенных за преступление \"Антиправительственное\" освободили");
            Console.WriteLine("Оставшиеся преступники после амнистии");
            ShowCriminal(_criminals);
        }

        private void ShowCriminal(IEnumerable<Criminal> filteredCriminals)
        {
            foreach (var criminal in filteredCriminals)
            {
                Console.WriteLine($"Имя преступника {criminal.FullName},Преступление - {criminal.Crime}");
            }
        }
    }

    class Criminal
    {
        public Criminal(string fullName,string crime) 
        {
            FullName = fullName;
            Crime = crime;
        }

        public string FullName { get; private set; }
        public string Crime { get; private set; }
    }
}
