using System;
using System.Collections.Generic;
using PolylineEncoder.Net.Models;

namespace PolylineEncoder.Net.Utility.Decoders
{
    public interface IPolylineDecoder
    {
        IEnumerable<Tuple<double, double>> DecodeAsTuples(string encodedPoints);
        IEnumerable<IGeoCoordinate> Decode(string encodedPoints);
    }
}