using Microsoft.EntityFrameworkCore;
using ProjectMVCwithDatabase.Controllers;
using ProjectMVCwithDatabase.Models;

namespace ProjectMVCwithDatabase.Data
{

    //step 3 this was creating a cintext object 
    public class ApplicationDbContext:DbContext //extedned DbContext manually
    {
        //create one controller by typing ctor manuaally and add..
        //(DbContextOptions<ApplicationDbContext> options):base(options) manually
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        //manually DbSet<Student> means you have Student model 
        public DbSet<Student>Students { get; set; }
    }
}
