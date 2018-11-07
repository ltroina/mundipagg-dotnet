﻿using Mundipagg.Models.Request;
using Mundipagg.Models.Response;
using Mundipagg.Resources.Interface;
using Mundipagg.Utils;
using System.Net.Http;

namespace Mundipagg.Resources
{
    /// <summary>
    /// Charge manager
    /// </summary>
    public class ChargeResource : BaseResource, IChargeResource
    {
        #region Public Constructors

        /// <summary>
        /// Creates a new charge manager
        /// </summary>
        /// <param name="configuration">Mundipagg Api configuration</param>
        public ChargeResource(Configuration configuration) : base(configuration) { }

        #endregion Public Constructors

        #region Public Methods

        public BaseResponse<GetChargeResponse> CancelCharge(string chargeId, CreateCancelChargeRequest request = null)
        {
            var method = HttpMethod.Delete;
            var endpoint = $"/charges/{chargeId}";

            return this.HttpClientUtil.SendRequest<GetChargeResponse>(method, endpoint, request);
        }

        public BaseResponse<GetChargeResponse> CaptureCharge(string chargeId, CreateCaptureChargeRequest request = null)
        {
            var method = HttpMethod.Post;
            var endpoint = $"/charges/{chargeId}/capture";

            return this.HttpClientUtil.SendRequest<GetChargeResponse>(method, endpoint, request);
        }

        public BaseResponse<GetChargeResponse> ConfirmPayment(string chargeId, CreateConfirmPaymentRequest request = null)
        {
            var method = HttpMethod.Post;
            var endpoint = $"/charges/{chargeId}/confirm-payment";

            return this.HttpClientUtil.SendRequest<GetChargeResponse>(method, endpoint, request);
        }

        public BaseResponse<GetChargeResponse> CreateCharge(CreateChargeRequest request)
        {
            var method = HttpMethod.Post;
            var endpoint = $"/charges";

            return this.HttpClientUtil.SendRequest<GetChargeResponse>(method, endpoint, request);
        }

        public BaseResponse<GetChargeResponse> GetCharge(string chargeId)
        {
            var method = HttpMethod.Get;
            var endpoint = $"/charges/{chargeId}";

            return this.HttpClientUtil.SendRequest<GetChargeResponse>(method, endpoint, null);
        }

        public BaseResponse<ListChargesResponse> GetCharges(ListChargesRequest request)
        {
            var method = HttpMethod.Get;
            var endpoint = $"/charges";
            var query = request.ToDictionary();

            return this.HttpClientUtil.SendRequest<ListChargesResponse>(method, endpoint, null, query);
        }

        public BaseResponse<GetChargeResponse> RetryCharge(string chargeId)
        {
            var method = HttpMethod.Post;
            var endpoint = $"/charges/{chargeId}/retry";

            return this.HttpClientUtil.SendRequest<GetChargeResponse>(method, endpoint, null);
        }

        public BaseResponse<GetChargeResponse> UpdateChargeCard(string chargeId, UpdateChargeCardRequest request)
        {
            var method = new HttpMethod("PATCH");
            var endpoint = $"/charges/{chargeId}/credit-card";

            return this.HttpClientUtil.SendRequest<GetChargeResponse>(method, endpoint, request);
        }

        public BaseResponse<GetChargeResponse> UpdateChargeDueDate(string chargeId, UpdateChargeDueDateRequest request)
        {
            var method = new HttpMethod("PATCH");
            var endpoint = $"/charges/{chargeId}/due-date";

            return this.HttpClientUtil.SendRequest<GetChargeResponse>(method, endpoint, request);
        }

        public BaseResponse<GetChargeResponse> UpdateChargeMetadata(string chargeId, UpdateMetadataRequest request)
        {
            var method = new HttpMethod("PATCH");
            var endpoint = $"/charges/{chargeId}/metadata";

            return this.HttpClientUtil.SendRequest<GetChargeResponse>(method, endpoint, request);
        }

        public BaseResponse<GetChargeResponse> UpdateChargePaymentMethod(string chargeId, UpdateChargePaymentMethodRequest request)
        {
            var method = new HttpMethod("PATCH");
            var endpoint = $"/charges/{chargeId}/payment-method";

            return this.HttpClientUtil.SendRequest<GetChargeResponse>(method, endpoint, request);
        }

        #endregion Public Methods
    }
}