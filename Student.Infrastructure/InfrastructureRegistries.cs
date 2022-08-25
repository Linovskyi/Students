using Microsoft.Extensions.DependencyInjection;
using Student.Infrastructure.Persistent;

namespace Student.Infrastructure
{
    public static class InfrastructureRegistries
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IStudentRepository, StudentRepository>();
        }
    }
}