using System;

namespace Contract
{
    public interface IRule
    {
        public string RuleName { get; }

        public ReturnApply ApplyRule(RuleContent ruleContent);

    }
}
