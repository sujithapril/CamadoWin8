using OnTheRoad.Server;
using OnTheRoad.ServerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
namespace OnTheRoad.Server
{
    // NOTE: You can use the ""Rename"" command on the ""Refactor"" menu to change the class name ""Service"" in code, svc and config file together.
    public class CamadoService : ICamadoService
    {


        public CamadoService()
        {

        }



        public List<Device> GetDevices()
        {
            List<Device> devices = new List<Device>();

            Device r1 = new Device() { DeviceId = 1, DeviceMacId = "BJFPHH", Description = "Lorem Ipsum", NickName = "Test Device1" };
            devices.Add(r1);

            Device r2 = new Device() { DeviceId = 2, DeviceMacId = "JKHLOM", Description = "Lorem Ipsum", NickName = "Test Device2" };
            devices.Add(r2);

            Device r3 = new Device() { DeviceId = 3, DeviceMacId = "CDFGHYY", Description = "Lorem Ipsum", NickName = "Test Device3" };
            devices.Add(r3);

            Device r4 = new Device() { DeviceId = 4, DeviceMacId = "UIOP98", Description = "Lorem Ipsum", NickName = "Test Device4" };
            devices.Add(r4);

            Device r5 = new Device() { DeviceId = 5, DeviceMacId = "CMNRET", Description = "Lorem Ipsum", NickName = "Test Device5" };
            devices.Add(r5);


            return devices;
        }

