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

    [Test]
    public void Test_CreateMethod_ThrowsInvalidOperationException_WhenThereIsNoSuchHeroName()
    {
        heroRep.Create(hero);
        Hero secondHero = new Hero("Peshaka", 40);

        Assert.Throws<InvalidOperationException>(() =>
        heroRep.Create(hero), $"Hero with name {hero.Name} already exists"
        );
    }

    [Test]
    public void Test_CreateMethod_AddsSaidHeroToRepo_And_ReturnsString()
    {
        heroRep.Create(hero);
        Hero secondHero = new Hero("Geshaka", 40);

        string expectedResult = $"Successfully added hero {secondHero.Name} with level {secondHero.Level}";
        string actualResult = heroRep.Create(secondHero);

        Assert.True(expectedResult.Equals(actualResult));
        Assert.That(2, Is.EqualTo(heroRep.Heroes.Count));
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    [TestCase(null)]
    public void Test_RemoveMethodThrows_IsNullOrWhiteSpace_WhenHeroName_IsNullOrWhiteSpace(string name)
    {
        Assert.Throws<ArgumentNullException>(() =>
        heroRep.Remove(name), "Name cannot be null"
        );
    }

    [Test]
    public void Test_RemoveMethod_RemovesSaidHero_And_ReturnsTrue()
    {
        heroRep.Create(hero);
        Assert.True(heroRep.Remove("Peshaka"));
        Assert.That(0, Is.EqualTo(heroRep.Heroes.Count));
    }

    [Test]
    public void Test_RemoveMethod_ReturnsFalse()
    {
        heroRep.Create(hero);
        Assert.False(heroRep.Remove("Geshaka"));
        Assert.That(1, Is.EqualTo(heroRep.Heroes.Count));
    }
}