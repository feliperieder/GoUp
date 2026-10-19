
using NUnit.Framework;

public class PlayerDoubleJumpTests
{
    [Test]
    public void InicializaComQuantidadeInformada()
    {
        // Arrange e Act
        PlayerDoubleJump pulo = new PlayerDoubleJump(3);

        // Assert
        Assert.AreEqual(3, pulo.ExtraJumps);
    }

    [Test]
    public void InicializaComValorNegativo_DeveSerZero()
    {
        // Arrange e Act
        PlayerDoubleJump pulo = new PlayerDoubleJump(-2);

        // Assert
        Assert.AreEqual(0, pulo.ExtraJumps);
    }

    [Test]
    public void InicializaAcimaDoMaximo_DeveLimitarEmCinco()
    {
        // Arrange e Act
        PlayerDoubleJump pulo = new PlayerDoubleJump(8);

        // Assert
        Assert.AreEqual(5, pulo.ExtraJumps);
    }

    [Test]
    public void AdicionaPuloExtra()
    {
        // Arrange
        PlayerDoubleJump pulo = new PlayerDoubleJump(2);

        // Act
        pulo.AddExtraJump(1);

        // Assert
        Assert.AreEqual(3, pulo.ExtraJumps);
    }

    [Test]
    public void AdicionaAcimaDoMaximo_DeveLimitarEmCinco()
    {
        // Arrange
        PlayerDoubleJump pulo = new PlayerDoubleJump(4);

        // Act
        pulo.AddExtraJump(3);

        // Assert
        Assert.AreEqual(5, pulo.ExtraJumps);
    }

    [Test]
    public void RemoveAbaixoDeZero_DeveLimitarEmZero()
    {
        // Arrange
        PlayerDoubleJump pulo = new PlayerDoubleJump(2);

        // Act
        pulo.RemoveExtraJump(5);

        // Assert
        Assert.AreEqual(0, pulo.ExtraJumps);
    }
}
