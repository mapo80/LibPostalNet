using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibPostalNet
{
    public partial class LibpostalNormalizeOptions
    {
        public string[] Langs
        {
            get
            {
                IList<string> _lang = new List<string>();

                unsafe
                {
                    for (int buc = 0; buc < (int)NumLanguages; buc++)
                    {
                        sbyte* pLang = Languages[buc];
                        _lang.Add(Marshal.PtrToStringAnsi((IntPtr)pLang));
                    }
                }

                return _lang.ToArray();
            }
        }
    }

    public partial class LibpostalAddressParserResponse
    {
        public List<KeyValuePair<string, string>> Results
        {
            get
            {
                var _results = new List<KeyValuePair<string, string>>();

                unsafe
                {
                    for (int buc = 0; buc < (int)NumComponents; buc++)
                    {
                        sbyte* pLabel = Labels[buc];
                        sbyte* pComponent = Components[buc];

                        _results.Add(new KeyValuePair<string, string>(Marshal.PtrToStringUTF8((IntPtr)pLabel), Marshal.PtrToStringUTF8((IntPtr)pComponent)));
                    }
                }

                return _results;
            }
        }
    }
}
