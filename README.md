# PolylineEncoder.Net ![Alt](https://ci.appveyor.com/api/projects/status/github/alexframe/polylineencoder.net?branch=master&svg=true&retina=true "Build status")

### Features
Allows you to encode and decode lat/long pairs into Google's encoded polyline format. 
You can learn more about Google's algorithm [here][1]. Let this package do the work for you.

### Getting Started
Install via [`PolylineEncoder.Net`][2] package on Nuget. In Package manager run:

````csharp
Install-Package PolylineEncoder.Net
````

### Usage
It's easy to use, create an instance of `IPolylineUtility` and simply start encoding or decoding. You can pass in a delimited string 
of latitudes and longitudes, `IEnumerable<IGeoCoordinate>` or `IEnumerable<Tuple<double,double>>`.

```csharp
// Create a polyline utility.
var utility = new PolylineUtility();

// Pass through a delimted string...
var delimitedLatLngs = "38.5,-120.2|40.7,-120.95|43.252,-126.453";

// ...or create an IEnumberable<IGeoCoordinate>
// or IEnumerable<Tuple<double,double>>
var geoPoints = new List<IGeoCoordinate>
{
    new GeoCoordinate(38.5, -120.2),
    new GeoCoordinate(40.7, -120.95),
    new GeoCoordinate(43.252, -126.453)
};

// Encode points to string.
var polyLineFromString = utility.Decode(delimitedLatLngs, ',', '|'); // output: _p~iF~ps|U_ulLnnqC_mqNvxq`@
var polyLineFromPoints = utility.Encode(geoPoints); // output: _p~iF~ps|U_ulLnnqC_mqNvxq`@

// Decode string to points.
var decodedFromString = utility.DecodeAsString(polyLineFromString, ',', '|'); // output: "38.5,-120.2|40.7,-120.95|43.252,-126.453"
var decodedFromPoints = utility.Decode(polyLineFromPoints); // output: An IEnumerable<IGeoCoorindate> equal to geoPoints.
```

  [1]: https://developers.google.com/maps/documentation/utilities/polylinealgorithm
  [2]: https://www.nuget.org/packages/PolylineEncoder.Net
