using QuartzCronBuilder.Builders;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    internal class MinutesExpressionBuilderSteps : ExpressionBuilderSteps
    {
        private CronExpressionBuilder cronExpressionBuilder;
        private MinutesExpressionBuilder expressionBuilder;

        public MinutesExpressionBuilderSteps()
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

        internal void WhenICreateANewMinuteExpressionBuilder()
        {
            this.expressionBuilder = new MinutesExpressionBuilder(this.cronExpressionBuilder);
        }

        internal void ThenTheMinuteExpressionBuilderShouldNotBeNull()
        {
            Assert.NotNull(this.expressionBuilder);
        }

        internal void WhenISelectRangeOfMinutes(int from, int to)
        {
            this.expressionBuilder.RangeOfMinutes(from, to);
        }

        internal void WhenISelectAllMinutes()
        {
            this.expressionBuilder.AllMinutes();
        }

        internal void GivenIHaveAMinuteExpressionBuilder()
        {
            this.GivenIHaveACronExpressionBuilder();
            this.WhenICreateANewMinuteExpressionBuilder();
        }

        internal void WhenISelectEveryXMinutes(int interval)
        {
            this.expressionBuilder.RunEveryXMinutes(interval);
        }

        internal void WhenISelectRunInMinutesIncrements(int startingValue, int increment)
        {
            this.expressionBuilder.RunInMinuteIncrements(startingValue, increment);
        }

        internal void WhenISelectSpecificMinutes(int[] specificMinutes)
        {
            this.expressionBuilder.SpecificMinutes(specificMinutes);
        }

        internal void WhenISelectSpecificMinutesAction(int[] specificMinutes)
        {
            this.testCode = () => this.expressionBuilder.SpecificMinutes(specificMinutes);
        }
    }
}