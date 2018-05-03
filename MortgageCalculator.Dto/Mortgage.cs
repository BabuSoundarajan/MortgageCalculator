using System;

namespace MortgageCalculator.Dto
{
    public class Mortgage
    {
        public int MortgageId { get; set; }
        public string Name { get; set; }
        public string MortgageType { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public int TermsInMonths { get; set; }
        public decimal CancellationFee { get; set; }
        public decimal EstablishmentFee { get; set; }
        public decimal InterestRate { get; set; }
        public Guid SchemaIdentifier { get; internal set; }
        public string InterestRepaymentType { get; set; }
    }

    public enum MortgageType
    {
        Variable,
        Fixed
    }

    public enum InterestRepayment
    {
        InterestOnly,
        PrincipalAndInterest
    }
}
