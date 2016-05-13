using System;

namespace PolylineEncoder.Net.Models
{
    public class GeoCoordinate : IGeoCoordinate
    {
        #region Properties

        private double _latitude;
        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                if (value < -90D || value > 90D)
                    throw new ArgumentOutOfRangeException(nameof(Latitude), $"{nameof(Latitude)} must be between -90 and 90.");

                _latitude = value;
            }
        }


        private double _longitude;
        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                if (value < -90D || value > 90D)
                    throw new ArgumentOutOfRangeException(nameof(Longitude), $"{nameof(Longitude)} must be between -180 and 180.");

                _longitude = value;
            }
        }

        #endregion

        #region c'tor

        public GeoCoordinate() { }

        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public GeoCoordinate(decimal latitude, decimal longitude) : this((double)latitude, (double)longitude) { }

        #endregion
    }
}
