using LibPostalNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibPostalConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            libpostal.LibpostalSetup();
            libpostal.LibpostalSetupParser();

            var response = libpostal.LibpostalParseAddress("781 Franklin Ave Crown Heights Brooklyn NYC NY 11216 USA", new LibpostalAddressParserOptions());

            unsafe
            {
                //How to convert this?

                var x = response.Components;
            }

            libpostal.LibpostalAddressParserResponseDestroy(response);

            // Teardown (only called once at the end of your program)
            libpostal.LibpostalTeardown();
            libpostal.LibpostalTeardownParser();
        }
    }
}
