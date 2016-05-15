using System;
using System.Collections.Generic;
using PolylineEncoder.Net.Models;
using PolylineEncoder.Net.Utility.Decoders;
using PolylineEncoder.Net.Utility.Encoders;

namespace PolylineEncoder.Net.Utility
{
    public class PolylineUtility : IPolylineUtility
    {
        private readonly IPolylineEncoder _encoder;
        private readonly IPolylineDecoder _decoder;

        public PolylineUtility() : this(new Encoder(), new Decoder()) { }

        public PolylineUtility(IPolylineEncoder encoder, IPolylineDecoder decoder)
        {
            _encoder = encoder;
            _decoder = decoder;
        }

        public string Encode(string delimtedLatLongs, char latLongDelmiter = ',', char pairDelimter = '|')
        {
            return _encoder.Encode(delimtedLatLongs, latLongDelmiter, pairDelimter);
        }

        public string Encode(double latitude, double longitude)
        {
            return _encoder.Encode(latitude, longitude);
        }

        public string Encode(IGeoCoordinate point)
        {
            return _encoder.Encode(point);
        }

        public string Encode(IEnumerable<Tuple<double, double>> points)
        {
            return _encoder.Encode(points);
        }

        public string Encode(IEnumerable<IGeoCoordinate> points)
        {
            return _encoder.Encode(points);
        }

        public string DecodeAsString(string encodedLatLongs, char latLongDelmiter = ',', char pairDelimter = '|')
        {
            return _decoder.DecodeAsString(encodedLatLongs, latLongDelmiter, pairDelimter);
        }

        public IEnumerable<Tuple<double, double>> DecodeAsTuples(string encodedPoints)
        {
            return _decoder.DecodeAsTuples(encodedPoints);
        }

        public IEnumerable<IGeoCoordinate> Decode(string encodedPoints)
        {
            return _decoder.Decode(encodedPoints);
        }
    }
}
