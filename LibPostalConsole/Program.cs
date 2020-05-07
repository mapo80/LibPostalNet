using LibPostalNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibPostalConsole {
    internal class Program {
        /// <summary>
        /// An example of using the LibPostalNet library
        /// </summary>
        /// <param name="args">args[0] should be the path to libpostal data files</param>
        private static void Main(string[] args) {
            string dataPath = Console.ReadLine();
            libpostal.LibpostalSetupDatadir(dataPath);
            libpostal.LibpostalSetupParserDatadir(dataPath);
            libpostal.LibpostalSetupLanguageClassifierDatadir(dataPath);

            var query = "";
            while (!string.IsNullOrWhiteSpace(query = Console.ReadLine())) {
                LibpostalAddressParserResponse response =
                    libpostal.LibpostalParseAddress(query, new LibpostalAddressParserOptions());

                List<KeyValuePair<string, string>> x = response.Results;
                foreach (KeyValuePair<string, string> result in x) {
                    Console.WriteLine(result.ToString());
                }

                libpostal.LibpostalAddressParserResponseDestroy(response);

                LibpostalNormalizeResponse expansion =
                    libpostal.LibpostalExpandAddress(query, libpostal.LibpostalGetDefaultOptions());
                foreach (string s in expansion.Expansions) {
                    Console.WriteLine(s);
                }
            }

            // Teardown (only called once at the end of your program)
            libpostal.LibpostalTeardown();
            libpostal.LibpostalTeardownParser();
            libpostal.LibpostalTeardownLanguageClassifier();
        }
    }
}