using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public class DayOfTheWeekExpressionBuilder : ExpressionBuilder<DayOfWeekField, YearExpressionBuilder>
    {
        public DayOfTheWeekExpressionBuilder(CronExpressionBuilder cronExpressionBuilder)
        {
            this.field = new DayOfWeekField();
            this.expressionBuilder = new YearExpressionBuilder(cronExpressionBuilder);
        }

        public YearExpressionBuilder AllDaysOfTheWeek()
        {
            this.field.AllValues();
            return this.expressionBuilder;
        }

        public YearExpressionBuilder LastDaysOfTheWeek()
        {
            this.field.Last();
            return this.expressionBuilder;
        }

        public YearExpressionBuilder NoSpecificDaysOfTheWeek()
        {
            this.field.NoSpecificValue();
            return this.expressionBuilder;
        }

        public YearExpressionBuilder NthDayOfMonth(int dayOfWeek, int weekNumber)
        {
            this.field.NthDayOfMonth(dayOfWeek, weekNumber);
            return this.expressionBuilder;
        }

        public YearExpressionBuilder RangeOfDaysOfTheWeek(int from, int to)
        {
            return base.RangeOf(from, to);
        }

        public YearExpressionBuilder RunInDaysOfTheWeekIncrements(int startingValue, int increment)
        {
            return base.RunInIncrements(startingValue, increment);
        }

        public YearExpressionBuilder SpecificDaysOfTheWeek(params int[] values)
        {
            return base.Specific(values);
        }
    }
}
