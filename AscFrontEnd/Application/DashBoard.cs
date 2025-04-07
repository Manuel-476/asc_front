using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AscFrontEnd.DTOs.StaticsDto;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Packaging;

namespace AscFrontEnd.Application
{
    public class DashBoard
    {
        public static float VendaTotal() 
        {
            float total = 0;
            if (StaticProperty.frs.Any())
            {
                foreach (var fr in StaticProperty.frs)
                {
                    foreach (var art in fr.frArtigo)
                    {
                        total += art.preco * art.qtd;
                    }
                }
            }
            if (StaticProperty.fts.Any())
            {
                foreach (var ft in StaticProperty.fts)
                {
                    foreach (var art in ft.ftArtigo)
                    {
                        total += art.preco * art.qtd;
                    }
                }
            }

            return total;
        }
        public static float VendaTotal(DateTime dataStart,DateTime dataEnd)
        {
            float total = 0;

            if (StaticProperty.frs.Where(x => x.data >= dataStart && x.data <= dataEnd).Any())
            {
                foreach (var fr in StaticProperty.frs.Where(x => x.data >= dataStart && x.data <= dataEnd))
                {
                    foreach (var art in fr.frArtigo)
                    {
                        total += art.preco * art.qtd;
                    }
                }
            }
            if (StaticProperty.fts.Where(x => x.data >= dataStart && x.data <= dataEnd).Any())
            {
                foreach (var ft in StaticProperty.fts.Where(x => x.data >= dataStart && x.data <= dataEnd))
                {
                    foreach (var art in ft.ftArtigo)
                    {
                        total += art.preco * art.qtd;
                    }
                }
            }
            return total;
        }
        public static float VendaTotal(DateTime dataStart)
        {
            float total = 0;

            if (StaticProperty.frs.Where(x => x.data == dataStart).Any())
            {
                foreach (var fr in StaticProperty.frs.Where(x => x.data.Year == dataStart.Year))
                {
                    foreach (var art in fr.frArtigo)
                    {
                        total += art.preco * art.qtd;
                    }
                }
            }
            if (StaticProperty.fts.Where(x => x.data.Year == dataStart.Year).Any())
            {
                foreach (var ft in StaticProperty.fts.Where(x => x.data.Year == dataStart.Year))
                {
                    foreach (var art in ft.ftArtigo)
                    {
                        total += art.preco * art.qtd;
                    }
                }
            }
            return total;
        }

        public static float CompraTotal()
        {
            float total = 0;
            if (StaticProperty.vfrs.Any())
            {
                foreach (var vfr in StaticProperty.vfrs)
                {
                  foreach (var art in vfr.vfrArtigo)
                  {
                        total += art.preco * art.qtd;
                   }
                } 
            }
            if (StaticProperty.vfts.Any())
            {
                foreach (var vft in StaticProperty.vfts)
                {
                    foreach (var art in vft.vftArtigo)
                    {
                        total += art.preco * art.qtd;
                    }
                }
            }

            return total;
        }
        public static float CompraTotal(DateTime dataStart, DateTime dataEnd)
        {
            float total = 0;
            if (StaticProperty.vfrs.Where(x => x.data >= dataStart && x.data <= dataEnd).Any())
            {
                foreach (var vfr in StaticProperty.vfrs.Where(x => x.data >= dataStart && x.data <= dataEnd))
                {
                    foreach (var art in vfr.vfrArtigo)
                    {
                        total += art.preco * art.qtd;
                    }
                }
            }
            if (StaticProperty.vfts.Where(x => x.data >= dataStart && x.data <= dataEnd).Any())
            {
                foreach (var vft in StaticProperty.vfts.Where(x => x.data >= dataStart && x.data <= dataEnd))
                {
                    foreach (var art in vft.vftArtigo)
                    {
                        total += art.preco * art.qtd;
                    }
                }
            }
            return total;
        }
        public static float CompraTotal(DateTime dataStart)
        {
            float total = 0;
            if (StaticProperty.vfrs.Where(x => x.data.Year == dataStart.Year).Any())
            {
                foreach (var vfr in StaticProperty.vfrs.Where(x => x.data.Year == dataStart.Year))
                {
                    foreach (var art in vfr.vfrArtigo)
                    {
                        total += art.preco * art.qtd;
                    }
                }
            }
            if (StaticProperty.vfts.Where(x => x.data.Year == dataStart.Year).Any())
            {
                foreach (var vft in StaticProperty.vfts.Where(x => x.data.Year == dataStart.Year))
                {
                    foreach (var art in vft.vftArtigo)
                    {
                        total += art.preco * art.qtd;
                    }
                }
            }

            return total;
        }
    }
}
