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

            unsafe
            {
                ulong n = ulong.MinValue;
                var expansions = libpostal.LibpostalExpandAddress(query, libpostal.LibpostalGetDefaultOptions(), ref n);
                for (ulong i = 0; i < n; i++)
                {
                    var normalized = new IntPtr(expansions[i]);
                    var str = Marshal.PtrToStringAnsi(normalized);
                    Console.WriteLine(str);
                }
            }

            libpostal.LibpostalAddressParserResponseDestroy(response);

            // Teardown (only called once at the end of your program)
            libpostal.LibpostalTeardown();
            libpostal.LibpostalTeardownParser();
            libpostal.LibpostalTeardownLanguageClassifier();
        }
    }
}
