using Microsoft.Extensions.Configuration;

namespace eCommerce.Shared.CoreSettings;

public static class CoreSetting
{
    public static Dictionary<string, string> ConnectionStrings { get; private set; }
    
    public static void SetConfig(IConfiguration configuration)
    {
        // SetConnectionStrings(configuration);
    }
    
    public static void SetConnectionStrings(IConfiguration configuration)
    {
        ConnectionStrings = configuration.GetRequiredSection("ConnectionStrings").Get<Dictionary<string, string>>();
    }
}