using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstWithRepositoryPattern.Repository
{
    interface IRipository <T> where T:class
    {

        List<T> GetAllData();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);


        
    }
}
