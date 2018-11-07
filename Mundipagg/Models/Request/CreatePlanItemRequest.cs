namespace Mundipagg.Models.Request
{
    public class CreatePlanItemRequest
    {
        #region Public Properties

        public int? Cycles { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public CreatePricingSchemeRequest PricingScheme { get; set; }

        public int? Quantity { get; set; }

        #endregion Public Properties
    }
}