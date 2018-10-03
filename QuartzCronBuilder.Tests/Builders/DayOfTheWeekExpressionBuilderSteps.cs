using QuartzCronBuilder.Builders;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    internal class DayOfTheWeekExpressionBuilderSteps : ExpressionBuilderSteps
    {
        private CronExpressionBuilder cronExpressionBuilder;
        private DayOfTheWeekExpressionBuilder expressionBuilder;

        public DayOfTheWeekExpressionBuilderSteps()
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
            this.expressionBuilder = new DayOfTheWeekExpressionBuilder(this.cronExpressionBuilder);
        }

        internal void ThenTheHourExpressionBuilderShouldNotBeNull()
        {
            Assert.NotNull(this.expressionBuilder);
        }

        internal void WhenISelectRangeOfDayOfTheWeek(int from, int to)
        {
            this.expressionBuilder.RangeOfDaysOfTheWeek(from, to);
        }

        internal void WhenISelectAllDayOfTheWeek()
        {
            this.expressionBuilder.AllDaysOfTheWeek();
        }

        internal void GivenIHaveAHourExpressionBuilder()
        {
            this.GivenIHaveACronExpressionBuilder();
            this.WhenICreateANewHourExpressionBuilder();
        }

        internal void WhenISelectRunInDayOfTheWeekIncrements(int startingValue, int increment)
        {
            this.expressionBuilder.RunInDaysOfTheWeekIncrements(startingValue, increment);
        }

        internal void WhenISelectSpecificDayOfTheWeek(int[] specificDayOfTheWeek)
        {
            this.expressionBuilder.SpecificDaysOfTheWeek(specificDayOfTheWeek);
        }

        internal void WhenISelectSpecificDayOfTheWeekAction(int[] specificDayOfTheWeek)
        {
            this.testCode = () => this.expressionBuilder.SpecificDaysOfTheWeek(specificDayOfTheWeek);
        }
    }
}