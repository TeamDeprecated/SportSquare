namespace SportSquare.Data
{
    using System.Data.Entity;
    using SportSquare.Models;
    using Contracts;
    using System;

    public class SportSquareDbContext : DbContext, ISportSquareDbContext
    {
     
        public SportSquareDbContext()
            : base("name=SportSquareDbContext")
        {
        }

        public virtual IDbSet<Venue> Venues { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        void ISportSquareDbContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}