# PolylineEncoder.Net ![Alt](https://ci.appveyor.com/api/projects/status/github/alexframe/polylineencoder.net?branch=master&svg=true&retina=true "Build status")

### Features
Allows you to encode and decode lat/long pairs into Google's encoded polyline format. 
Learn more about Google's algorithm [here.][1]

### Usage
```csharp
// Create a polyline utility.
var utility = new PolylineUtility();

// Create an IEnumberable<IGeoCoordinates>
// or IEnumerable<Tuple<double,double>>
var geoPoints = new List<IGeoCoordinate>
{
    new GeoCoordinate(38.5, -120.2),
    new GeoCoordinate(40.7, -120.95),
    new GeoCoordinate(43.252, -126.453)
};

// Encode points to string.
var polyLine = utility.Encode(geoPoints);

// output: _p~iF~ps|U_ulLnnqC_mqNvxq`@

// Decode string to points.
var decodedPoints = utility.Decode(polyLine);
```

  [1]: https://developers.google.com/maps/documentation/utilities/polylinealgorithm
