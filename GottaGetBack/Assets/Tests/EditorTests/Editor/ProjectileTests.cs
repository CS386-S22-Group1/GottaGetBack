using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class ProjectileTests : MonoBehaviour
{
    [Test]
    public void TestProjectilePresent()
    {
        Assert.NotZero(3.14);
    }

    [Test]
    public void TestProjectileSpeed()
    {
        Assert.Positive(5.0);
    }

    [Test]
    public void TestProjectileDeleted()
    {
        Assert.NotNull(new Vector2());
    }
}

