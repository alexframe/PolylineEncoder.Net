using PolylineEncoder.Net.Utility.Decoders;
using Xunit;

namespace PolylineEncoder.Net.Tests.DecoderTests
{

    public class DecoderTests
    {
        [Fact]
        public void StringDecodeShouldMatchGoogle()
        {
            var decoder = new Decoder();
            const string googleInput = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";
            const string googleOutput = "38.5,-120.2|40.7,-120.95|43.252,-126.453";

            Assert.Equal(decoder.DecodeAsString(googleInput), googleOutput);
        }

        [Fact]
        public void StringDecodeShouldNotMatchGoogle()
        {
            var decoder = new Decoder();
            const string googleInput = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";
            const string googleOutput = "40.7,-120.95|38.5,-120.2|43.252,-126.453";

            Assert.NotEqual(decoder.DecodeAsString(googleInput), googleOutput);
        }
        
    }
}
