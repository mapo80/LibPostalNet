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
                        _lang.Add(Marshal.PtrToStringAuto((IntPtr)pLang));
                    }
                }

                return _lang.ToArray();
            }
        }
    }
    public partial class LibpostalAddressParserResponse
    {
        public Dictionary<string, string> Results
        {
            get
            {
                var _results = new Dictionary<string, string>();

                unsafe
                {
                    for (int buc = 0; buc < (int)NumComponents; buc++)
                    {
                        sbyte* pLabel = Labels[buc];
                        sbyte* pComponent = Components[buc];

                        _results.Add(Marshal.PtrToStringAuto((IntPtr)pLabel), Marshal.PtrToStringAuto((IntPtr)pComponent));
                    }
                }

                return _results;
            }
        }
    }
}
