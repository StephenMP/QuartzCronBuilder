using System;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    public class DayOfTheMonthExpressionBuilderFeatures
    {
        private readonly DayOfTheMonthExpressionBuilderSteps steps;
        private Random random;

        public DayOfTheMonthExpressionBuilderFeatures()
        {
            this.steps = new DayOfTheMonthExpressionBuilderSteps();
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
        public void CanSelectAllDayOfTheMonth()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            this.steps.WhenISelectAllDayOfTheMonth();

            this.steps.ThenIShouldReceiveAllValues();
        }

        [Fact]
        public void CanSelectRangeOfDayOfTheMonth()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var from = this.random.Next(1, 15);
                var to = this.random.Next(15, 32);


                this.steps.WhenISelectRangeOfDayOfTheMonth(from, to);

                this.steps.ThenIShouldReceiveTheRange(from, to);
            }
        }

        [Fact]
        public void CanSelectIncrementsOfDayOfTheMonth()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var startingValue = random.Next(1, 4);
                var increment = random.Next(1, 4);

                this.steps.WhenISelectRunInDayOfTheMonthIncrements(startingValue, increment);

                this.steps.ThenIShouldReceiveIncrements(startingValue, increment);
            }
        }

        [Fact]
        public void CanSelectSpecificDayOfTheMonth()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var numberOfValues = this.random.Next(1, 32);
                var specificDayOfTheMonth = new int[numberOfValues];
                for (var j = 0; j < numberOfValues; j++)
                {
                    specificDayOfTheMonth[j] = random.Next(1, 32);
                }

                this.steps.WhenISelectSpecificDayOfTheMonth(specificDayOfTheMonth);

                this.steps.ThenIShouldReceiveTheSpecificValues(specificDayOfTheMonth);
            }
        }

        [Fact]
        public void CannotSelectSpecificDayOfTheMonthOutsideAllowedValues()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var numberOfValues = this.random.Next(1, 32);
                var specificDayOfTheMonth = new int[numberOfValues];
                for (var j = 0; j < numberOfValues; j++)
                {
                    specificDayOfTheMonth[j] = random.Next(int.MinValue, 1);
                }

                this.steps.WhenISelectSpecificDayOfTheMonthAction(specificDayOfTheMonth);

                this.steps.ThenIShouldThrow<ArgumentException>("You provided invalid values for the cron expression!");

                for (var j = 0; j < numberOfValues; j++)
                {
                    specificDayOfTheMonth[j] = random.Next(32, int.MaxValue);
                }

                this.steps.WhenISelectSpecificDayOfTheMonthAction(specificDayOfTheMonth);

                this.steps.ThenIShouldThrow<ArgumentException>("You provided invalid values for the cron expression!");
            }
        }
    }
}