        string ICamadoService.GetBarGraph(string deviceId)
        {
            string bargraphjson =
                @"{	""status"": 1,	""message"": ""Success"",	""allGraphData"": {		""graphData"": {
			""graphResults"": [{""graphSeries"": [{					""name"": ""hive"",
					""columns"": [						""time"",
						""max_frequency"",						""max_humidity"",
						""max_spl"",						""max_temperature"",
						""max_vib""
					],

					""values"": [

						[
							""2017-06-20T11:30:00Z"",
							800,
							25,
							80,
							35,
							110
						],
						[
							""2017-06-20T12:30:00Z"",
							3339.39,
							44,
							24.59,
							30,
							120
						],
						[
							""2017-06-20T13:30:00Z"",
							800,
							25,
							80,
							35,
							130
						],
						[
							""2017-06-20T14:30:00Z"",
							800,
							25,
							80,
							35,
							140
						],
						[
							""2017-06-20T15:30:00Z"",
							800,
							25,
							80,
							35,
							150
						],
						[
							""2017-06-20T16:30:00Z"",
							800,
							25,
							80,
							35,
							160
						],
						[
							""2017-06-20T17:30:00Z"",
							800,
							25,
							80,
							35,
							170
						],
						[
							""2017-06-20T18:30:00Z"",
							800,
							25,
							80,
							35,
							180
						],
						[
							""2017-06-20T19:30:00Z"",
							800,
							25,
							80,
							35,
							190
						],
						[
							""2017-06-20T20:30:00Z"",
							800,
							25,
							80,
							35,
							200
						],
						[
							""2017-06-20T21:30:00Z"",
							800,
							25,
							80,
							35,
							210
						],
						[
							""2017-06-20T22:30:00Z"",
							800,
							25,
							80,
							35,
							220
						],
						[
							""2017-06-20T23:30:00Z"",
							800,
							25,
							80,
							35,
							230
						],
						[
							""2017-06-20T00:30:00Z"",
							800,
							25,
							80,
							35,
							0
						],
						[
							""2017-06-20T01:30:00Z"",
							800,
							25,
							80,
							35,
							10
						],
						[
							""2017-06-20T02:30:00Z"",
							800,
							25,
							80,
							35,
							20
						],
						[
							""2017-06-20T03:30:00Z"",
							1250,
							10,
							150,
							235,
							30
						],
						[
							""2017-06-20T04:30:00Z"",
							2000,
							60,
							5,
							90,
							40
						],
						[
							""2017-06-20T05:30:00Z"",
							0,
							40,
							80,
							48,
							50
						],
						[
							""2017-06-20T06:30:00Z"",
							800,
							25,
							80,
							35,
							60
						],
						[
							""2017-06-20T07:30:00Z"",
							800,
							25,
							80,
							35,
							70
						],
						[
							""2017-06-20T08:30:00Z"",
							800,
							25,
							80,
							35,
							80
						],
						[
							""2017-06-20T09:30:00Z"",
							800,
							25,
							80,
							35,
							90
						],
						[
							""2017-06-20T10:30:00Z"",
							800,
							25,
							80,
							35,
							100
						]
					]
				}]
			}]



		},
		""graphRows"": [{
				""hourlyAverageId"": 361,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 1,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-06T19:30:02.000Z"",
				""FA"": 1100,
				""SA"": 0,
				""CA"": 58,
				""HA"": 85,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 362,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 2,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-06T20:30:02.000Z"",
				""FA"": 450,
				""SA"": 0,
				""CA"": 60,
				""HA"": 91,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 363,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 3,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-06T21:30:02.000Z"",
				""FA"": 700,
				""SA"": 0,
				""CA"": 57,
				""HA"": 92,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 364,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 4,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-06T22:30:02.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 58,
				""HA"": 92,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 365,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 5,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-05T23:30:02.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 30,
				""HA"": 46,
				""XA"": 86,
				""YA"": 0,
				""ZA"": 0,
				""count"": 2,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 366,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 6,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-07T00:30:03.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 57,
				""HA"": 89,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 367,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 7,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-07T01:30:02.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 57,
				""HA"": 88,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 368,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 8,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-07T02:30:02.000Z"",
				""FA"": 5858.68,
				""SA"": 18.14,
				""CA"": 60,
				""HA"": 93,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 369,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 9,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-07T03:30:02.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 58,
				""HA"": 92,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 370,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 10,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-07T04:30:02.000Z"",
				""FA"": 5607.86,
				""SA"": 17.72,
				""CA"": 58,
				""HA"": 92,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 371,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 11,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-06T05:30:03.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 28,
				""HA"": 43,
				""XA"": 86,
				""YA"": 0,
				""ZA"": 0,
				""count"": 2,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 372,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 12,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-07T06:30:02.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 58,
				""HA"": 83,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 373,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 13,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-06T07:30:02.000Z"",
				""FA"": 5890.56,
				""SA"": 6.56,
				""CA"": 28,
				""HA"": 41,
				""XA"": 86,
				""YA"": 0,
				""ZA"": 0,
				""count"": 2,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 374,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 14,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-07T08:30:02.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 56,
				""HA"": 81,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 375,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 15,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-07T09:30:03.000Z"",
				""FA"": 3555.85,
				""SA"": 34.11,
				""CA"": 58,
				""HA"": 73,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 376,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 16,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-06T10:30:02.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 28,
				""HA"": 42,
				""XA"": 86,
				""YA"": 0,
				""ZA"": 0,
				""count"": 2,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 377,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 17,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-05T11:30:02.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 0,
				""HA"": 0,
				""XA"": 0,
				""YA"": 0,
				""ZA"": 0,
				""count"": 1,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 378,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 18,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-04T12:30:02.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 0,
				""HA"": 0,
				""XA"": 0,
				""YA"": 0,
				""ZA"": 0,
				""count"": 1,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 379,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 19,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-05T13:30:02.000Z"",
				""FA"": 8656.94,
				""SA"": 45.18,
				""CA"": 31,
				""HA"": 41,
				""XA"": 86,
				""YA"": 0,
				""ZA"": 0,
				""count"": 2,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 380,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 20,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-06T14:30:02.000Z"",
				""FA"": 6610.61,
				""SA"": 31.84,
				""CA"": 60,
				""HA"": 82,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 381,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 21,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-06T15:30:02.000Z"",
				""FA"": 5598.31,
				""SA"": 29.37,
				""CA"": 59,
				""HA"": 84,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 382,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 22,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-06T16:30:02.000Z"",
				""FA"": 10850.7,
				""SA"": 46.13,
				""CA"": 59,
				""HA"": 87,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 383,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 23,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-06T17:30:02.000Z"",
				""FA"": 6279.88,
				""SA"": 17.93,
				""CA"": 59,
				""HA"": 84,
				""XA"": 172,
				""YA"": 0,
				""ZA"": 0,
				""count"": 3,
				""status"": 1,
				""log"": """"
			},
			{
				""hourlyAverageId"": 384,
				""orgId"": 1,
				""userId"": 0,
				""deviceId"": 16,
				""timeFrame"": 24,
				""dateCreated"": ""2017-07-04T12:04:57.000Z"",
				""dateUpdated"": ""2017-07-04T12:04:57.000Z"",
				""FA"": 0,
				""SA"": 0,
				""CA"": 0,
				""HA"": 0,
				""XA"": 0,
				""YA"": 0,
				""ZA"": 0,
				""count"": 0,
				""status"": 1,
				""log"": """"
			}
		]

	}

}
                 ";

            return  bargraphjson;
        }

      
    }
}