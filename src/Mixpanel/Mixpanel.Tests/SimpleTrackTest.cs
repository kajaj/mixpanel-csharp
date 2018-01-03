using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mixpanel.Tests
{
    [TestFixture]
    public class SimpleTrackTest
    {
        [Test]
        public void TrackSimpleEvent()
        {
            var token = "";
            var mixpanelClient = new MixpanelClient(token);
            var eventData = new Dictionary<string, Object>();
            eventData["Time"] = DateTime.UtcNow.AddMinutes(-7);
            var success = mixpanelClient.Track("test event", "1234", eventData);
        }

        [Test]
        public void ImportSimpleEvent()
        {
          var token = "";
          var api_key = "";
          var mixpanelClient = new MixpanelClient(token, api_key);
          var eventData = new Dictionary<string, Object>();
          eventData["Time"] = DateTime.UtcNow.AddDays(-7);
          var success = mixpanelClient.Import("test import event", "1234", eventData);
        }
  }
}
