using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UpgradeSystemTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void BuyUpgrade_IncreaseJump()
    {
        // Arrange
        var upgrades = new UpgradeSystem(20);
        float puloInicial = upgrades.JumpForce;

        // Act
        bool comprado = upgrades.TryUpgrade(UpgradeType.Jump);

        // Assert
        Assert.IsTrue(comprado);
        Assert.AreEqual(puloInicial + 1f, upgrades.JumpForce);
        Assert.AreEqual(12, upgrades.Points);
    }

    [Test]
    public void BuyUpgrade_IncreaseSpeed()
    {
        // Arrange
        var upgrades = new UpgradeSystem(20);
        float velocidadeInicial = upgrades.Speed;

        // Act
        bool comprado = upgrades.TryUpgrade(UpgradeType.Speed);

        // Assert
        Assert.IsTrue(comprado);
        Assert.AreEqual(velocidadeInicial + 1f, upgrades.Speed);
        Assert.AreEqual(15, upgrades.Points);
    }

    [Test]
    public void BuyUpgrade_IncreaseCoyoteTime()
    {
        // Arrange
        var upgrades = new UpgradeSystem(20);
        float coyoteTimeInicial = upgrades.CoyoteTime;
        // Act
        bool comprado = upgrades.TryUpgrade(UpgradeType.CoyoteTime);

        // Assert
        Assert.IsTrue(comprado);
        Assert.AreEqual(coyoteTimeInicial + 0.05f, upgrades.CoyoteTime);
        Assert.AreEqual(17, upgrades.Points);
    }

    [Test]
    public void BuyUpgrade_InsufficientPoints_DoesNotBuy()
    {
        // Arrange
        var upgrades = new UpgradeSystem(2);
        float puloInicial = upgrades.JumpForce;

        // Act
        bool comprado = upgrades.TryUpgrade(UpgradeType.Jump);

        // Assert
        Assert.IsFalse(comprado);
        Assert.AreEqual(puloInicial, upgrades.JumpForce);
        Assert.AreEqual(2, upgrades.Points);
    }

    [Test]
    public void BuyUpgrade_AtMaxLevel_DoesNotBuy()
    {
        // Arrange
        var upgrades = new UpgradeSystem(1000);

        for (int i = 0; i < 5; i++)
            upgrades.TryUpgrade(UpgradeType.Jump);

        int pontosAntes = upgrades.Points;

        // Act
        bool comprado = upgrades.TryUpgrade(UpgradeType.Jump);

        // Assert
        Assert.IsFalse(comprado);
        Assert.AreEqual(10f, upgrades.JumpForce);
        Assert.AreEqual(pontosAntes, upgrades.Points);
    }
}
