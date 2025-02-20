namespace Basket.API.Data;

public interface IBasketRepository
{
    Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
    Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default);
    Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default);
}
