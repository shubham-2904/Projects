using LoggerService;
using Reference.Domain.Model;
using ReferenceRepositoryManager;
using ReferenceServices.Dtos;
using ReferenceServices.ServicesInterfaces;
using SharedData;

namespace ReferenceServices.Services;

public class AuctionHouseService : IAuctionHouseService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerManager _logger;

    public AuctionHouseService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
    {
        _repositoryManager = repositoryManager;
        _logger = loggerManager;
    }

    public async Task<Response<AuctionHouseDto>> CreateAuctionHouseAsync(AuctionHouseForCreationDto auctionHouseForCreationDto)
    {
        try
        {
            AuctionHouse auctionHouser = auctionHouseForCreationDto.ToEntity();
            _repositoryManager.AuctionHouse.CreateAuctionHouse(auctionHouser);
            await _repositoryManager.CommitAsync();
            AuctionHouseDto auctionHouserDto = auctionHouser.ToDto();
            return Response<AuctionHouseDto>.Ok(auctionHouserDto, "Auction House created successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Response<AuctionHouseDto>.Fail("Error occured while creating Auction House");
        }
    }

    public async Task<Response<bool>> DeleteAuctionHouseAsync(long id)
    {
        try
        {
            AuctionHouse? auctionHouse = await _repositoryManager.AuctionHouse.GetAuctionHouseByIdAsync(id, true);
            if (auctionHouse is null)
            {
                _logger.LogError("Auction House not found");
                return Response<bool>.Fail("Error occured deleting Auction House");
            }
            auctionHouse.LastModifyDate = DateTime.UtcNow;
            auctionHouse.IsDeleted = true;
            await _repositoryManager.CommitAsync();
            return Response<bool>.Ok(true, "Auction House deleted successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Response<bool>.Fail("Error occured deleting Auction House");
        }
    }

    public async Task<Response<IEnumerable<AuctionHouseDto>>> GetAllAuctionHousesAsync(bool trackChanges)
    {
        try
        {
            IEnumerable<AuctionHouse> auctionHouses = await _repositoryManager.AuctionHouse.GetAllAuctionHouseOrByConditionAsync(trackChanges, ah => !ah.IsDeleted);
            if (auctionHouses is null)
            {
                _logger.LogError("Auction houses not present in DB");
                return Response<IEnumerable<AuctionHouseDto>>.Fail("Error occured while fetching the auction houses");
            }
            ICollection<AuctionHouseDto> auctionHouseDtos = [];
            foreach (AuctionHouse auctionHouse in auctionHouses)
            {
                auctionHouseDtos.Add(auctionHouse.ToDto());
            } 
            return Response<IEnumerable<AuctionHouseDto>>.Ok(auctionHouseDtos, "Auction houses display sucessfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Response<IEnumerable<AuctionHouseDto>>.Fail("Error occured while fetching the auction houses");
        }
    }

    public async Task<Response<AuctionHouseDto>> GetAuctionHouseIdAsync(long id, bool trackChanges)
    {
        try
        {
            AuctionHouse auctionHouse = (await _repositoryManager.AuctionHouse
                .GetAllAuctionHouseOrByConditionAsync(trackChanges, ah => ah.AuctionHouseId == id && ah.IsDeleted == false))
                .FirstOrDefault()!;
            if (auctionHouse == null)
            {
                _logger.LogError("Auction House not found or deleted from DB");
                return Response<AuctionHouseDto>.Fail("Auction House not found or deleted from DB");
            }
            AuctionHouseDto auctionHouseDto = auctionHouse!.ToDto();
            return Response<AuctionHouseDto>.Ok(auctionHouseDto, "Auction House fetched successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Response<AuctionHouseDto>.Fail("Error while fetching Auction House");
        }
    }

    public Task<Response<IEnumerable<AuctionHouseDto>>> GetAuctionHousesByIdsAsync(IEnumerable<long> ids, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<AuctionHouseDto>> UpdateAuctionHouseAsync(AuctionHouseForUpdationDto auctionHouseForUpdationDto)
    {
        try
        {
            AuctionHouse? auctionHouse = await _repositoryManager.AuctionHouse.GetAuctionHouseByIdAsync(auctionHouseForUpdationDto.Id, true);
            if (auctionHouse is null)
            {
                _logger.LogError("Auction House not found");
                return Response<AuctionHouseDto>.Fail("Auction House not found");
            }
            auctionHouseForUpdationDto.ToEntity(auctionHouse);
            await _repositoryManager.CommitAsync();
            AuctionHouseDto auctionHouseDto = auctionHouse.ToDto();
            return Response<AuctionHouseDto>.Ok(auctionHouseDto, "Auction House updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return Response<AuctionHouseDto>.Fail("Error while updating Auction House");
        }
    }
}
