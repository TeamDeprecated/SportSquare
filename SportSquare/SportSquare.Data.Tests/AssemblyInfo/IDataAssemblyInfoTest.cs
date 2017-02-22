using System.Reflection;

using NUnit.Framework;

using SportSquare.Data.AssemblyInfo;

namespace SportSquare.Data.Tests.AssemblyInfo
{
    [TestFixture]
    public class IDataAssemblyInfoTest
    {
        [Test]
        public void ModelsAssembly_ShouldContainsIModelAssemblyInfo()
        {
            var assembly = typeof(IDataAssemblyInfo);
            var result = Assembly.GetAssembly(assembly);

            Assert.That(result.FullName, Is.Not.Null.And.Contains("SportSquare.Data"));
        }
    }
}
