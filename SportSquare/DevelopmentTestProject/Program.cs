using SportSquare.VenueImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var importer = new VenueImporter();
            importer.ParseVenues();
        }
    }
}
