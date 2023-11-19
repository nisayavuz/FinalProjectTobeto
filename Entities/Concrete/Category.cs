
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        //cıplak class kalmasın: bir class herhangi bir inheritance ya da interface implementationı almıyorsa ilerde sorun yaratacaktır.
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
