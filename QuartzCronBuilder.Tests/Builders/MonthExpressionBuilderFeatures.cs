using System;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    public class MonthExpressionBuilderFeatures
    {
        private readonly MonthExpressionBuilderSteps steps;
        private Random random;

        public MonthExpressionBuilderFeatures()
        {
            this.steps = new MonthExpressionBuilderSteps();
            this.random = new Random();
        }

        [Fact]
        public void CanCreateANewMonthExpressionBuilder()
        {
            this.steps.GivenIHaveACronExpressionBuilder();

            this.steps.WhenICreateANewMonthExpressionBuilder();

            this.steps.ThenTheMonthExpressionBuilderShouldNotBeNull();
        }

        [Fact]
        public void CanSelectAllMonths()
        {
            this.steps.GivenIHaveAMonthExpressionBuilder();

            this.steps.WhenISelectAllMonths();

            this.steps.ThenIShouldReceiveAllValues();
        }

        [Fact]
        public void CanSelectRangeOfMonths()
        {
            this.steps.GivenIHaveAMonthExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var from = this.random.Next(1, 6);
                var to = this.random.Next(6, 13);


                this.steps.WhenISelectRangeOfMonths(from, to);

                this.steps.ThenIShouldReceiveTheRange(from, to);
            }
        }

        [Fact]
        public void CanSelectEveryXMonths()
        {
            this.steps.GivenIHaveAMonthExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var interval = random.Next(1, 4);

                this.steps.WhenISelectEveryXMonths(interval);

                this.steps.ThenIShouldReceiveEveryXInterval(interval);
            }
        }

        [Fact]
        public void CanSelectIncrementsOfMonths()
        {
            this.steps.GivenIHaveAMonthExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var startingValue = random.Next(1, 4);
                var increment = random.Next(1, 4);

                this.steps.WhenISelectRunInMonthsIncrements(startingValue, increment);

                this.steps.ThenIShouldReceiveIncrements(startingValue, increment);
            }
        }

        [Fact]
        public void CanSelectSpecificMonths()
        {
            this.steps.GivenIHaveAMonthExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var numberOfValues = this.random.Next(1, 12);
                var specificMonths = new int[numberOfValues];
                for (var j = 0; j < numberOfValues; j++)
                {
                    specificMonths[j] = random.Next(1, 13);
                }

                this.steps.WhenISelectSpecificMonths(specificMonths);

                this.steps.ThenIShouldReceiveTheSpecificValues(specificMonths);
            }
        }

        [Fact]
        public void CannotSelectSpecificMonthsOutsideAllowedValues()
        {
            this.steps.GivenIHaveAMonthExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var numberOfValues = this.random.Next(1, 13);
                var specificMonths = new int[numberOfValues];
                for (var j = 0; j < numberOfValues; j++)
                {
                    specificMonths[j] = random.Next(int.MinValue, 1);
                }

                this.steps.WhenISelectSpecificMonthsAction(specificMonths);

                this.steps.ThenIShouldThrow<ArgumentException>("You provided invalid values for the cron expression!");

                for (var j = 0; j < numberOfValues; j++)
                {
                    specificMonths[j] = random.Next(13, int.MaxValue);
                }

                this.steps.WhenISelectSpecificMonthsAction(specificMonths);

                this.steps.ThenIShouldThrow<ArgumentException>("You provided invalid values for the cron expression!");
            }
        }
    }
}
