using NUnit.Framework;
using PolylineEncoder.Net.Models;
using PolylineEncoder.Net.Utility;
using System.Collections.Generic;
using System.Linq;

namespace PolylineEncoder.Tests
{
    public class DecodeTests
    {
        [Test]
        public void DecodeTest()
        {
            // arrange
            var s = "sezbGuogHuAa@TmFgAeCrBsH|FaG~CHE{IrAPtFkKgF}h@rC{AMuG~FoBpFdNvDoGhDKpBfB~CnKlHmT`IDdB{Yk@}MyCkNjKrDM`DhElFxCvNt@sS|BhB~AeKhBaBqAqDqAV}AoF}Akd@}ByJpAc@JkLfAzPzAUKmf@rBgRn@KP|G|AxCvAuAMqBtAECqCnFsGaHcl@hC{AfAyNhF_IfDsKnGcGtRqC|MbG|AcCxFtHxAyCo@aIdAaA?aFkFuT`JaC~C|Eh@mLzMpCtCaC`@|EzC}HxGbMt@xH_AvAzFs@";
            var utility = new PolylineUtility();

            // act
            IEnumerable<IGeoCoordinate> res = utility.Decode(s);

            // assert
            Assert.IsTrue(res != null);
            Assert.IsTrue(res.ToList().Count > 0);
        }

        [Test]
        public void EncodeTest()
        {
            // arrange
            var expected = "_c`|@_c`|@";
            var utility = new PolylineUtility();
            var p = new GeoCoordinate(10.0, 10.0);

            // act
            var encoded = utility.Encode(p);

            // assert
            Assert.IsTrue(encoded != null);
            Assert.IsTrue(encoded ==  expected);
        }

    }
}
