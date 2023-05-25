using System.IO;

namespace Files1
{
    internal class Program
    {
        static void Main(string[] ars)
        {
            string sourcePath = @"C:\Users\gabri\OneDrive\Área de Trabalho\Udemy\C# Completo\Seção 13 - Trabalhando com arquivos\File1.txt";
            string targetPath = @"C:\Users\gabri\OneDrive\Área de Trabalho\Udemy\C# Completo\Seção 13 - Trabalhando com arquivos\File2.txt";

            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);
                string[] lines = File.ReadAllLines(sourcePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("An error ocured");
                Console.WriteLine(e.Message);
            }
        }
    }
}