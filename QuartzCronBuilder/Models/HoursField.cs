namespace QuartzCronBuilder.Models
{
    public class HoursField : CronField
    {
        public HoursField() : base()
        {
            this.MaxValue = 23;
        }
    }
}
