using Business.Lib;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/helpers")]
    [ApiController]
    public class HelpersController : CustomBaseController
    {
        private HelperLib helperLib;

        public HelpersController()
        {
            helperLib = new HelperLib();
        }

        #region [Security]

        [HttpGet("HashBCrypt")]
        public IActionResult HashBCrypt([FromQuery]string plainText)
        {
            var result = helperLib.HashBCrypt(plainText);
            return webAPIHelper.CreateResponse(result);
        }

        [HttpGet("VerifyBCrypt")]
        public IActionResult VerifyBCrypt([FromQuery]string plainText, [FromQuery]string hash)
        {
            var result =  helperLib.VerifyBCrypt(plainText, hash);
            return webAPIHelper.CreateResponse(result);
        }

        [HttpGet("EncryptString")]
        public IActionResult EncryptString([FromQuery]string clearText)
        {
            var result =  helperLib.EncryptString(clearText);
            return webAPIHelper.CreateResponse(result);
        }

        [HttpGet("DecryptString")]
        public IActionResult DecryptString([FromQuery]string cipherText)
        {
            var result =  helperLib.DecryptString(cipherText);
            return webAPIHelper.CreateResponse(result);
        }

        #endregion [Security]

        #region [Utilities]

        [HttpGet("GenRandomNumber")]
        public IActionResult GenRandomNumber([FromQuery]int min, [FromQuery]int max)
        {
            var result =  helperLib.GenRandomNumber(min, max);
            return webAPIHelper.CreateResponse(result);
        }

        [HttpGet("GenRandomChar")]
        public IActionResult GenRandomChar([FromQuery]int length)
        {
            var result =  helperLib.GenRandomChar(length);
            return webAPIHelper.CreateResponse(result);
        }

        #endregion [Utilities]

        #region [Compression]

        [HttpGet("CompressToGzipString")]
        public IActionResult CompressToGzipString([FromQuery]string plaintText)
        {
            var result =  helperLib.CompressToGzipString(plaintText);
            return webAPIHelper.CreateResponse(result);
        }

        [HttpGet("DecompressGzipString")]
        public IActionResult DecompressGzipString([FromQuery]string compressedString)
        {
            var result =  helperLib.DecompressGzipString(compressedString);
            return webAPIHelper.CreateResponse(result);
        }

        #endregion [Compression]
    }
}