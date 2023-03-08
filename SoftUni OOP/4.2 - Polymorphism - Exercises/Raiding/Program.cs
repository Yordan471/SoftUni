using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.HeroFactory;
using Raiding.HeroFactory.Interfaces;

IHeroFactory heroFactory = new HeroFactory();

IEngine engine = new Engine(heroFactory);

engine.Run();

