using StructureMap;

namespace ReportingModule.SystemTests.Common.Configuration
{
	public static class ContainerTestExtensions
    {
        public static IContainer Add<T>(this IContainer c, T b)
        {
            c.Configure(x => x.For<T>().Use(() => b));
            return c;
        }
    }
}