namespace Core.Domain
{

    public interface IObjectIdentifier<out T>
    {
        T Value { get; }
    }

}
