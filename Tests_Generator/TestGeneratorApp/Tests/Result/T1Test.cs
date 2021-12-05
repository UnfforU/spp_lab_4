using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;

[TestFixture]
class T1Test
{
    private Mock<IDisposable> a;
    private Mock<ICloneable> b;
    private T1 t1;
    [SetUp]
    public void SetUp()
    {
        var c = default(int);
        var d = default(string);
        a = new Mock<IDisposable>();
        b = new Mock<ICloneable>();
        t1 = new T1(a.Object, b.Object, c, d);
    }

    [Test]
    public void Function1()
    {
        var e = default(int);
        var f = default(int);
        var actual = t1.Function1(e, f);
        var expected = default(int);
        Assert.That(actual, Is.EqualTo(expected));
        Assert.Fail("aotugenerated");
    }

    [Test]
    public void Function2()
    {
        t1.Function2();
        Assert.Fail("aotugenerated");
    }
}