using System;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    public class YearExpressionBuilderFeatures
    {
        private YearExpressionBuilderSteps steps;
        private Random random;

        public YearExpressionBuilderFeatures()
        {
            this.steps = new YearExpressionBuilderSteps();
            this.random = new Random();
        }

        [Fact]
        public void CanCreateANewYearExpressionBuilder()
        {
            this.steps.GivenIHaveACronExpressionBuilder();

            this.steps.WhenICreateANewYearExpressionBuilder();

            this.steps.ThenTheYearExpressionBuilderShouldNotBeNull();
        }

        [Fact]
        public void CanSelectAllYears()
        {
            this.steps.GivenIHaveAYearExpressionBuilder();

            this.steps.WhenISelectAllYears();

            this.steps.ThenIShouldReceiveAllValues();
        }

        [Fact]
        public void CanSelectRangeOfYears()
        {
            this.steps.GivenIHaveAYearExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var from = this.random.Next(1, 51);
                var to = this.random.Next(51, 101);


                this.steps.WhenISelectRangeOfYears(from, to);

                this.steps.ThenIShouldReceiveTheRange(from, to);
            }
        }

        [Fact]
        public void CanSelectEveryXYears()
        {
            this.steps.GivenIHaveAYearExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var interval = random.Next(1, 101);

                this.steps.WhenISelectEveryXYears(interval);

                this.steps.ThenIShouldReceiveEveryXInterval(interval);
            }
        }

        [Fact]
        public void CanSelectIncrementsOfYears()
        {
            this.steps.GivenIHaveAYearExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var startingValue = random.Next(1, 10);
                var increment = random.Next(1, 10);

                this.steps.WhenISelectRunInYearsIncrements(startingValue, increment);

                this.steps.ThenIShouldReceiveIncrements(startingValue, increment);
            }
        }

        [Fact]
        public void CanSelectSpecificYears()
        {
            this.steps.GivenIHaveAYearExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var numberOfValues = this.random.Next(1, 51);
                var specificYears = new int[numberOfValues];
                for (var j = 0; j < numberOfValues; j++)
                {
                    specificYears[j] = random.Next(1970, 2100);
                }

                this.steps.WhenISelectSpecificYears(specificYears);

                this.steps.ThenIShouldReceiveTheSpecificValues(specificYears);
            }
        }
    }
}
