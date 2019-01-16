using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibPostalNet;

namespace Tests
{
    [TestClass]
    public class Simple
    {
        [ClassInitialize]
        public static void SetupSimpleTests(TestContext testContext)
        {
            var dataPath = "C:\\libpostal";
            Assert.IsTrue(libpostal.LibpostalSetupDatadir(dataPath));
            Assert.IsTrue(libpostal.LibpostalSetupParserDatadir(dataPath));
            Assert.IsTrue(libpostal.LibpostalSetupLanguageClassifierDatadir(dataPath));
        }

        [ClassCleanup]
        public static void TeardownSimpleTests()
        {
            libpostal.LibpostalTeardown();
            libpostal.LibpostalTeardownParser();
            libpostal.LibpostalTeardownLanguageClassifier();
        }

        [TestMethod]
        public void BasicTest()
        {
            var query = "Av. Beira Mar 1647 - Salgueiros, 4400-382 Vila Nova de Gaia";

            var response = libpostal.LibpostalParseAddress(query, new LibpostalAddressParserOptions());
            Assert.IsNotNull(response.Results, "Parse had a null response");
            Assert.AreEqual((ulong)5, response.NumComponents, "Number of parsed elements incorrect.");

            libpostal.LibpostalAddressParserResponseDestroy(response);

            var expansion = libpostal.LibpostalExpandAddress(query, libpostal.LibpostalGetDefaultOptions());
            Assert.IsNotNull(expansion, "Expansion result is null");
            Assert.IsNotNull(expansion.Expansions, "Expansion array is null");
            Assert.IsTrue(expansion.Expansions.Length > 0, "Expansion had empty set of results");
        }

        [TestMethod]
        public void APBasedNormalization()
        {
            var query = "123 main st apt 2";

            var options = libpostal.LibpostalGetDefaultOptions();
            var expansion = libpostal.LibpostalExpandAddress(query, options);

            options.AddressComponents = LibpostalNormalizeOptions.LIBPOSTAL_ADDRESS_HOUSE_NUMBER|LibpostalNormalizeOptions.LIBPOSTAL_ADDRESS_UNIT;
            var expansion2 = libpostal.LibpostalExpandAddress(query, options);
            Assert.IsNotNull(expansion, "Expansion result is null");
            Assert.IsNotNull(expansion.Expansions, "Expansion array is null");
            Assert.IsTrue(expansion.Expansions.Length != expansion2.Expansions.Length, "Expansions should be different.");
        }
    }
}
