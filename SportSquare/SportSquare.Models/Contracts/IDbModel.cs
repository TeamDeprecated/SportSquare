using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Models.Contracts
{
    public interface IDbModel
    {
        bool IsDeleted { get; set; }
    }
}
