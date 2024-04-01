using NlwAuction.Domain.Entities;

namespace NlwAuction.Domain.Interfaces.DataAccess.Repositories;

public interface IOfferRepository
{
	Task Add(Offer offer);
	Task<Offer> Save(Offer offer);
}
