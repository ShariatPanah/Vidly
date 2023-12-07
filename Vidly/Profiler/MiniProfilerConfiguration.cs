namespace Vidly.Web.Profiler
{
    public static class MiniProfilerConfiguration
    {
        public static void AddMiniProfilerConfig(this IServiceCollection services)
        {
            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
            });
        }
    }
}
