using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTable.Tests
{
    [TestClass]
    public class HashTableTest
    {
        private Table firstHashTable;
        private Table secondHashTable;
        private Table thirdHashTable;
        private HashFunctionFromVS hashFunctionMod100;
        private HashFunctionByMultiplication hashFunctionByMultiplication;
        private HashFunctionCalledPerfect hashFunctionCalledPerfect;
        private readonly string filePath = @"test.txt";

        [TestInitialize]
        public void Initialize()
        {
            hashFunctionMod100 = new HashFunctionFromVS();
            hashFunctionByMultiplication = new HashFunctionByMultiplication();
            hashFunctionCalledPerfect = new HashFunctionCalledPerfect();
            firstHashTable = new Table(hashFunctionMod100);
            secondHashTable = new Table(hashFunctionByMultiplication);
            thirdHashTable = new Table(hashFunctionCalledPerfect);
            firstHashTable.FillingTheTable(filePath);
            secondHashTable.FillingTheTable(filePath);
            thirdHashTable.FillingTheTable(filePath);
        }

        [TestCleanup]
        public void CleanUp()
        {
            firstHashTable.ClearTable();
            secondHashTable.ClearTable();
            thirdHashTable.ClearTable();
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
            => FindingTheWordWasTest(firstHashTable);

        [TestMethod]
        public void FindingTheWordWasForSecondTableTest()
            => FindingTheWordWasTest(secondHashTable);

        [TestMethod]
        public void FindingTheWordWasForThirdTableTest()
            => FindingTheWordWasTest(thirdHashTable);

        [TestMethod]
        public void RemovingOneWordForFirstHashTest()
            => RemovingOneWordTest(firstHashTable);

        [TestMethod]
        public void RemovingOneWordForSecondHashTest()
            => RemovingOneWordTest(secondHashTable);

        [TestMethod]
        public void RemovingOneWordForThirdHashTest()
            => RemovingOneWordTest(thirdHashTable);

        [TestMethod]
        public void AddingUserWordForFirstHashTest()
            => AddingUserWordTest(firstHashTable);

        [TestMethod]
        public void AddingUserWordForSecondHashTest()
            => AddingUserWordTest(secondHashTable);

        [TestMethod]
        public void AddingUserWordForThirdHashTest()
            => AddingUserWordTest(thirdHashTable);

        [TestMethod]
        public void AddingTheSameWordForFirstHashTest()
            => AddingTheSameWordTest(firstHashTable);

        [TestMethod]
        public void AddingTheSameWordForSecondHashTest()
            => AddingTheSameWordTest(secondHashTable);

        [TestMethod]
        public void AddingTheSameWordForThirdHashTest()
            => AddingTheSameWordTest(thirdHashTable);

        [TestMethod]
        public void DoubleRemoveForFirstHashTest()
            => DoubleRemoveTest(firstHashTable);

        [TestMethod]
        public void DoubleRemoveForSecondHashTest()
            => DoubleRemoveTest(secondHashTable);

        [TestMethod]
        public void DoubleRemoveForThirdHashTest()
            => DoubleRemoveTest(thirdHashTable);
    }
}
