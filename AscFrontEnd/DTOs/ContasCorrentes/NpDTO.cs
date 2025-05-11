using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Buyer.Application.DTOs.Documentos;

namespace AscFrontEnd.DTOs.ContasCorrentes
{
    public class NpDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public float quantia { get; set; }
        public ICollection<VftNpDTO> vftNps { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
    }

    public class VftNpDTO
    {
        public int Id { get; set; }
        public int vftId { get; set; }
       // public VftDTO vft { get; set; }
        public int npId { get; set; }
       // public NpDTO? np { get; set; }
    }
}
