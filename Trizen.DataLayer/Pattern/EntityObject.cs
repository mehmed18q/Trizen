namespace Trizen.DataLayer.Pattern;

public record EntityObject<E, O>
{
    public E Entity { get; set; }
    public O? Value { get; set; }
}