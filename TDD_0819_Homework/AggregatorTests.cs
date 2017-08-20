using System;
using FluentAssertions;
using System.Collections.Generic;
using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD_0819_Homework
{
    [TestClass]
    public class AggregatorTests
    {
        [TestMethod]
        public void AggregateTest_輸入11筆_3筆一組_Cost總和_預期6_15_24_21()
        {
            // arrange
            var chunkSize = 3;
            var property = "Cost";
            var expected = new[] { 6, 15, 24, 21 };

            // act
            var actual = FakeCollectionAggregator.Aggregate(chunkSize, property);

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void AggregateTest_輸入11筆_4筆一組_Revenue總和_預期50_66_60()
        {
            // arrange
            var chunkSize = 4;
            var property = "Revenue";
            var expected = new[] { 50, 66, 60 };

            // act
            var actual = FakeCollectionAggregator.Aggregate(chunkSize, property);

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void AggregateTest_筆數輸入負數_預期拋ArgumentException()
        {
            // arrange
            var chunkSize = -1;
            var property = "";

            // act
            Action act = () => FakeCollectionAggregator.Aggregate(chunkSize, property);

            // assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void AggregateTest_尋找的欄位若不存在_預期拋ArgumentException()
        {
            // arrange
            var chunkSize = 3;
            var property = "NotExistedProperty";

            // act
            Action act = () => FakeCollectionAggregator.Aggregate(chunkSize, property);

            // assert
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void AggregateTest_筆數輸入0_回傳0()
        {
            // arrange
            var chunkSize = 0;
            var property = "Cost";
            var expected = new[] { 0 };

            // act
            var actual = FakeCollectionAggregator.Aggregate(chunkSize, property);

            // assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }

    internal class FakeCollectionAggregator : CollectionAggregator
    {
        public static int[] Aggregate(int chunkSize, string property)
        {
            var source = new List<object>
            {
                new {Id=1, Cost=1, Revenue=11, SellPrice=21},
                new {Id=2, Cost=2, Revenue=12, SellPrice=22},
                new {Id=3, Cost=3, Revenue=13, SellPrice=23},
                new {Id=4, Cost=4, Revenue=14, SellPrice=24},
                new {Id=5, Cost=5, Revenue=15, SellPrice=25},
                new {Id=6, Cost=6, Revenue=16, SellPrice=26},
                new {Id=7, Cost=7, Revenue=17, SellPrice=27},
                new {Id=8, Cost=8, Revenue=18, SellPrice=28},
                new {Id=9, Cost=9, Revenue=19, SellPrice=29},
                new {Id=10, Cost=10, Revenue=20, SellPrice=30},
                new {Id=11, Cost=11, Revenue=21, SellPrice=31},
            };

            return Aggregate(source, chunkSize, property);
        }
    }
}
