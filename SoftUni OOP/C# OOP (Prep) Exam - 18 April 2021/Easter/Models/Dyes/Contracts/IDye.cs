namespace Easter.Models.Dyes.Contracts
{
    public interface Dye
    {
        int Power { get; }

        void Use();

        bool IsFinished();
    }
}
