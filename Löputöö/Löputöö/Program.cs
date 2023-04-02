using System.Text;
using System.Text.RegularExpressions;
using Löputöö;

namespace Löputöö;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Anna oma meetodi valik: 1 - Sum|2 - SingleOrDefault|" +
                    " 3 - SingleOrDefault1| 4 - Max| 5 - Empty| 6 - CreateFile| 7 - Pyramid");
        int valik = Convert.ToInt32(Console.ReadLine());

        switch (valik)
        {
            case 1:
                Sum();
                break;
            case 2:
                SingleOrDefault();
                break;
            case 3:
                SingleOrDefault1();
                break;
            case 4:
                Max();
                break;
            case 5:
                Empty();
                break;
            case 6:
                CreateFile();
                break;
            case 7:
                Pyramid();
                break;
            default:
                Console.WriteLine("Error: valikut pole");
                break;
        }
    }

    public static void Sum()
    {

        Console.WriteLine("Sum() method");

        int numbersSum = NumberList.numberList.Sum();


        Console.WriteLine("Sum: " + numbersSum);

    }
    public static void SingleOrDefault()
    {
        Console.WriteLine("SingleOrDefault() method - int List");
        // Antud meetod kasutab arvulist listi ja otsib meie poolt sisestatud arvu.
        Console.Write("Enter a number to search for: ");
        int number = int.Parse(Console.ReadLine());

        // Search the list for the specified number
        int foundNumber = NumberList.numberList.SingleOrDefault(n => n == number);

        if (foundNumber != 0)
        {
            Console.WriteLine("Found number: " + foundNumber);
        }
        else
        {
            Console.WriteLine("Number not found.");
        }
    }


    // SingleOrDefault meetod string listiga
    public static void SingleOrDefault1()
    {
        Console.WriteLine("SingleOrDefault() method - string List");
        Console.Write("Enter the name of a fruit to search for: ");
        string fruitName = Console.ReadLine();

        // Search the list for the specified fruit
        string foundFruit = Fruits.fruits.SingleOrDefault(fruit => fruit == fruitName);

        if (foundFruit != null)
        {
            Console.WriteLine("Found fruit: " + foundFruit);
        }
        else
        {
            Console.WriteLine("Fruit not found.");
        }
    }

    //Otsib arvulisest listist kõige suurema arvu.
    public static void Max()
    {
        Console.WriteLine("Max() method");
        int maxNumber = NumberList.numberList.Max();

        Console.WriteLine("Max number: " + maxNumber);
    }

    //Võtab etteantud arvulise listi, näitab selle esialgset kuju ja siis tühjnedab selle listi ning väljastab
    //tühja listi.
    public static void Empty()
    {
        Console.WriteLine("Empty() method");
        Console.WriteLine("Original list: ");
        foreach (var num in NumberList.numberList)
        {
            Console.Write(num + " ");
        }
        NumberList.numberList.Clear();

        Console.WriteLine("\nEmptied list:");
        foreach (var num in NumberList.numberList)
        {
            Console.Write(num + " ");
        }
    }

    //Loob faili ja püüab seda salvestada kasutaja poolt ettenähtud kohta.
    //Kui selline koht arvutis on juba olemas, küsib kas soovime faili täiendada
    // ja kui selline koht arvutis puudub, siis ütleb, et antud faili pole sinna
    //võimalik salvestada ja lõpetab programmi.
    public static void CreateFile()
    {
        Console.WriteLine("\nCreate File\n");
        try
        {
            Console.WriteLine("Please enter file name: ");
            string fileName = Console.ReadLine();
            Console.WriteLine("Please enter the path for your file: ");
            string path = Console.ReadLine();

            if (Directory.Exists(path))
            {
                string fullPath = Path.Combine(path, fileName);

                if (!File.Exists(fullPath))
                {
                    using (StreamWriter sw = File.CreateText(fullPath))
                    {
                        Console.WriteLine("Enter the text to write to the file:");
                        string text = Console.ReadLine();
                        sw.Write(text);
                    }
                    Console.WriteLine("File created successfully.");
                }
                else
                {
                    Console.WriteLine("File already exists at the specified path.");

                    // Ask the user if they want to modify the file
                    Console.Write("Do you want to modify the file? (y/n) ");
                    string answer = Console.ReadLine();

                    // If the user does not want to modify the file, exit the program
                    if (answer.ToLower() != "y")
                    {
                        return;
                    }

                    // Prompt the user for additional text to add to the file
                    Console.Write("Enter additional text: \n");
                    string additionalText = Console.ReadLine();

                    // Append the additional text to the file
                    using (StreamWriter writer = File.AppendText(fullPath))
                    {
                        writer.WriteLine(additionalText);
                    }

                    Console.WriteLine("Text added to file successfully.");
                }
            }
            else
            {
                throw new DirectoryNotFoundException("The specified path does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public static void Pyramid()
    {
        Console.WriteLine("Püramiid");

        Console.WriteLine("Mitmerealist püramiidi soovid?: ");
        int rows = Convert.ToInt32(Console.ReadLine());
        

        for (int i = 1; i <= rows; i++)
        {
            int num = 1;
            for (int j = 1; j <= rows - i; j++)
            {
                Console.Write(" ");
            }
            for (int k = 1; k <= 2 * i - 1; k++)
            {
                Console.Write(num);
                num++;
            }
            Console.WriteLine();
        }
    }
}