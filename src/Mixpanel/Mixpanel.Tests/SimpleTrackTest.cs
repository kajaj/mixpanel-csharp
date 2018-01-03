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
            var success = mixpanelClient.Track("test event", "1234", new object { });
        }
    }
}
