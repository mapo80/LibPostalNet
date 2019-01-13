using LibPostalNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibPostalConsole
{
    class Program
    {
        /// <summary>
        /// An example of using the LibPostalNet library
        /// </summary>
        /// <param name="args">args[0] should be the path to libpostal data files</param>
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var dataPath = args[0];
                libpostal.LibpostalSetupDatadir(dataPath);
                libpostal.LibpostalSetupParserDatadir(dataPath);
                libpostal.LibpostalSetupLanguageClassifierDatadir(dataPath);
            }
            else
            {
                libpostal.LibpostalSetup();
                libpostal.LibpostalSetupParser();
                libpostal.LibpostalSetupLanguageClassifier();
            }

            var query = "Av. Beira Mar 1647 - Salgueiros, 4400-382 Vila Nova de Gaia";

            var response = libpostal.LibpostalParseAddress(query, new LibpostalAddressParserOptions());

            var x = response.Results;
            foreach (var result in x)
            {
                Console.WriteLine(result.ToString());
            }

            libpostal.LibpostalAddressParserResponseDestroy(response);

            var expansion = libpostal.LibpostalExpandAddress(query, libpostal.LibpostalGetDefaultOptions());
            foreach (var s in expansion.Expansions)
            {
                Console.WriteLine(s);
            }
            
            // Teardown (only called once at the end of your program)
            libpostal.LibpostalTeardown();
            libpostal.LibpostalTeardownParser();
            libpostal.LibpostalTeardownLanguageClassifier();
        }
    }
}
