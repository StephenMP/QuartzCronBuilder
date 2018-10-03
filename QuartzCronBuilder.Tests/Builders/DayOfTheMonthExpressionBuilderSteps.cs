using QuartzCronBuilder.Builders;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    internal class DayOfTheMonthExpressionBuilderSteps : ExpressionBuilderSteps
    {
        private CronExpressionBuilder cronExpressionBuilder;
        private DayOfTheMonthExpressionBuilder expressionBuilder;

        public DayOfTheMonthExpressionBuilderSteps()
        {
            base.Initialize(() =>
            {
                var cronExpression = this.expressionBuilder.BuildCronExpression();
                var firstSpaceIndex = cronExpression.IndexOf(" ");
                return cronExpression.Substring(0, firstSpaceIndex);
            });
        }

        internal void GivenIHaveACronExpressionBuilder()
        {
            this.cronExpressionBuilder = new CronExpressionBuilder();
        }

        internal void WhenICreateANewHourExpressionBuilder()
        {
            this.expressionBuilder = new DayOfTheMonthExpressionBuilder(this.cronExpressionBuilder);
        }

        internal void ThenTheHourExpressionBuilderShouldNotBeNull()
        {
            Assert.NotNull(this.expressionBuilder);
        }

        internal void WhenISelectRangeOfDayOfTheMonth(int from, int to)
        {
            this.expressionBuilder.RangeOfDaysOfTheMonth(from, to);
        }

        internal void WhenISelectAllDayOfTheMonth()
        {
            this.expressionBuilder.AllDaysOfTheMonth();
        }

        internal void GivenIHaveAHourExpressionBuilder()
        {
            this.GivenIHaveACronExpressionBuilder();
            this.WhenICreateANewHourExpressionBuilder();
        }

        internal void WhenISelectRunInDayOfTheMonthIncrements(int startingValue, int increment)
        {
            this.expressionBuilder.RunInDaysOfTheMonthIncrements(startingValue, increment);
        }

        internal void WhenISelectSpecificDayOfTheMonth(int[] specificDayOfTheMonth)
        {
            this.expressionBuilder.SpecificDaysOfTheMonth(specificDayOfTheMonth);
        }

        internal void WhenISelectSpecificDayOfTheMonthAction(int[] specificDayOfTheMonth)
        {
            this.testCode = () => this.expressionBuilder.SpecificDaysOfTheMonth(specificDayOfTheMonth);
        }
    }
}