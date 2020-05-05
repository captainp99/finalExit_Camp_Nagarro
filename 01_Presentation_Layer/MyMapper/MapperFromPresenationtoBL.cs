using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_Presentation_Layer.MyMapper
{
  public class MapperFromPresenationtoBL
  {
    public static T2 Mapping<T1, T2>(T1 T1obj)
    {
      var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
      var mapper = config.CreateMapper();
      T2 T2obj = mapper.Map<T1, T2>(T1obj);
      return T2obj;

    }
  }
}
