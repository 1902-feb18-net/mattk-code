using System;
using Xunit;

namespace ML.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(10000)]
        public void AddedItemsShouldBeContained(int value)
        {
            var list = new MemoryList<int>();

            list.Add(value);

            Assert.True(list.Contains(value));

        }

        [Fact]
        public void RemovedItemsShouldNotBeContained()
        {
            var list = new MemoryList<int>();

            list.Add(5);
            list.Remove(5);

            Assert.True(list.Contains(5));
        }

        [Fact]
        public void AddShouldNotThrowException()
        {
            var list = new MemoryList<int>();

            list.Add(5);
        }

        [Fact]
        public void ContainsShouldBeTrueForContained()
        {
            var list = new MemoryList<int>();

            list.Add(6);

            var result = list.Contains(6);
            Assert.True(result);

        }

        [Fact]
        public void ContainsShouldBeFalseForNotContained()
        {
            var list = new MemoryList<int>();

            list.Add(7);
            list.Remove(7);

            var result = list.Contains(7);
            Assert.False(result);

        }

        [Fact]
        public void HasContainedShouldBeTrueForHasContained()
        {
            var list = new MemoryList<int>();

            list.Add(8);

            var result = list.HasContained(8);

            Assert.True(result);
        }

        [Fact]
        public void HasContainedShouldBeTrueForHasContainedAndRemoved()
        {
            var list = new MemoryList<int>();
            list.Add(9);
            list.Remove(9);

            var result = list.HasContained(9);

            Assert.True(result);

        }

        [Fact]
        public void HasContainedShouldBeFalseForHasNotContained()
        {
            var list = new MemoryList<int>();

            var result = HasContained(10);

            Assert.False(result);

        }

        

    }
}
