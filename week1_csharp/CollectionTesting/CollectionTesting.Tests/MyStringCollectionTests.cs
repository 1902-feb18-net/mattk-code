using CollectionTestingLibrary;
using System;
using Xunit;

namespace CollectionTesting.Tests
{
    public class MyStringCollectionTests
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void AddShouldNotThrowException()
        {
            var collection = new MyStringCollection();

            collection.Add("abc");


        }

        [Fact]
        public void ContainsShouldBeTrueForContained()
        {
            var collection = new MyStringCollection();
            collection.Add("asdf");

            var result = collection.Contains("asdf");

            Assert.True(result);

        }

        [Fact]
        public void ContainsShouldBeFalseForNotContained()
        {
            var collection = new MyStringCollection();

            var result = collection.Contains("asdf");

            Assert.False(result);

        }

        //[Fact]
        //public void FailingTest()
        //{
        //    Assert.True(false);
        //}

        [Fact]
        public void RemoveEmptyShouldRemoveOneEmpty()
        {
            var sut = new MyStringCollection();

            sut.Add("");

            sut.RemoveEmpty();

            Assert.False(sut.Contains(""));


        }

        [Fact]
        public void GetFirstShouldGetFirstFromNonEmptyList()
        {
            var sut = new MyStringCollection();
            sut.Add("asdf");
            sut.Add("ghjk");


            var result = sut.GetFirst();

            Assert.Equal("asdf", result);
        }


        [Fact]
        public void GetFirstShouldThrowOnEmptyList()
        {
            var sut = new MyStringCollection();

            //try
            //{
            //    var result = sut.GetFirst();
            //}
            //catch (InvalidOperationException e)
            //{
            //    return;
            //}
            //Assert.True(false, "should have thrown InvalidOperationException");

            Assert.ThrowsAny<InvalidOperationException>(() => sut.GetFirst());
        }
    }
}
