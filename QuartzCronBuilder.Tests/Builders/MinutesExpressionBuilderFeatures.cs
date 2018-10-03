using System;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    public class MinutesExpressionBuilderFeatures
    {
        private readonly MinutesExpressionBuilderSteps steps;
        private Random random;

        public MinutesExpressionBuilderFeatures()
        {
            this.steps = new MinutesExpressionBuilderSteps();
            this.random = new Random();
        }

        [Fact]
        public void CanCreateANewMinuteExpressionBuilder()
        {
            this.steps.GivenIHaveACronExpressionBuilder();

            this.steps.WhenICreateANewMinuteExpressionBuilder();

            this.steps.ThenTheMinuteExpressionBuilderShouldNotBeNull();
        }

        [Fact]
        public void CanSelectAllMinutes()
        {
            this.steps.GivenIHaveAMinuteExpressionBuilder();

            this.steps.WhenISelectAllMinutes();

            this.steps.ThenIShouldReceiveAllValues();
        }

        [Fact]
        public void CanSelectRangeOfMinutes()
        {
            this.steps.GivenIHaveAMinuteExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var from = this.random.Next(1, 6);
                var to = this.random.Next(6, 13);


                this.steps.WhenISelectRangeOfMinutes(from, to);

                this.steps.ThenIShouldReceiveTheRange(from, to);
            }
        }

        [Fact]
        public void CanSelectEveryXMinutes()
        {
            this.steps.GivenIHaveAMinuteExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var interval = random.Next(1, 4);

                this.steps.WhenISelectEveryXMinutes(interval);

                this.steps.ThenIShouldReceiveEveryXInterval(interval);
            }
        }

        [Fact]
        public void CanSelectIncrementsOfMinutes()
        {
            this.steps.GivenIHaveAMinuteExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var startingValue = random.Next(1, 4);
                var increment = random.Next(1, 4);

                this.steps.WhenISelectRunInMinutesIncrements(startingValue, increment);

                this.steps.ThenIShouldReceiveIncrements(startingValue, increment);
            }
        }

        [Fact]
        public void CanSelectSpecificMinutes()
        {
            this.steps.GivenIHaveAMinuteExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var numberOfValues = this.random.Next(1, 12);
                var specificMinutes = new int[numberOfValues];
                for (var j = 0; j < numberOfValues; j++)
                {
                    specificMinutes[j] = random.Next(1, 13);
                }

                this.steps.WhenISelectSpecificMinutes(specificMinutes);

                this.steps.ThenIShouldReceiveTheSpecificValues(specificMinutes);
            }
        }

        [Fact]
        public void CannotSelectSpecificMinutesOutsideAllowedValues()
        {
            this.steps.GivenIHaveAMinuteExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var numberOfValues = this.random.Next(1, 13);
                var specificMinutes = new int[numberOfValues];
                for (var j = 0; j < numberOfValues; j++)
                {
                    specificMinutes[j] = random.Next(int.MinValue, 1);
                }

                this.steps.WhenISelectSpecificMinutesAction(specificMinutes);

                this.steps.ThenIShouldThrow<ArgumentException>("You provided invalid values for the cron expression!");

                for (var j = 0; j < numberOfValues; j++)
                {
                    specificMinutes[j] = random.Next(13, int.MaxValue);
                }

                this.steps.WhenISelectSpecificMinutesAction(specificMinutes);

                this.steps.ThenIShouldThrow<ArgumentException>("You provided invalid values for the cron expression!");
            }
        }
    }
}