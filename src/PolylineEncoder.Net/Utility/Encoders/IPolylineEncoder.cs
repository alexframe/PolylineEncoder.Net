using System;
using System.Collections.Generic;
using PolylineEncoder.Net.Models;

namespace PolylineEncoder.Net.Utility.Encoders
{
    public interface IPolylineEncoder
    {
        string Encode(decimal latitude, decimal longitude);
        string Encode(IGeoCoordinate point);
        string Encode(IEnumerable<Tuple<decimal, decimal>> points);
        string Encode(IEnumerable<IGeoCoordinate> points);
    }
}
