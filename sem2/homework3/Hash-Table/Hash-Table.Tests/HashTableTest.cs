using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hash_Table.Tests
{
    [TestClass]
    public class HashTableTest
    {
        [TestInitialize]
        public void Initialize()
        {
            hashFunctionMod100 = new HashFunctionFromVS();
            hashFunctionByMultiplication = new HashFunctionByMultiplication();
            hashFunctionCalledPerfect = new HashFunctionCalledPerfect();
            firstHash_Table = new Table(hashFunctionMod100);
            secondHash_Table = new Table(hashFunctionByMultiplication);
            thirdHash_Table = new Table(hashFunctionCalledPerfect);
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

        public void FindingTheWordWasTest(Table hash_Table)
        {
            Assert.IsTrue(hash_Table.Exists("was"));
        }

        public void RemovingOneWordTest(Table hash_Table)
        {
            Assert.IsTrue(hash_Table.Exists("the"));
            hash_Table.RemoveData("the");
            Assert.IsFalse(hash_Table.Exists("the"));
        }

        public void AddingUserWordTest(Table hash_Table)
        {
            hash_Table.AddData("mathmech");
            Assert.IsTrue(hash_Table.Exists("mathmech"));
            hash_Table.RemoveData("mathmech");
            Assert.IsFalse(hash_Table.Exists("mathmech"));
        }

        public void AddingTheSameWordTest(Table hash_Table)
        {
            hash_Table.AddData("ololo");
            hash_Table.AddData("ololo");
            hash_Table.RemoveData("ololo");
            Assert.IsFalse(hash_Table.Exists("ololo"));
        }

        public void DoubleRemoveTest(Table hash_Table)
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

        private Table firstHash_Table;
        private Table secondHash_Table;
        private Table thirdHash_Table;
        private HashFunctionFromVS hashFunctionMod100;
        private HashFunctionByMultiplication hashFunctionByMultiplication;
        private HashFunctionCalledPerfect hashFunctionCalledPerfect;
        private string filePath = @"test.txt";
    }
}
