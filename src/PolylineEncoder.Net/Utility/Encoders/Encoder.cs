using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PolylineEncoder.Net.Models;

namespace PolylineEncoder.Net.Utility.Encoders
{
    public class Encoder : IPolylineEncoder
    {
        public string Encode(decimal latitude, decimal longitude)
        {
            return Encode(new GeoCoordinate(latitude, longitude));
        }

        public string Encode(IGeoCoordinate point)
        {
            return Encode(new[] { point });
        }

        public string Encode(IEnumerable<Tuple<decimal, decimal>> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));

            var geoPoints = points.Select(point => new GeoCoordinate(point.Item1, point.Item2)).Cast<IGeoCoordinate>().ToList();
            return Encode(geoPoints);
        }

        public string Encode(IEnumerable<IGeoCoordinate> points)
        {
            if (points == null)
                throw new ArgumentNullException(nameof(points));

            var encodedPolyline = new StringBuilder();

            var encodeDiff = (Action<int>)(diff =>
            {
                var shifted = diff << 1;
                if (diff < 0)
                    shifted = ~shifted;

                var rem = shifted;
                while (rem >= 0x20)
                {
                    encodedPolyline.Append((char)((0x20 | (rem & 0x1f)) + 63));
                    rem >>= 5;
                }
                encodedPolyline.Append((char)(rem + 63));
            });

            var lastLat = 0;
            var lastLng = 0;
            foreach (var point in points)
            {
                var lat = (int)Math.Round(point.Latitude * 1E5);
                var lng = (int)Math.Round(point.Longitude * 1E5);

                encodeDiff(lat - lastLat);
                encodeDiff(lng - lastLng);

                lastLat = lat;
                lastLng = lng;
            }

            return encodedPolyline.ToString();
        }
    }
}
