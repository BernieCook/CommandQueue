using CommandQueue.Domain.Interfaces;
using CommandQueue.Domain.Services;
using CommandQueue.Web.Models.SimulationModels;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommandQueue.Web.ApiControllers
{
    public class ComplaintController : ApiController
    {
        private readonly IComplaintService _complaintService;

        public ComplaintController()
        {
            // Use DI here. 
            _complaintService = new ComplaintService();
        }

        //
        // POST: /api/complaint/send-complaint/

        [ActionName("send-complaint")]
        public HttpResponseMessage Post(
            SendComplaintModel sendComplaintModel)
        {
            if (ModelState.IsValid)
            {
                _complaintService.ProcessComplaint(
                    sendComplaintModel.FullName,
                    sendComplaintModel.Complaint,
                    sendComplaintModel.Level);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
