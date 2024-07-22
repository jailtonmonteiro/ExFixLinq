using System.Globalization;
using System.Linq.Expressions;
using ExFixLinq.Entities;

namespace ExFixLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\Cursos\CSharp\ExFixLinq\ExFixLinq\Files\input.txt";

            double limit = 2000;

            List<Employee> list = new List<Employee>();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] data = sr.ReadLine().Split(',');
                        string name = data[0];
                        string email = data[1];
                        double salary = double.Parse(data[2], CultureInfo.InvariantCulture);
                        list.Add(new Employee(name, email, salary));
                    }
                }

                var people = list.Where(p => p.Salary > limit).OrderBy(p => p.Email).Select(p => p.Email);

                var sum = list.Where(p => p.Name[0] == 'M').Sum(s => s.Salary);

                foreach (string p in people)
                {
                    Console.WriteLine(p);
                }

                Console.WriteLine($"Soma de salários iniciados com M: {sum.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Existe algum erro com o arquivo, favo verificar!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}