using QuartzCronBuilder.Builders;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    internal class HoursExpressionBuilderSteps : ExpressionBuilderSteps
    {
        private CronExpressionBuilder cronExpressionBuilder;
        private HoursExpressionBuilder expressionBuilder;

        public HoursExpressionBuilderSteps()
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
            this.expressionBuilder = new HoursExpressionBuilder(this.cronExpressionBuilder);
        }

        internal void ThenTheHourExpressionBuilderShouldNotBeNull()
        {
            Assert.NotNull(this.expressionBuilder);
        }

        internal void WhenISelectRangeOfHours(int from, int to)
        {
            this.expressionBuilder.RangeOfHours(from, to);
        }

        internal void WhenISelectAllHours()
        {
            this.expressionBuilder.AllHours();
        }

        internal void GivenIHaveAHourExpressionBuilder()
        {
            this.GivenIHaveACronExpressionBuilder();
            this.WhenICreateANewHourExpressionBuilder();
        }

        internal void WhenISelectEveryXHours(int interval)
        {
            this.expressionBuilder.RunEveryXHours(interval);
        }

        internal void WhenISelectRunInHoursIncrements(int startingValue, int increment)
        {
            this.expressionBuilder.RunInHourIncrements(startingValue, increment);
        }

        internal void WhenISelectSpecificHours(int[] specificHours)
        {
            this.expressionBuilder.SpecificHours(specificHours);
        }

        internal void WhenISelectSpecificHoursAction(int[] specificHours)
        {
            this.testCode = () => this.expressionBuilder.SpecificHours(specificHours);
        }
    }
}