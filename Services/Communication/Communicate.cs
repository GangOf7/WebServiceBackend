using Microsoft.Extensions.Options;
using PiratesBay.Data;
using PiratesBay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;

namespace PiratesBay.Services.Communication
{
    public class Communicate
    {
        private readonly DataContext _dataContext;

        public TwilioSettings _TwilioOptions { get; }
        public Communicate(IOptions<TwilioSettings> twilioSettings, DataContext dataContext)
        {
            _TwilioOptions = twilioSettings.Value;
            _dataContext = dataContext;
        }

        public async Task ValidateSensorData()
        {

        }






        public async Task SendSMS(Value value)
        {
            TwilioClient.Init(_TwilioOptions.AccountSid, _TwilioOptions.AuthToken);
            var message = await Twilio.Rest.Api.V2010.Account.MessageResource.CreateAsync(
                body: $"New Value insterted with the Name : {value.Name}",
                from: new Twilio.Types.PhoneNumber(_TwilioOptions.PhoneNumber),
                to: "+919331133004"
                );
        }
    }
}
