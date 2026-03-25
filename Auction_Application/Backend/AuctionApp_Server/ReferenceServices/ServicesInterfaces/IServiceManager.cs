namespace ReferenceServices.ServicesInterfaces;

public interface IServiceManager
{
    IUserService UserService { get; }

    IAuctionHouseService AuctionHouseService { get; }
}
