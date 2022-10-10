namespace Shopi.Challange.Ordering.Core.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
