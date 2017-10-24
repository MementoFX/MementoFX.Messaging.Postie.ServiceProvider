using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using SharpTestsEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoFX.Messaging.Postie.ServiceProvider.Tests
{
    
    public class ServiceProviderTypeResolverFixture
    {
        [Fact]
        public void Ctor_should_throw_ArgumentNullException_on_null_services_parameter()
        {
            Executing.This(() => new ServiceProviderTypeResolver(null))
                .Should()
                .Throw<ArgumentNullException>()
                .And
                .ValueOf
                .ParamName
                .Should()
                .Be
                .EqualTo("services");
        }

        [Fact]
        public void Ctor_should_set_Container_property()
        {
            var serviceCollectionMock = new Mock<IServiceCollection>().Object;
            var sut = new ServiceProviderTypeResolver(serviceCollectionMock);
            Assert.Same(serviceCollectionMock, sut.Services);
        }
    }
}
