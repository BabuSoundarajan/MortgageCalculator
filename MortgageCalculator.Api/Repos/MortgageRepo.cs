using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MortgageCalculator.Api.Repos
{
    public interface IMortgageRepo
    {
        List<Mortgage> GetAllMortgages();
    }

    public class MortgageRepo : IMortgageRepo
    {
        public List<Mortgage> GetAllMortgages()
        {
            using (var context = new MortgageData.MortgageDataContext())
            {
                var mortgages = context.Mortgages.ToList();
                List<Mortgage> result = new List<Mortgage>();
                foreach (var mortgage in mortgages)
                {
                    result.Add(new Mortgage()
                    {
                        Name = mortgage.Name,
                        EffectiveStartDate = mortgage.EffectiveStartDate,
                        EffectiveEndDate = mortgage.EffectiveEndDate,
                        CancellationFee = mortgage.CancellationFee,
                        EstablishmentFee = mortgage.CancellationFee,
                        InterestRepaymentType = mortgage.InterestRepayment.ToString(),
                        MortgageId = mortgage.MortgageId,
                        MortgageType = mortgage.MortgageType.ToString(),
                        InterestRate = mortgage.InterestRate,
                        TermsInMonths = GetMonthDifference(mortgage.EffectiveStartDate, mortgage.EffectiveEndDate)
                    });
                }
                return result.OrderBy(x => x.MortgageType).ThenBy(x => x.InterestRate).ToList();
            }
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }
    }
}