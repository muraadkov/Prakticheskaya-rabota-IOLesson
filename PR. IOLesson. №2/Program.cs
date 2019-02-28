using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Interfejsy
{
    class Program
    {
        static void Main(string[] args)
        {
            //2 задание
            string path = string.Empty;
            Console.WriteLine("Программа для создания файла");
            Console.WriteLine("Выберите диск, в котором хотите создать файл: ");

            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                if (drives[i].IsReady)
                {
                    Console.WriteLine($"{i}.{drives[i].Name}");
                }
            }
            Console.WriteLine("Выберите диск, в котором хотите создать файл, написав его порядковый номер: ");
            var number = int.Parse(Console.ReadLine());
            path = drives[number].Name;
            Console.WriteLine($"Выбран диск {path}");
            foreach (var directory in drives[number].RootDirectory.EnumerateDirectories())
            {
                Console.WriteLine($"Папка {directory.Name}");
            }
            Console.WriteLine("Напишите название папки, которую хотите создать: ");
            var directoryName = Console.ReadLine();
            path += directoryName;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Console.WriteLine("Напишите название файла, который хотите создать: ");
            var fileName = Console.ReadLine();
            path += @"\" + fileName;
            if (!File.Exists(path))
            {
                using (File.Create(path)) ;
            }
            Console.WriteLine("Введите своё имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите свой возраст: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите свою фамилию: ");
            string familiya = Console.ReadLine();
            using (var streamwriter = new StreamWriter(path))
            {
                streamwriter.WriteLine("Имя: " + name);
                streamwriter.WriteLine("Фамилия: " + familiya);
                streamwriter.WriteLine("Возраст: " + age);
            }
            Console.Read();
        }
    }
}
