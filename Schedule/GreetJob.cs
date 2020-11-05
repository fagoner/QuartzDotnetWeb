using System;
using System.Threading.Tasks;
using Quartz;

namespace QuartzDotnetWeb.Schedule
{
    public class GreetJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync($"Greetings dev... DateTime: {DateTime.Now}");
            // ... your logic
            Console.Out.WriteLine($"Next job time(TimeUtc)!: {context.NextFireTimeUtc}");
        }
    }

}