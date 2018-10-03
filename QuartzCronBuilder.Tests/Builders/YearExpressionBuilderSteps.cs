using QuartzCronBuilder.Builders;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    internal class YearExpressionBuilderSteps : ExpressionBuilderSteps
    {
        private CronExpressionBuilder cronExpressionBuilder;
        private YearExpressionBuilder yearExpressBuilder;

        public YearExpressionBuilderSteps()
        {
            base.Initialize(() => this.yearExpressBuilder.BuildCronExpression());
        }

        internal void GivenIHaveACronExpressionBuilder()
        {
            this.cronExpressionBuilder = new CronExpressionBuilder();
        }

        internal void WhenICreateANewYearExpressionBuilder()
        {
            this.yearExpressBuilder = new YearExpressionBuilder(this.cronExpressionBuilder);
        }

        internal void ThenTheYearExpressionBuilderShouldNotBeNull()
        {
            Assert.NotNull(this.yearExpressBuilder);
        }

        internal void WhenISelectRangeOfYears(int from, int to)
        {
            this.yearExpressBuilder.RangeOfYears(from, to);
        }

        internal void WhenISelectAllYears()
        {
            this.yearExpressBuilder.AllYears();
        }

        internal void GivenIHaveAYearExpressionBuilder()
        {
            this.GivenIHaveACronExpressionBuilder();
            this.WhenICreateANewYearExpressionBuilder();
        }

        internal void WhenISelectEveryXYears(int interval)
        {
            this.yearExpressBuilder.RunEveryXYears(interval);
        }

        internal void WhenISelectRunInYearsIncrements(int startingValue, int increment)
        {
            this.yearExpressBuilder.RunInYearsIncrements(startingValue, increment);
        }

        internal void WhenISelectSpecificYears(int[] specificYears)
        {
            this.yearExpressBuilder.SpecificYears(specificYears);
        }

        internal void WhenISelectSpecificYearsAction(int[] specificYears)
        {
            this.testCode = () => this.yearExpressBuilder.SpecificYears(specificYears);
        }
    }
}