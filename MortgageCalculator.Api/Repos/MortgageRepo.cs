using MortgageCalculator.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MortgageCalculator.Api.Repos
{
    public interface IMortgageRepo
    {
        List<Mortgage> GetAllMortgages();
        int GetMonthDifference(DateTime startDate, DateTime endDate);
        List<mortgageDropDownList> GetMortgageDropDownList();
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
                        InterestRepaymentType = (InterestRepayment)(mortgage.InterestRepayment),
                        MortgageId = mortgage.MortgageId,
                        MortgageType = (MortgageType)mortgage.MortgageType,
                        InterestRate = mortgage.InterestRate,
                        TermsInMonths = GetMonthDifference(mortgage.EffectiveStartDate, mortgage.EffectiveEndDate)
                    });
                }
                return result.OrderBy(x => x.MortgageType).ThenBy(x => x.InterestRate).ToList();
            }
        }


        public int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public List<mortgageDropDownList> GetMortgageDropDownList()
        {
            List<mortgageDropDownList> mortgageDropDownList = new List<mortgageDropDownList>();

            var mortgages = GetAllMortgages();
            mortgageDropDownList.Add(new mortgageDropDownList
            {
                Value = 0,
                Text = "Select Mortgage Type"
            });

            foreach (var mortgage in mortgages)
            {
                mortgageDropDownList.Add(new mortgageDropDownList
                {
                    Value = mortgage.InterestRate,
                    Text = string.Format("{0}%-{1}", mortgage.InterestRate, mortgage.Name)
                });
            }
            return mortgageDropDownList;
        }
    }
}