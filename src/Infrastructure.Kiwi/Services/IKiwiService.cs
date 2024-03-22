using Infrastructure.Kiwi.Contracts.Requests;
using Infrastructure.Kiwi.Contracts.Responses;

namespace Infrastructure.Kiwi.Services;

public interface IKiwiService
{
    Task<GetOfferListResponse> GetOfferList(GetOfferListRequest request);
    Task<GetOfferResponse?> GetOffer(string offerId);
}