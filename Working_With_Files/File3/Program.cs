﻿using System.IO;

namespace Files3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\gabri\OneDrive\Área de Trabalho\Udemy\C# Completo\Seção 13 - Trabalhando com arquivos\File1.txt";
            StreamReader sr = null;

            try
            {
                sr = File.OpenText(path);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occured");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }
    }
}