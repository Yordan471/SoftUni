using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            cars = new List<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)cars;

        public void Add(IFormulaOneCar model)
        {
            cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            IFormulaOneCar car = cars.FirstOrDefault(c => c.Model == name);

            if (car == null)
            {
                return null;
            }

            return car;
        }

        public bool Remove(IFormulaOneCar model)
        {
            IFormulaOneCar removeCar = cars.FirstOrDefault(c => c.Model.Equals(model));

            if (removeCar != null)
            {
                cars.Remove(removeCar);
                return true;
            }

            return false;
        }
    }
}
