using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections;
using UnityEngine;

public class PlayerScoreTests
{
    private GameObject objeto;
    private PlayerScore pontuacao;

    [SetUp]
    public void SetUp()
    {
        objeto = new GameObject("PlayerScoreTest");
        pontuacao = objeto.AddComponent<PlayerScore>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(objeto);
    }

    [Test]
    public void InicializaPontuacao()
    {
        Assert.AreEqual(0f, pontuacao.Score);
        Assert.AreEqual(1f, pontuacao.ScoreBonus);
    }

    [Test]
    public void AdicionaPontuacao()
    {
        pontuacao.AddScore(10f);

        Assert.AreEqual(10f * pontuacao.ScoreBonus, pontuacao.Score);
    }

    [Test]
    public void AplicaBonusNaPontuacao()
    {
        pontuacao.ApplyScoreBonus(2f);
        pontuacao.AddScore(10f);

        Assert.AreEqual(10f * pontuacao.ScoreBonus, pontuacao.Score);
    }

    [Test]
    public void AdicionarZeroPontos_NaoAlteraPontuacao()
    {
        // Arrange
        pontuacao.AddScore(10f);
        float pontuacaoAnterior = pontuacao.Score;

        // Act
        pontuacao.AddScore(0f);

        // Assert
        Assert.AreEqual(pontuacaoAnterior, pontuacao.Score);
    }

}