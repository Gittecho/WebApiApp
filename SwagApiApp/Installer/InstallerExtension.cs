using Microsoft.Extensions.Configuration;

namespace SwagApiApp.Installer
{
    public static class InstallerExtension
    {
        public static void InstallerServiceExtension(
            this IServiceCollection services, IConfiguration configuration)
        {
            var InstallerImplementingClasses = typeof(Startup).Assembly.GetExportedTypes().Where(x => typeof(IInstaller).IsAssignableFrom(x)
           && !x.IsInterface && !x.IsAbstract);

            var ActiveInstances = InstallerImplementingClasses.Select(
                Activator.CreateInstance).Cast<IInstaller>().ToList();

            ActiveInstances.ForEach(Instance => Instance.InstallerService(services, configuration));
        }
    }
}