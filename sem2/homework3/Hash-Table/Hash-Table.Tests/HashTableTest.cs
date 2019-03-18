using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hash_Table.Tests
{
    [TestClass]
    public class HashTableTest
    {
        [TestInitialize]
        public void Initialize()
        {
            hashFunctionMod100 = new HashFunctionMod100();
            hashFunctionByMultiplication = new HashFunctionByMultiplication();
            hashFunctionCalledPerfect = new HashFunctionCalledPerfect();
            firstHash_Table = new Hash_Table(hashFunctionMod100);
            secondHash_Table = new Hash_Table(hashFunctionByMultiplication);
            thirdHash_Table = new Hash_Table(hashFunctionCalledPerfect);
            firstHash_Table.FillingTheTable(filePath);
            secondHash_Table.FillingTheTable(filePath);
            thirdHash_Table.FillingTheTable(filePath);
        }

        [TestCleanup]
        public void CleanUp()
        {
            firstHash_Table.ClearTable();
            secondHash_Table.ClearTable();
            thirdHash_Table.ClearTable();
        }

        public void FindingTheWordWasTest(Hash_Table hash_Table)
        {
            Assert.IsTrue(hash_Table.IsData("was"));
        }

        public void RemovingOneWordTest(Hash_Table hash_Table)
        {
            Assert.IsTrue(hash_Table.IsData("the"));
            hash_Table.RemoveData("the");
            Assert.IsFalse(hash_Table.IsData("the"));
        }

        public void AddingUserWordTest(Hash_Table hash_Table)
        {
            hash_Table.AddData("mathmech");
            Assert.IsTrue(hash_Table.IsData("mathmech"));
            hash_Table.RemoveData("mathmech");
            Assert.IsFalse(hash_Table.IsData("mathmech"));
        }

        public void AddingTheSameWordTest(Hash_Table hash_Table)
        {
            hash_Table.AddData("ololo");
            hash_Table.AddData("ololo");
            hash_Table.RemoveData("ololo");
            Assert.IsFalse(hash_Table.IsData("ololo"));
        }

        public void DoubleRemoveTest(Hash_Table hash_Table)
        {
            hash_Table.AddData("like_coding");
            hash_Table.RemoveData("like_coding");
            hash_Table.RemoveData("like_coding");
        }

        [TestMethod]
        public void FindingTheWordWasForFirstHashTest()
            => FindingTheWordWasTest(firstHash_Table);

        [TestMethod]
        public void FindingTheWordWasForSecondTableTest()
            => FindingTheWordWasTest(secondHash_Table);

        [TestMethod]
        public void FindingTheWordWasForThirdTableTest()
            => FindingTheWordWasTest(thirdHash_Table);

        [TestMethod]
        public void RemovingOneWordForFirstHashTest()
            => RemovingOneWordTest(firstHash_Table);

        [TestMethod]
        public void RemovingOneWordForSecondHashTest()
            => RemovingOneWordTest(secondHash_Table);

        [TestMethod]
        public void RemovingOneWordForThirdHashTest()
            => RemovingOneWordTest(thirdHash_Table);

        [TestMethod]
        public void AddingUserWordForFirstHashTest()
            => AddingUserWordTest(firstHash_Table);

        [TestMethod]
        public void AddingUserWordForSecondHashTest()
            => AddingUserWordTest(secondHash_Table);

        [TestMethod]
        public void AddingUserWordForThirdHashTest()
            => AddingUserWordTest(thirdHash_Table);

        [TestMethod]
        public void AddingTheSameWordForFirstHashTest()
            => AddingTheSameWordTest(firstHash_Table);

        [TestMethod]
        public void AddingTheSameWordForSecondHashTest()
            => AddingTheSameWordTest(secondHash_Table);

        [TestMethod]
        public void AddingTheSameWordForThirdHashTest()
            => AddingTheSameWordTest(thirdHash_Table);

        [TestMethod]
        public void DoubleRemoveForFirstHashTest()
            => DoubleRemoveTest(firstHash_Table);

        [TestMethod]
        public void DoubleRemoveForSecondHashTest()
            => DoubleRemoveTest(secondHash_Table);

        [TestMethod]
        public void DoubleRemoveForThirdHashTest()
            => DoubleRemoveTest(thirdHash_Table);

        private Hash_Table firstHash_Table;
        private Hash_Table secondHash_Table;
        private Hash_Table thirdHash_Table;
        private HashFunctionMod100 hashFunctionMod100;
        private HashFunctionByMultiplication hashFunctionByMultiplication;
        private HashFunctionCalledPerfect hashFunctionCalledPerfect;
        private string filePath = @"test.txt";
    }
}
