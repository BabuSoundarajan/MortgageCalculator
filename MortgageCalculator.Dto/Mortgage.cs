using System;
using System.ComponentModel;

namespace MortgageCalculator.Dto
{
    public class Mortgage
    {
        public int MortgageId { get; set; }
        public string Name { get; set; }
        [DisplayName("Type")]
        public MortgageType MortgageType { get; set; }
        [DisplayName("StartDate")]
        public DateTime EffectiveStartDate { get; set; }
        [DisplayName("EndDate")]
        public DateTime EffectiveEndDate { get; set; }
        public int TermsInMonths { get; set; }
        public decimal CancellationFee { get; set; }
        public decimal EstablishmentFee { get; set; }
        public decimal InterestRate { get; set; }
        public Guid SchemaIdentifier { get; internal set; }
        [DisplayName("RepaymentType")]
        public InterestRepayment InterestRepaymentType { get; set; }
    }

    public enum MortgageType
    {
        Fixed,
        Variable
    }

    public enum InterestRepayment
    {
        InterestOnly,
        PrincipalAndInterest
    }

    public class mortgageDropDownList
    {
        public decimal Value { get; set; }
        public string Text { get; set; }
    }

}
