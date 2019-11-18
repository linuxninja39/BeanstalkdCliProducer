using System;
using System.Threading.Tasks;
using EarthDiverDtos;
using EarthDiverDtos.Enums;
using Turbocharged.Beanstalk;

namespace BeanstalkdCliProducer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var imageResizeRequest = new ImageResizeRequestDto
            {
                Name = "bob"
            };
            var beanstalkdClient = await BeanstalkConnection.ConnectProducerAsync("localhost:11300");
            await beanstalkdClient.UseAsync(JobChannelsEnum.ImageResize.ToString());
            await beanstalkdClient.PutAsync(imageResizeRequest, 5, TimeSpan.Zero);
        }
    }
}