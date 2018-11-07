namespace Mundipagg.Models.Request
{
    public class UpdatePriceBracketRequest
    {
        #region Public Properties

        public int? EndQuantity { get; set; }

        public int? OveragePrice { get; set; }

        public int Price { get; set; }

        public int StartQuantity { get; set; }

        #endregion Public Properties
    }
}