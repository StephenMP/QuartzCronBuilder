using System;
using Xunit;

namespace QuartzCronBuilder.Tests.Builders
{
    internal class ExpressionBuilderSteps
    {
        private Func<string> buildCronExpressionFunc;

        protected void Initialize(Func<string> buildCronExpressionFunc)
        {
            this.buildCronExpressionFunc = buildCronExpressionFunc;
        }

        public void ThenIShouldReceiveTheRange(int from, int to)
        {
            var actualResult = this.buildCronExpressionFunc();
            Assert.Equal($"{from}-{to}", actualResult);
        }

        public void ThenIShouldReceiveAllValues()
        {
            var actualResult = this.buildCronExpressionFunc();
            Assert.Equal("*", actualResult);
        }

        public void ThenIShouldReceiveEveryXInterval(int interval)
        {
            var actualResult = this.buildCronExpressionFunc();
            Assert.Equal($"*/{interval}", actualResult);
        }

        public void ThenIShouldReceiveIncrements(int startingValue, int increment)
        {
            var actualResult = this.buildCronExpressionFunc();
            Assert.Equal($"{startingValue}/{increment}", actualResult);
        }

        public void ThenIShouldReceiveTheSpecificValues(params int[] specificValues)
        {
            var actualResult = this.buildCronExpressionFunc();
            var values = string.Join(",", specificValues);
            Assert.Equal(values, actualResult);
        }
    }
}
