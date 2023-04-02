using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    HeroRepository heroRep;
    Hero hero;

    [SetUp]
    public void SetUp()
    {
        heroRep = new HeroRepository();
        hero = new Hero("Peshaka", 20);
    }

    [Test]
    public void Test_HeroRepositoryConstructor_SetsPropertiesCorrectly()
    {
        Assert.NotNull(heroRep.Heroes);
    }
}