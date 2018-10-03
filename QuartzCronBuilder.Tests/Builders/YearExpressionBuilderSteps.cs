using QuartzCronBuilder.Builders;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    internal class YearExpressionBuilderSteps : ExpressionBuilderSteps
    {
        private CronExpressionBuilder cronExpressionBuilder;
        private YearExpressionBuilder yearExpressionBuilder;

        public YearExpressionBuilderSteps()
        {
            base.Initialize(() => this.yearExpressionBuilder.BuildCronExpression());
        }

        internal void GivenIHaveACronExpressionBuilder()
        {
            this.cronExpressionBuilder = new CronExpressionBuilder();
        }

        internal void WhenICreateANewYearExpressionBuilder()
        {
            this.yearExpressionBuilder = new YearExpressionBuilder(this.cronExpressionBuilder);
        }

        internal void ThenTheYearExpressionBuilderShouldNotBeNull()
        {
            Assert.NotNull(this.yearExpressionBuilder);
        }

        internal void WhenISelectRangeOfYears(int from, int to)
        {
            this.yearExpressionBuilder.RangeOfYears(from, to);
        }

        internal void WhenISelectAllYears()
        {
            this.yearExpressionBuilder.AllYears();
        }

        internal void GivenIHaveAYearExpressionBuilder()
        {
            this.GivenIHaveACronExpressionBuilder();
            this.WhenICreateANewYearExpressionBuilder();
        }

        internal void WhenISelectEveryXYears(int interval)
        {
            this.yearExpressionBuilder.RunEveryXYears(interval);
        }

        internal void WhenISelectRunInYearsIncrements(int startingValue, int increment)
        {
            this.yearExpressionBuilder.RunInYearsIncrements(startingValue, increment);
        }

        internal void WhenISelectSpecificYears(int[] specificYears)
        {
            this.yearExpressionBuilder.SpecificYears(specificYears);
        }

        internal void WhenISelectSpecificYearsAction(int[] specificYears)
        {
            this.testCode = () => this.yearExpressionBuilder.SpecificYears(specificYears);
        }
    }
}