using MortgageCalculator.Api.Repos;
using MortgageCalculator.Dto;
using System.Collections.Generic;

namespace MortgageCalculator.Api.Services
{
    public interface IMortgageService
    {
        List<Mortgage> GetAllMortgages();
    }

    public class MortgageService : IMortgageService
    {

        private readonly IMortgageRepo _mortgageRepo;
        public MortgageService() : this(new MortgageRepo())
        { }

        public MortgageService(IMortgageRepo mortgageRepo)
        {
            this._mortgageRepo = mortgageRepo;
        }

        public List<Mortgage> GetAllMortgages()
        {
            return _mortgageRepo.GetAllMortgages();
        }

        public List<mortgageDropDownList> GetMortgageDropDownList()
        {
            return _mortgageRepo.GetMortgageDropDownList();
        }
    }
}