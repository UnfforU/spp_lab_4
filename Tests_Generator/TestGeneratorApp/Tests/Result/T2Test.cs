using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;

[TestFixture]
class T2Test
{
    private T2 t2;
    [SetUp]
    public void SetUp()
    {
        t2 = new T2();
    }

    [Test]
    public void Function1()
    {
        t2.Function1();
        Assert.Fail("aotugenerated");
    }

    [Test]
    public void Function2()
    {
        t2.Function2();
        Assert.Fail("aotugenerated");
    }
}