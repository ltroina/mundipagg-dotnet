using System.Collections.Generic;

namespace Mundipagg.Models.Response
{
    public class GetPricingSchemeResponse
    {
        #region Public Properties

        public int? MinimumPrice { get; set; }

        public int Price { get; set; }

        public List<GetPriceBracketResponse> PriceBrackets { get; set; }

        public string SchemeType { get; set; }

        #endregion Public Properties
    }
}