using EF.Model;
using SportSquare.Data.Contracts;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SportSquare.Services
{
    public class SearchService:ISearchService
    {
        private readonly IGenericRepository<Venue> repository;
        
        //TODO figureout how to abstract the models -> Automapper
        public SearchService(IGenericRepository<Venue> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            this.repository = repository;
        }

        public IEnumerable<Venue> FilterVenues(string filter, string location)
        {
            //return this.repository.Get<Venue>(Func<Venue>();
            return null;
             
        }
    }
}
