namespace Application.Configuration.Services;
public static partial class RoleConfigurationManager
{
    private class RoleConfiguration
    {
        public string CommandName { get; set; }
        public string[] RequiredRoles { get; set; }

        public RoleConfiguration(string commandName, string[] requiredRoles)
        {
            CommandName = commandName;
            RequiredRoles = requiredRoles;
        }

        public RoleConfiguration()
        {
        }
    }
}
