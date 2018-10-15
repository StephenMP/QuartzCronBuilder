# QuartzCronBuilder
A fluent API bulder to build cron expression for the Quartz scheduler

# Sample
Build a Cron Expression to run every 15 minutes, at the half minute (0:30, 15:30, 30:30, and 45:30) forever
```
var runScheduledJobsCronScheduleExpression = CronExpressionBuilder.NewExpression()
                                                                  .SpecificSeconds(30)
                                                                  .SpecificMinutes(0, 15, 30, 45)
                                                                  .AllHours()
                                                                  .AllDaysOfTheMonth()
                                                                  .AllMonths()
                                                                  .NoSpecificDaysOfTheWeek()
                                                                  .AllYears()
                                                                  .BuildCronExpression();

var runScheduledJobsCronSchedule = CronScheduleBuilder.CronSchedule(runScheduledJobsCronScheduleExpression);
var runScheduledJobsJob = JobBuilder.Create<RunScheduledJobsJob>().WithIdentity(typeof(RunScheduledJobsJob).Name).Build();
var runScheduledJobsTrigger = TriggerBuilder.Create().WithIdentity($"{typeof(RunScheduledJobsJob).Name}Trigger").StartNow().WithSchedule(runScheduledJobsCronSchedule).Build();
await scheduler.ScheduleJob(runScheduledJobsJob, runScheduledJobsTrigger);
```
