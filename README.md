### QuartzDonetWeb

Simple webApi to run a crontask every 30 seconds

#### Requirements

`Dotnet core 3.x (SDK)`

#### Install / Execute
`dotnet restore`
`dotnet run`

#### Expected Behaviour
Every 30 seconds, the following message will appear in the  console
```
Greetings dev... DateTime: 11/5/2020 11:48:00 AM
Next job time(TimeUtc)!: 11/5/2020 5:48:30 PM +00:00
```

#### Modify behaviour
Goto to  `Schedule/GreetJob.cs` to modify the action when the job is triggered
```
public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync($"Greetings dev... DateTime: {DateTime.Now}");
            // ... your logic
            Console.Out.WriteLine($"Next job time(TimeUtc)!: {context.NextFireTimeUtc}");
        }
```

#### Configure Cron/Schedule
To update the value, go to `Starpup.cs`, search for the following code

```
    ...
    services.AddSingleton(new JobSchedule(
        jobType: typeof(GreetJob),
        cronExpression: "0/30 * * * * ?")); //every 30'seconds
```
To set `cronExpression` please check: [quartz-scheduler.net/crontriggers.html](https://www.quartz-scheduler.net/documentation/quartz-2.x/tutorial/crontriggers.html)

#### Packages Cron/Schedule
- `dotnet add package Quartz --version 3.2.3`
- `dotnet add package Quartz.Extensions.DependencyInjection --version 3.2.3`

#### Reference/Source
- [Article](https://andrewlock.net/creating-a-quartz-net-hosted-service-with-asp-net-core/)
- [Demo code](https://github.com/andrewlock/blog-examples/tree/master/QuartzHostedService)
