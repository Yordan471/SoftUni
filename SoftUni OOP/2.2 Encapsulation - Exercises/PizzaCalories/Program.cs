
using PizzaCalories;

Pizza pizza = new();

string command = string.Empty;

while ((command = Console.ReadLine()) != "END")
{
    string[] pizzaInfo = command
        .Split();

    string information = pizzaInfo[0];
    try
    {
        if (information == "Pizza")
        {
            string pizzaName = pizzaInfo[1];
            pizza.Name = pizzaName;
        }
        else if (information == "Dough")
        {
            string flourType = pizzaInfo[1];
            string bakingTechnique = pizzaInfo[2];
            double grams = double.Parse(pizzaInfo[3]);

            Dough dough = new(flourType, bakingTechnique, grams);
            pizza.Dough = dough;
        }
        else if (information == "Topping")
        {
            string toppingType = pizzaInfo[1];
            double weight = double.Parse(pizzaInfo[2]);

            Topping topping = new(toppingType, weight);
            pizza.AddTopping(topping);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
}

Console.WriteLine(pizza);