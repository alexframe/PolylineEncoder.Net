using System;
using System.Collections.Generic;
using PolylineEncoder.Net.Models;
using PolylineEncoder.Net.Utility.Encoders;
using Xunit;

namespace PolylineEncoder.Net.Tests.EncoderTests
{

    public class EncoderTests
    {
        [Fact]
        public void StringEncodeShouldMatchGoogle()
        {
            var encoder = new Encoder();
            const string googleOutput = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";
            const string googleInput = "38.5,-120.2|40.7,-120.95|43.252,-126.453";

            Assert.Equal(encoder.Encode(googleInput), googleOutput);
        }

        [Fact]
        public void StringEncodeShouldNotMatchGoogle()
        {
            var encoder = new Encoder();
            const string googleOutput = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";
            const string googleInput = "43.252,-126.453|38.5,-120.2|40.7,-120.95";

            Assert.NotEqual(encoder.Encode(googleInput), googleOutput);
        }

        [Fact]
        public void GeoCoordsEncodeShouldMatchGoogle()
        {
            var encoder = new Encoder();
            const string googleOutput = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";

            var points = new List<IGeoCoordinate>
            {
                new GeoCoordinate(38.5, -120.2),
                new GeoCoordinate(40.7, -120.95),
                new GeoCoordinate(43.252, -126.453)
            };

            Assert.Equal(encoder.Encode(points), googleOutput);
        }

        [Fact]
        public void GeoCoordsEncodeShouldNotMatchGoogle()
        {
            var encoder = new Encoder();
            const string googleOutput = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";

            var points = new List<IGeoCoordinate>
            {
                new GeoCoordinate(38.5, -120.2),
                new GeoCoordinate(43.252, -126.453),
                new GeoCoordinate(40.7, -120.95)
            };

            Assert.NotEqual(encoder.Encode(points), googleOutput);
        }

        [Fact]
        public void TuplesEncodeShouldMatchGoogle()
        {
            var encoder = new Encoder();
            const string googleOutput = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";

            var points = new List<Tuple<double, double>>
            {
                Tuple.Create(38.5, -120.2),
                Tuple.Create(40.7, -120.95),
                Tuple.Create(43.252, -126.453)
            };

            Assert.Equal(encoder.Encode(points), googleOutput);
        }

        [Fact]
        public void TuplesEncodeShouldNotMatchGoogle()
        {
            var encoder = new Encoder();
            const string googleOutput = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";

            var points = new List<Tuple<double, double>>
            {
                Tuple.Create(38.5, -120.2),
                Tuple.Create(43.252, -126.453),
                Tuple.Create(40.7, -120.95)
            };

            Assert.NotEqual(encoder.Encode(points), googleOutput);
        }
    }
}
