using MortgageCalculator.Api.Repos;
using MortgageCalculator.Dto;
using System.Collections.Generic;
using System.Linq;

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

        public Mortgage Get(int id)
        {
            return GetAllMortgages().FirstOrDefault(x => x.MortgageId == id);
        }


        public List<MortgageDropDownList> GetMortgageDropDownList()
        {
            return _mortgageRepo.GetMortgageDropDownList();
        }
    }
}