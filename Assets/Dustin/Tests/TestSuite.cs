using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using Dustin.Scripts.API;

namespace Dustin.Tests
{
    public class TestSuite
    {
        private Item _itemDropped;
        private Resource _resource;
        private Inventory _inventory;
        
        [SetUp]
        public void SetUp()
        {
            _itemDropped = new Item("test item");
            _resource = new Resource("test resource", _itemDropped, 1, 1);
            _inventory = new Inventory();
        }

        [TearDown]
        public void TearDown()
        {
        }
        
        [Test]
        public void TestCanExploitResource()
        {

            var result = _resource.ExploitResource(1);
            Assert.IsNotEmpty(result);
            Assert.True(result.Length == 1);
            Assert.True(result[0].Name == _itemDropped.Name);
        }
        
        [Test]
        public void TestCanCollectItem()
        {

            Assert.IsEmpty(_inventory.Items);
            var result = _inventory.CollectItem(_itemDropped);
            Assert.True(result);
            Assert.IsNotEmpty(_inventory.Items);
            Assert.Contains(_itemDropped, _inventory.Items);
        }
        
        // A Test behaves as an ordinary method
        [Test]
        public void TestSuiteSimplePasses()
        {
            // Use the Assert class to test conditions
            Assert.Pass("pass by default");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestSuiteWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            Assert.Pass("pass by default");
            yield return null;
        }
    }
}
