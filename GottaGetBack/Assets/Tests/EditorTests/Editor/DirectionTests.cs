using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using CharacterControl;

public class DirectionTests
{
    [Test]
    public void TestXYInputsAreZero()
    {
        PlayerController testPlayer = new PlayerController();

        Assert.AreEqual( 0.000000f, testPlayer.xInput );
        Assert.AreEqual( 0.000000f, testPlayer.yInput );
    }

    [Test]
    public void TestingDesiredDirectionIsZero()
    {
        PlayerController testPlayer = new PlayerController();

        Assert.AreEqual( Vector2.zero, testPlayer.desiredDirection );
    }

    [Test]
    public void TestMousePositionIsZero()
    {
        PlayerController testPlayer = new PlayerController();

        Assert.AreEqual( Vector2.zero, testPlayer.mousePosition );
    }
}
