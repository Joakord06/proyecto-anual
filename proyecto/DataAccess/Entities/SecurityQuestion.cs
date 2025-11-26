using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class SecurityQuestion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Question { get; set; } = null!;
        public string AnswerHash { get; set; } = null!;
    }
}
