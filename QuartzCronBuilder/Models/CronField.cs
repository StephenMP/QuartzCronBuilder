using System;
using System.Collections.Generic;
using System.Linq;

namespace QuartzCronBuilder.Models
{
    public class CronField
    {
        protected readonly List<char> allowedTokens;

        public string CronExpression { get; protected set; }

        public bool IsMandatory { get; protected set; }

        public int MaxValue { get; protected set; }

        public int MinValue { get; protected set; }

        public CronField()
        {
            this.IsMandatory = true;
            this.MinValue = 0;
            this.MaxValue = 59;
            this.CronExpression = "0";
            this.allowedTokens = new List<char> { ',', '-', '*', '/' };
        }

        public void AllValues()
        {
            this.CronExpression = "*";
        }

        public void RangeOfValues(int from, int to)
        {
            this.CronExpression = $"{from}-{to}";
        }

        public void RunEveryXYears(int interval)
        {
            this.CronExpression = $"*/{interval}";
        }

        public void RunInIncrements(int startingValue, int increment)
        {
            this.CronExpression = $"{startingValue}/{increment}";
        }

        public void SpecificValues(params int[] specificValues)
        {
            if (this.ValuesAreValid(specificValues))
            {
                this.CronExpression = string.Join(",", specificValues);
            }
            else
            {
                throw new ArgumentException("You provided invalid values for the cron expression!");
            }
        }

        public bool ValuesAreValid(params int[] values)
        {
            return !values.Any(v => v < this.MinValue || v > this.MaxValue);
        }
    }
}
