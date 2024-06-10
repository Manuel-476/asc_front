

using AscFrontEnd;
using System;
using System.Collections.Generic;

namespace EAscFrontEnd
{
    public class NcDTO
    {
        public int id { get; set; }
        public string documento { get; set; }
        public int clienteId { get; set; }
        public int status { get; set; }

        public DateTime data { get; set; }
        public List<NcArtigoDTO> ncArtigo { get; set; }
    }
}
