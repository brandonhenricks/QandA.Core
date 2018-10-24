namespace QandA.Core.Factories
{
    public interface IFactory<T>
    {
        T Create();
    }
}