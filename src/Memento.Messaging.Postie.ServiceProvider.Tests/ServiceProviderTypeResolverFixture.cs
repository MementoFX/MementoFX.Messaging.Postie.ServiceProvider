using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using SharpTestsEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.Messaging.Postie.ServiceProvider.Tests
{
    [TestFixture]
    public class ServiceProviderTypeResolverFixture
    {
        [Test]
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

        [Test]
        public void Ctor_should_set_Container_property()
        {
            var serviceCollectionMock = new Mock<IServiceCollection>().Object;
            var sut = new ServiceProviderTypeResolver(serviceCollectionMock);
            Assert.AreSame(serviceCollectionMock, sut.Services);
        }
    }
}
