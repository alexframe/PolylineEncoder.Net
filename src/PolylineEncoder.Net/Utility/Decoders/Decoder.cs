﻿using System;
using System.Collections.Generic;
using PolylineEncoder.Net.Models;

namespace PolylineEncoder.Net.Utility.Decoders
{
    public class Decoder : IPolylineDecoder
    {
        public IEnumerable<Tuple<double, double>> DecodeAsTuples(string encodedPoints)
        {
            if (!string.IsNullOrEmpty(encodedPoints))
            {
                foreach (var point in Decode(encodedPoints))
                {
                    yield return Tuple.Create(point.Latitude, point.Longitude);
                }
            }
        }

        public IEnumerable<IGeoCoordinate> Decode(string encodedPoints)
        {
            if (!string.IsNullOrEmpty(encodedPoints))
            {
                var polyLineChars = encodedPoints.ToCharArray();
                var index = 0;

                var currentLat = 0;
                var currentLng = 0;

                while (index < polyLineChars.Length)
                {
                    // Calculate next Latitude
                    var sum = 0;
                    var shifter = 0;
                    int next5Bits;

                    do
                    {
                        next5Bits = polyLineChars[index++] - 63;
                        sum |= (next5Bits & 31) << shifter;
                        shifter += 5;
                    } while (next5Bits >= 32 && index < polyLineChars.Length);

                    if (index >= polyLineChars.Length)
                        break;

                    currentLat += (sum & 1) == 1 ? ~(sum >> 1) : sum >> 1;

                    // Calculate next longitude
                    sum = 0;
                    shifter = 0;

                    do
                    {
                        next5Bits = polyLineChars[index++] - 63;
                        sum |= (next5Bits & 31) << shifter;
                        shifter += 5;
                    } while (next5Bits >= 32 && index < polyLineChars.Length);

                    if (index >= polyLineChars.Length && next5Bits >= 32)
                        break;

                    currentLng += (sum & 1) == 1 ? ~(sum >> 1) : sum >> 1;

                    var geoPoint = new GeoCoordinate
                    {
                        Latitude = Convert.ToDouble(currentLat) / 100000.0,
                        Longitude = Convert.ToDouble(currentLng) / 100000.0
                    };

                    yield return geoPoint;
                }
            }
        }
    }
}
