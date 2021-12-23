using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Contract;

namespace BatchRename
{
    internal class RuleInfo
    {
        public IRule Rule { get; set; }
        public RuleContent RuleContent { get; set; }
        public RuleInfo(IRule rule)
        {
            this.Rule = rule;
            RuleContent = new RuleContent();
        }
    }
}
