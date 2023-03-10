using WildFarm.Core;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.Factories.Interfaces;

IAnimalFactory animalFactory = new AnimalFactory();
IFoodFactory foodFactory = new FoodFactory();

IEngine engine = new Engine(animalFactory, foodFactory);

engine.Run();