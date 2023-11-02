using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data 
{
    public class FootballBettingContext : DbContext
    {
        private const string ConnectionString = 
            "Server=DESKTOP-U0UT8KF\\SQLEXPRESS;Database=SoftUni;Trusted_Connection=True;TrustServerCertificate=True";
    }
}
