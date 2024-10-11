using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Biblioteca_Bella.Models.DAL
{
    internal interface IDao<T>
    {
        List<T> GetAll();

        // TODO
        // T? GetById(int id);
        // T? GetByCod(string co)
        bool insert(T par);
        bool update(T par);
        bool delete(T par);
    }
}
