using QuartzCronBuilder.Builders;
using QuartzCronBuilder.Models;

namespace QuartzCronBuilder
{
    public class CronExpressionBuilder : ExpressionBuilder<SecondsField, MinutesExpressionBuilder>
    {
        public CronExpressionBuilder()
        {
            this.field = new SecondsField();
            this.expressionBuilder = new MinutesExpressionBuilder(this);
        }

        public static CronExpressionBuilder NewExpression() => new CronExpressionBuilder();

        public MinutesExpressionBuilder AllSeconds()
        {
            return base.All();
        }

        public MinutesExpressionBuilder RangeOfSeconds(int from, int to)
        {
            return base.RangeOf(from, to);
        }

        public MinutesExpressionBuilder RunInSecondIncrements(int startingValue, int increment)
        {
            return base.RunInIncrements(startingValue, increment);
        }

        public MinutesExpressionBuilder SpecificSeconds(params int[] values)
        {
            return base.Specific(values);
        }
    }
}
