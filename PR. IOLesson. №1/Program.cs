using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace PR.IOLesson._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 задание
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
            Console.WriteLine("Напишите название файла, который хотите открыть: ");
            var fileName = Console.ReadLine();
            using (File.OpenWrite(fileName)) ;
            path += @"\" + fileName;

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
                string newData = Encoding.UTF8.GetString(buffer);
                var countBytes = fileStream.Length;
                Console.WriteLine("Текст в файле: " + newData);
                Console.WriteLine("Число байтов: " + countBytes);
            }
        }
    }
}
