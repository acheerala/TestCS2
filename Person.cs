using System;
using System.Linq;
namespace TestCS
{
    public interface Identity
    {
        int Id { get; set; }
    }
    public class Person : Identity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person()
        {
        }
    }
}
