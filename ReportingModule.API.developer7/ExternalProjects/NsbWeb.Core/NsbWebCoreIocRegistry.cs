using StructureMap;

namespace NsbWeb.Core
{
    public class NsbWebCoreIocRegistry : Registry
    {
        public NsbWebCoreIocRegistry()
        {
            Scan(cfg =>
                {
                    cfg.TheCallingAssembly();
                    cfg.WithDefaultConventions();
                }
            );
        }
    }
}