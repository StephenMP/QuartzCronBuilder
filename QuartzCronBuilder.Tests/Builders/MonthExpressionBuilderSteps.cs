using QuartzCronBuilder.Builders;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    internal class MonthExpressionBuilderSteps : ExpressionBuilderSteps
    {
        private CronExpressionBuilder cronExpressionBuilder;
        private MonthExpressionBuilder monthExpressionBuilder;

        public MonthExpressionBuilderSteps()
        {
            base.Initialize(() =>
            {
                var cronExpression = this.monthExpressionBuilder.BuildCronExpression();
                var firstSpaceIndex = cronExpression.IndexOf(" ");
                return cronExpression.Substring(0, firstSpaceIndex);
            });
        }

        internal void GivenIHaveACronExpressionBuilder()
        {
            this.cronExpressionBuilder = new CronExpressionBuilder();
        }

        internal void WhenICreateANewMonthExpressionBuilder()
        {
            this.monthExpressionBuilder = new MonthExpressionBuilder(this.cronExpressionBuilder);
        }

        internal void ThenTheMonthExpressionBuilderShouldNotBeNull()
        {
            Assert.NotNull(this.monthExpressionBuilder);
        }

        internal void WhenISelectRangeOfMonths(int from, int to)
        {
            this.monthExpressionBuilder.RangeOfMonths(from, to);
        }

        internal void WhenISelectAllMonths()
        {
            this.monthExpressionBuilder.AllMonths();
        }

        internal void GivenIHaveAMonthExpressionBuilder()
        {
            this.GivenIHaveACronExpressionBuilder();
            this.WhenICreateANewMonthExpressionBuilder();
        }

        internal void WhenISelectEveryXMonths(int interval)
        {
            this.monthExpressionBuilder.RunEveryXMonths(interval);
        }

        internal void WhenISelectRunInMonthsIncrements(int startingValue, int increment)
        {
            this.monthExpressionBuilder.RunInMonthsIncrements(startingValue, increment);
        }

        internal void WhenISelectSpecificMonths(int[] specificMonths)
        {
            this.monthExpressionBuilder.SpecificMonths(specificMonths);
        }

        internal void WhenISelectSpecificMonthsAction(int[] specificMonths)
        {
            this.testCode = () => this.monthExpressionBuilder.SpecificMonths(specificMonths);
        }
    }
}