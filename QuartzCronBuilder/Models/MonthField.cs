using System.Linq;
using QuartzCronBuilder.Enums;

namespace QuartzCronBuilder.Models
{
    public class MonthField : CronField
    {
        public MonthField() : base()
        {
            this.MinValue = 1;
            this.MaxValue = 12;
        }

        public void SpecificValue(params CronMonth[] months)
        {
            var intValues = months.Select(month => (int)month).ToArray();
            this.SpecificValues(intValues);
        }
    }
}
