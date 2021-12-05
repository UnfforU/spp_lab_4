using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;

[TestFixture]
class T3Test
{
    private Mock<IEnumerable<int>> a;
    private T3 t3;
    [SetUp]
    public void SetUp()
    {
        a = new Mock<IEnumerable<int>>();
        t3 = new T3(a.Object);
    }

    [Test]
    public void Function1()
    {
        var b = default(int);
        var c = default(string);
        t3.Function1(b, c);
        Assert.Fail("aotugenerated");
    }

    [Test]
    public void Function2()
    {
        t3.Function2();
        Assert.Fail("aotugenerated");
    }
}