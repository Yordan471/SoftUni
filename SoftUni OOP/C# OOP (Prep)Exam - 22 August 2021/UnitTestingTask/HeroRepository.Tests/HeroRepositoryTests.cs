using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    HeroRepository heroRep;
    Hero hero;
    Hero nullHero;

    [SetUp]
    public void SetUp()
    {
        heroRep = new HeroRepository();
        hero = new Hero("Peshaka", 20);
        nullHero = null;
    }

    [Test]
    public void Test_HeroRepositoryConstructor_SetsPropertiesCorrectly()
    {
        Assert.NotNull(heroRep.Heroes);
    }

    [Test]
    public void Test_Create_ThrowsArgumentNullException_IfHeroIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => 
        heroRep.Create(nullHero), "Hero is null"
        );
    }

}