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
                ClientId = "e552ed0c-5dde-475a-983e-ef3e4defb700",
                Id = 548667,
                Uri = new Uri("http://digitalcommunications.wp.st-andrews.ac.uk/files/2019/04/JPEG_compression_Example-768x576.jpg"),
                Name = "Test"
            };
            var beanstalkdClient = await BeanstalkConnection.ConnectProducerAsync("localhost:11300");
            await beanstalkdClient.UseAsync(JobChannelsEnum.ImageResize.ToString());
            await beanstalkdClient.PutAsync(imageResizeRequest, 5, TimeSpan.Zero);
        }
    }
}