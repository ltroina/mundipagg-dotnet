using System.Collections.Generic;

namespace Mundipagg.Models.Response
{
    public class ListDiscountsResponse
    {
        #region Public Properties

        public List<GetDiscountResponse> Data { get; set; }

        public PagingResponse Paging { get; set; }

        #endregion Public Properties
    }
}