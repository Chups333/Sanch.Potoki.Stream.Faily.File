using System;
using System.IO;
using System.Text;

namespace Sanch.Potoki.Stream.Faily.File
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.OutputEncoding = Encoding.ASCII; - можно менять кодировку консоли
            //открыть файл
            //прочитать или записать
            //правильно закрыть чтоб не потерять данные

            //позволяет создать объект потока и автоматически вызывать команду закрытия при выходе из этой области
            using (var sw = new StreamWriter("my.txt", true, Encoding.UTF8)) //позволяет создать объект доступный внутри этих скобок и при выходе это объект будет уничтожен диспулс
            {
                // using (var sw = new StreamWriter ("my.txt")) - удаляет прошлые записи и пишит заново (перезапись)
                // using (var sw = new StreamWriter ("my.txt", true)) - дописывает(приписывает )
                // using (var sw = new StreamWriter ("my.txt", true, Encoding.UTF8)) - кодировка
                sw.Write("Hello"); // запись данных в файл
                sw.WriteLine("World");
                sw.WriteLine("Привет");
            }

            using (var sr = new StreamReader("my.txt", Encoding.UTF8))
            {
                //while (!sr.EndOfStream) // читаем файл построчно
                //{
                //    Console.WriteLine(sr.ReadLine);
                //}
                //sr.CurrentEncoding - кодировка потока
                //sr.DiscardBufferedData(); - возвращает потоко в начало 1
                //sr.BaseStream.Seek(0, SeekOrigin.Begin); - возвращает потоко в начало 1.1
                var text = sr.ReadToEnd(); // прочитает файл от начала до конца
               
                Console.WriteLine(text);
                Console.ReadKey();

            }


        }
    }
}
