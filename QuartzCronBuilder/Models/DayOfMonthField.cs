namespace QuartzCronBuilder.Models
{
    public class DayOfMonthField : CronField
    {
        public DayOfMonthField() : base()
        {
            this.allowedTokens.AddRange(new char[] { '?', 'L', 'W' });
            this.MinValue = 1;
            this.MaxValue = 31;
        }

        public void Last()
        {
            this.CronExpression = "L";
        }

        public void NoSpecificValue()
        {
            this.CronExpression = "?";
        }

        public void WeekdaysOnly()
        {
            this.CronExpression = "W";
        }
    }
}
