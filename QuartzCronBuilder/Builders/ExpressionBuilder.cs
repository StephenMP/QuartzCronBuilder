using QuartzCronBuilder.Models;

namespace QuartzCronBuilder.Builders
{
    public abstract class ExpressionBuilder
    {
        public abstract string BuildCronExpression();
    }

    public abstract class ExpressionBuilder<TField, TExpressionBulder> : ExpressionBuilder where TField : CronField where TExpressionBulder : ExpressionBuilder
    {
        protected TExpressionBulder expressionBuilder;
        protected TField field;

        public override string BuildCronExpression() => $"{this.field.CronExpression} {this.expressionBuilder.BuildCronExpression()}";

        protected virtual TExpressionBulder All()
        {
            this.field.AllValues();
            return this.expressionBuilder;
        }

        protected TExpressionBulder RangeOf(int from, int to)
        {
            this.field.RangeOfValues(from, to);
            return this.expressionBuilder;
        }

        protected TExpressionBulder RunInIncrements(int startingValue, int increment)
        {
            this.field.RunInIncrements(startingValue, increment);
            return this.expressionBuilder;
        }

        protected TExpressionBulder RunEveryXInterval(int interval)
        {
            this.field.RunEveryXInterval(interval);
            return this.expressionBuilder;
        }

        protected TExpressionBulder Specific(params int[] values)
        {
            this.field.SpecificValues(values);
            return this.expressionBuilder;
        }
    }
}
