namespace SportSquare.Data
{
    using System.Data.Entity;
    using Contracts;
    using System;
    using EF.Model;
    public class SportSquareDbContext : DbContext, ISportSquareDbContext
    {
     
        public SportSquareDbContext()
            : base("SportSquareDbContext")
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