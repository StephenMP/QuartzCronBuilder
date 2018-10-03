using System;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    public class HoursExpressionBuilderFeatures
    {
        private readonly HoursExpressionBuilderSteps steps;
        private Random random;

        public HoursExpressionBuilderFeatures()
        {
            this.steps = new HoursExpressionBuilderSteps();
            this.random = new Random();
        }

        [Fact]
        public void CanCreateANewHourExpressionBuilder()
        {
            this.steps.GivenIHaveACronExpressionBuilder();

            this.steps.WhenICreateANewHourExpressionBuilder();

            this.steps.ThenTheHourExpressionBuilderShouldNotBeNull();
        }

        [Fact]
        public void CanSelectAllHours()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            this.steps.WhenISelectAllHours();

            this.steps.ThenIShouldReceiveAllValues();
        }

        [Fact]
        public void CanSelectRangeOfHours()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var from = this.random.Next(1, 6);
                var to = this.random.Next(6, 13);


                this.steps.WhenISelectRangeOfHours(from, to);

                this.steps.ThenIShouldReceiveTheRange(from, to);
            }
        }

        [Fact]
        public void CanSelectEveryXHours()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var interval = random.Next(1, 4);

                this.steps.WhenISelectEveryXHours(interval);

                this.steps.ThenIShouldReceiveEveryXInterval(interval);
            }
        }

        [Fact]
        public void CanSelectIncrementsOfHours()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var startingValue = random.Next(1, 4);
                var increment = random.Next(1, 4);

                this.steps.WhenISelectRunInHoursIncrements(startingValue, increment);

                this.steps.ThenIShouldReceiveIncrements(startingValue, increment);
            }
        }

        [Fact]
        public void CanSelectSpecificHours()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var numberOfValues = this.random.Next(1, 12);
                var specificHours = new int[numberOfValues];
                for (var j = 0; j < numberOfValues; j++)
                {
                    specificHours[j] = random.Next(1, 13);
                }

                this.steps.WhenISelectSpecificHours(specificHours);

                this.steps.ThenIShouldReceiveTheSpecificValues(specificHours);
            }
        }

        [Fact]
        public void CannotSelectSpecificHoursOutsideAllowedValues()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var numberOfValues = this.random.Next(1, 13);
                var specificHours = new int[numberOfValues];
                for (var j = 0; j < numberOfValues; j++)
                {
                    specificHours[j] = random.Next(int.MinValue, 1);
                }

                this.steps.WhenISelectSpecificHoursAction(specificHours);

                this.steps.ThenIShouldThrow<ArgumentException>("You provided invalid values for the cron expression!");

                for (var j = 0; j < numberOfValues; j++)
                {
                    specificHours[j] = random.Next(13, int.MaxValue);
                }

                this.steps.WhenISelectSpecificHoursAction(specificHours);

                this.steps.ThenIShouldThrow<ArgumentException>("You provided invalid values for the cron expression!");
            }
        }
    }
}