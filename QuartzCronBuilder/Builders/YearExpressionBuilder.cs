using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class YearExpressionBuilder
    {
        private readonly CronExpressionBuilder cronExpressionBuilder;
        private readonly YearField yearField;

        public YearExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.yearField = new YearField();
            this.cronExpressionBuilder = cronExpressionBuilder;
        }

        public CronExpressionBuilder AllYears()
        {
            this.yearField.AllValues();
            return this.cronExpressionBuilder;
        }

        public string BuildCronExpression() => this.yearField.CronExpression;

        public CronExpressionBuilder RangeOfYears(int from, int to)
        {
            this.yearField.RangeOfValues(from, to);
            return this.cronExpressionBuilder;
        }

        public CronExpressionBuilder RunEveryXYears(int interval)
        {
            this.yearField.RunEveryXYears(interval);
            return this.cronExpressionBuilder;
        }

        public CronExpressionBuilder RunInYearsIncrements(int startingValue, int increment)
        {
            this.yearField.RunInIncrements(startingValue, increment);
            return this.cronExpressionBuilder;
        }

        public CronExpressionBuilder SpecificYears(params int[] years)
        {
            this.yearField.SpecificValues(years);
            return this.cronExpressionBuilder;
        }
    }
}
