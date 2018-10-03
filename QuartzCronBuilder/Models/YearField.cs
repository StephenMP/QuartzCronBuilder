namespace QuartzCronBuilder.Models
{
    public class YearField : CronField
    {
        public YearField() : base()
        {
            this.IsMandatory = false;
            this.MinValue = 1970;
            this.MaxValue = 2099;
            this.CronExpression = "";
        }
    }
}
