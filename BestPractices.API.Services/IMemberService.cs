using BestPractices.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices.API.Services
{
    public interface IMemberService
    {
        public MemberDVO GetMemberById(int Id);
    }
}
