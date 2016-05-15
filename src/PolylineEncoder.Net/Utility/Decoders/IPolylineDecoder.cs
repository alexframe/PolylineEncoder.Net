using System;
using System.Collections.Generic;
using PolylineEncoder.Net.Models;

namespace PolylineEncoder.Net.Utility.Decoders
{
    public interface IPolylineDecoder
    {
        string DecodeAsString(string encodedLatLongs, char latLongDelmiter = ',', char pairDelimter = '|');
        IEnumerable<Tuple<double, double>> DecodeAsTuples(string encodedPoints);
        IEnumerable<IGeoCoordinate> Decode(string encodedPoints);
    }
}