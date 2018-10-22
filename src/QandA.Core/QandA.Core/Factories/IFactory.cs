namespace QandA.Core.Factories
{
    internal interface IFactory<T>
    {
        T Create();
    }
}