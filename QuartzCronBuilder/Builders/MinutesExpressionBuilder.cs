using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class MinutesExpressionBuilder
    {
        private readonly HoursExpressionBuilder hoursExpressionBuilder;
        private readonly MinutesField minutesField;

        public MinutesExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.minutesField = new MinutesField();
            this.hoursExpressionBuilder = new HoursExpressionBuilder(cronExpressionBuilder);
        }

        public HoursExpressionBuilder AllMinutes()
        {
            this.minutesField.AllValues();
            return this.hoursExpressionBuilder;
        }

        public string BuildCronExpression() => $"{this.minutesField.CronExpression} {this.hoursExpressionBuilder.BuildCronExpression()}";

        public HoursExpressionBuilder RangeOfMinutes(int from, int to)
        {
            this.minutesField.RangeOfValues(from, to);
            return this.hoursExpressionBuilder;
        }

        public HoursExpressionBuilder RunEveryXMinutes(int interval)
        {
            this.minutesField.RunEveryXMinutes(interval);
            return this.hoursExpressionBuilder;
        }

        public HoursExpressionBuilder RunInMinuteIncrements(int startingValue, int increment)
        {
            this.minutesField.RunInIncrements(startingValue, increment);
            return this.hoursExpressionBuilder;
        }

        public HoursExpressionBuilder SpecificMinutes(params int[] seconds)
        {
            this.minutesField.SpecificValues(seconds);
            return this.hoursExpressionBuilder;
        }
    }
}
