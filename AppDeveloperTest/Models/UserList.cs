using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace AppDeveloperTest.Models
{
    public class UserList
    {
       public int Page { get; set; }
       public int PerPage { get; set; }
       public int Total { get; set; }
       public int TotalPages { get; set; }
       public User Data { get; set; }
    }
}
