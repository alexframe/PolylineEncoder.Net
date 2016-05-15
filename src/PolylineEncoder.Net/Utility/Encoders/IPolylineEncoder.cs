using System;
using System.Collections.Generic;
using PolylineEncoder.Net.Models;

namespace PolylineEncoder.Net.Utility.Encoders
{
    public interface IPolylineEncoder
    {
        string Encode(string delimitedLatLongs, char latLongDelmiter = ',', char pairDelimter = '|');
        string Encode(double latitude, double longitude);
        string Encode(IGeoCoordinate point);
        string Encode(IEnumerable<Tuple<double, double>> points);
        string Encode(IEnumerable<IGeoCoordinate> points);
    }
}
