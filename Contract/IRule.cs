using System;

namespace Contract
{
    public interface IRule
    {
        public string RuleName { get; }

        public Boolean ApplyRule(RuleContent ruleContent);

    }
}
