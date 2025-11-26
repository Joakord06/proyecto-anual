using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class SystemConfig
    {
        public int MinPasswordLength { get; set; } = 8;
        public int QuestionsToAnswer { get; set; } = 2;
        public bool RequireUpperLower { get; set; }
        public bool RequireDigits { get; set; }
        public bool RequireSpecial { get; set; }
        public bool Require2FA { get; set; }
        public bool DisallowPreviousPasswords { get; set; }
        public bool DisallowPersonalData { get; set; }
    }
}
