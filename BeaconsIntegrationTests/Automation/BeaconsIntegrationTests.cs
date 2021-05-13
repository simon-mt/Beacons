using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BeaconsDomain;
using FluentAssertions;
using Gherkin.Ast;
using Xunit.Gherkin.Quick;

namespace BeaconsIntegrationTests.Automation
{
    [FeatureFile("./Specifications/Beacons.feature")]
    public class BeaconsIntegrationTests : ApiBase, IDisposable
    {
        private readonly List<HttpResponseMessage> _httpResponses = new List<HttpResponseMessage>();
        private BeaconList _beaconList;

        [Given("there are no saved beacons")]
        public async Task There_Are_No_Beacons() => (await GetNumberOfBeaconsAsync()).Should().Be(0);


        [Given("the following beacons exist")]
        [When("the following beacons are added")]
        public async Task When_Beacons_Added(DataTable qualifications)
        {
            foreach (var row in qualifications.Rows.Skip(1))
            {
                var cells = row.Cells.ToArray();

                var beacon = new Beacon
                {
                    Name = cells[0].Value,
                    Activated = (cells[1].Value == "y")
                };

                _httpResponses.Add(await AddBeaconAsync(beacon));
            }
        }

        [When(@"beacon (.+) is requested")]
        public async Task When_Beacon_Name_Requested(String name)
        {
            var response = await _client.GetAsync("Beacons/" + name);
            _beaconList = await ConvertResponseContentToObjectAsync<BeaconList>(response);
        }

        [When(@"the list of active beacons is requested")]
        public async Task When_Active_Beacons_Requested()
        {
            var response = await _client.GetAsync("Beacons/Status?activated=true");
            _beaconList = await ConvertResponseContentToObjectAsync<BeaconList>(response);
        }

        [Then(@"the number of returned beacons should be (.+)")]
        public async Task Should_return_N_Saved_Beacons(int expected)
        {
            _beaconList.Beacons.Count.Should().Be(expected);
        }


        [Then(@"the number of saved beacons should be (.+)")]
        public async Task Should_Be_N_Saved_Beacons(int expected)
        {
            var actualNumberOfBeacons = await GetNumberOfBeaconsAsync();

            actualNumberOfBeacons.Should().Be(expected);
        }


        private async Task<HttpResponseMessage> AddBeaconAsync(Beacon item)
            => await _client.PostAsync("Beacons/", ConvertObjectToHttpContent(item));

        private async Task<int> GetNumberOfBeaconsAsync()
        {
            var response = await _client.GetAsync("Beacons/");

            var beaconList = await ConvertResponseContentToObjectAsync<BeaconList>(response);

            return beaconList.Beacons.Count;
        }

        public override void Dispose()
        {
            _httpResponses.Clear();
            base.Dispose();
        }
    }
}
