using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DAL.EF;
using ent = Solution.DO.Objects;

namespace Solution.Maps
{
    public class Mapas
    {
        public static void CreateMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ent.Authors2, data.authors2>();


                cfg.CreateMap<data.authors2, ent.Authors2>();

            });

        }
    }
}
