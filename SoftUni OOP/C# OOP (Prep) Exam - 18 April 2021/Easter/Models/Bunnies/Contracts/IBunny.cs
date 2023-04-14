namespace Easter.Models.Bunnies.Contracts
{
    using System.Collections.Generic;

    using Dyes.Contracts;

    public interface IBunny
    {
        string Name { get; }

        int Energy { get; }

        ICollection<Dye> Dyes { get; }

        abstract void Work();

        void AddDye(Dye dye);
    }
}