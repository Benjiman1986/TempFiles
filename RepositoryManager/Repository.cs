using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryManager
{
    public class Repository
    {
        public decimal TotalCount
        { 
            get {
                decimal total = 0;
                foreach (var r in MergeRepository)
                {
                    total += r.Stock;
                }

                return total;
            }
            private set { }
        }

        public List<SingleRepository> MergeRepository { get; set; }
    }

    public class SingleRepository
    {
        public string Name {get;set;}

        public decimal Stock {get;set;}
    }
}
