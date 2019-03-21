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
        public void ToStringTest()
        {
            // arrange
            var s = "sezbGuogHuAa@TmFgAeCrBsH|FaG~CHE{IrAPtFkKgF}h@rC{AMuG~FoBpFdNvDoGhDKpBfB~CnKlHmT`IDdB{Yk@}MyCkNjKrDM`DhElFxCvNt@sS|BhB~AeKhBaBqAqDqAV}AoF}Akd@}ByJpAc@JkLfAzPzAUKmf@rBgRn@KP|G|AxCvAuAMqBtAECqCnFsGaHcl@hC{AfAyNhF_IfDsKnGcGtRqC|MbG|AcCxFtHxAyCo@aIdAaA?aFkFuT`JaC~C|Eh@mLzMpCtCaC`@|EzC}HxGbMt@xH_AvAzFs@";
            var utility = new PolylineUtility();

            // act
            IEnumerable<IGeoCoordinate> res = utility.Decode(s);

            // assert
            Assert.IsTrue(res!=null);
            Assert.IsTrue(res.ToList().Count > 0);
        }
    }
}
