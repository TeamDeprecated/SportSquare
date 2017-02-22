using System.Reflection;

using NUnit.Framework;

using SportSquare.Models.AssemblyInfo;

namespace SportSquare.Models.Tests.AssemblyInfo
{
    [TestFixture]
    public class IModelAssemblyInfoTest
    {
        [Test]
        public void ModelsAssembly_ShouldContainsIModelAssemblyInfo()
        {
            var assembly = typeof(IModelAssemblyInfo);
            var result = Assembly.GetAssembly(assembly);

            Assert.That(result.FullName, Is.Not.Null.And.Contains("SportSquare.Models"));
        }
    }
}
