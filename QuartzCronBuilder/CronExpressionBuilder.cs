using QuartzCronBuilder.Builders;
using QuartzCronBuilder.Models;

namespace QuartzCronBuilder
{
    public class CronExpressionBuilder
    {
        private readonly MinutesExpressionBuilder minutesExpressionBuilder;
        private readonly SecondsField secondsField;

        public CronExpressionBuilder()
        {
            this.secondsField = new SecondsField();
            this.minutesExpressionBuilder = new MinutesExpressionBuilder(this);
        }

        public static CronExpressionBuilder NewExpression() => new CronExpressionBuilder();

        public MinutesExpressionBuilder AllSeconds()
        {
            this.secondsField.AllValues();
            return this.minutesExpressionBuilder;
        }

        public string BuildCronExpression() => $"{this.secondsField.CronExpression} {this.minutesExpressionBuilder.BuildCronExpression()}".Trim();

        public MinutesExpressionBuilder RangeOfSeconds(int from, int to)
        {
            this.secondsField.RangeOfValues(from, to);
            return this.minutesExpressionBuilder;
        }

        public MinutesExpressionBuilder RunInSecondIncrements(int startingValue, int increment)
        {
            this.secondsField.RunInIncrements(startingValue, increment);
            return this.minutesExpressionBuilder;
        }

        public MinutesExpressionBuilder SpecificSeconds(params int[] seconds)
        {
            this.secondsField.SpecificValues(seconds);
            return this.minutesExpressionBuilder;
        }
    }
}
