using System.Reflection;
using Quartz;

namespace InmobiliariaAndes.Application.Extensions;

public static class JobsExtensions
{
    public static IEnumerable<dynamic?> GetJobFromAssembly(this Assembly assembly)
    {
        // base interface types
        var jobQuartzInterfaceType = typeof(IJob);        

        return assembly.GetTypes()
            .Where(t => jobQuartzInterfaceType.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
            .Select(x => Activator.CreateInstance(x) as dynamic)
            .Where(x => x != null); // dynamic to allow access to properties like JobName and JobGroup and can infer the type at runtime
    }
}
