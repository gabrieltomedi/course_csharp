﻿namespace Interface3.Devices
{
    internal class Scanner : Device, IScanner
    {
        public override void ProcessDoc(string document)
        {
            Console.WriteLine("Scanner Processing: " + document);
        }

        public string Scan()
        {
            return "Scanner scan Result";
        }
    }
}
