using System;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    public class DayOfTheWeekExpressionBuilderFeatures
    {
        private readonly DayOfTheWeekExpressionBuilderSteps steps;
        private Random random;

        public DayOfTheWeekExpressionBuilderFeatures()
        {
            this.steps = new DayOfTheWeekExpressionBuilderSteps();
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
        public void CanSelectAllDayOfTheWeek()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            this.steps.WhenISelectAllDayOfTheWeek();

            this.steps.ThenIShouldReceiveAllValues();
        }

        [Fact]
        public void CanSelectRangeOfDayOfTheWeek()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var from = this.random.Next(1, 6);
                var to = this.random.Next(6, 13);


                this.steps.WhenISelectRangeOfDayOfTheWeek(from, to);

                this.steps.ThenIShouldReceiveTheRange(from, to);
            }
        }

        [Fact]
        public void CanSelectIncrementsOfDayOfTheWeek()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var startingValue = random.Next(1, 4);
                var increment = random.Next(1, 4);

                this.steps.WhenISelectRunInDayOfTheWeekIncrements(startingValue, increment);

                this.steps.ThenIShouldReceiveIncrements(startingValue, increment);
            }
        }

        [Fact]
        public void CanSelectSpecificDayOfTheWeek()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var numberOfValues = this.random.Next(1, 8);
                var specificDayOfTheWeek = new int[numberOfValues];
                for (var j = 0; j < numberOfValues; j++)
                {
                    specificDayOfTheWeek[j] = random.Next(1, 8);
                }

                this.steps.WhenISelectSpecificDayOfTheWeek(specificDayOfTheWeek);

                this.steps.ThenIShouldReceiveTheSpecificValues(specificDayOfTheWeek);
            }
        }

        [Fact]
        public void CannotSelectSpecificDayOfTheWeekOutsideAllowedValues()
        {
            this.steps.GivenIHaveAHourExpressionBuilder();

            for (var i = 0; i < 10; i++)
            {
                var numberOfValues = this.random.Next(1, 8);
                var specificDayOfTheWeek = new int[numberOfValues];
                for (var j = 0; j < numberOfValues; j++)
                {
                    specificDayOfTheWeek[j] = random.Next(int.MinValue, 1);
                }

                this.steps.WhenISelectSpecificDayOfTheWeekAction(specificDayOfTheWeek);

                this.steps.ThenIShouldThrow<ArgumentException>("You provided invalid values for the cron expression!");

                for (var j = 0; j < numberOfValues; j++)
                {
                    specificDayOfTheWeek[j] = random.Next(9, int.MaxValue);
                }

                this.steps.WhenISelectSpecificDayOfTheWeekAction(specificDayOfTheWeek);

                this.steps.ThenIShouldThrow<ArgumentException>("You provided invalid values for the cron expression!");
            }
        }
    }
}