using HttpFactoryProject;
using HttpFactoryProject.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        public ValuesController valuesController { get; set; }

        [SetUp]
        public void Setup()
        {
            //  Arrange
            //  Setting up the stuff required for Configuration.GetConnectionString("DefaultConnection")
            Mock<IConfigurationSection> configurationSectionStub = new Mock<IConfigurationSection>();
            //configurationSectionStub.Setup(x => x["DefaultConnection"]).Returns("TestConnectionString");
            Mock<IConfiguration> configurationStub = new Mock<IConfiguration>();
            //configurationStub.Setup(x => x.GetSection("ConnectionStrings")).Returns(configurationSectionStub.Object);

            IServiceCollection services = new ServiceCollection();
            var target = new Startup(configurationStub.Object);

            //  Act
            target.ConfigureServices(services);
            //  Mimic internal asp.net core logic.
            services.AddTransient<IHttpService, HttpService>();
            services.AddTransient<ValuesController>();

            var serviceProvider = services.BuildServiceProvider();
            valuesController = serviceProvider.GetService<ValuesController>();

        }

        [Test]
        public async System.Threading.Tasks.Task Test1Async()
        {
            var result = valuesController.GetAsync();
            
            Assert.IsNotNull(result);
            Assert.Pass();
        }
    }
}