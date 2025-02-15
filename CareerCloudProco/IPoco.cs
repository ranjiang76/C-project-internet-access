using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    public interface IPoco
    {
        public Guid Id { get; set; }

 
    }

    public interface IPocoCode
    {
        public string Code { get; set; }


    }

    public interface IPocoLanguageID
    {
        public string LanguageID { get; set; }


    }
}
