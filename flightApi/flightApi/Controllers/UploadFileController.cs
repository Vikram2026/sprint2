using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace flightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                //var folderName = Path.Combine("Resources", "Images");
                // var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory());
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    // var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    string connectionString = "DefaultEndpointsProtocol=https;AccountName=myazurestorage12;AccountKey=ZVwU6jDMIjBX1Fnfo7TKjyFxSLbHn+NFGaeuIygCuryjRrP8BLPlFPIHhU7SdOkRFGShBFO3TSyw+AStEjhbhg==;EndpointSuffix=core.windows.net";
                    string containerName = "images";
                    BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
                    var blob = container.GetBlobClient(fileName);
                    var blobstream = System.IO.File.OpenRead(fileName);
                    await blob.UploadAsync(blobstream);
                    var Uri = blob.Uri.AbsoluteUri;
                    return Ok();

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);

            }
        }
    }
}