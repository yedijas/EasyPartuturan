using System;
using EPLogic;

namespace EPConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrangBatak siAdit = new OrangBatak("Adit", "Situmeang", Gender.Male);
            siAdit.AnaknyaSi(new OrangBatak("Diapari", "Situmeang", Gender.Male));
            //siAdit.AnaknyaSi(siAdit);
        }
    }
}