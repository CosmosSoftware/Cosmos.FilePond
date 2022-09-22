using Cosmos.FilePond.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mime;
using System.Text;

namespace Cosmos.FilePond.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new Case() { CaseId = 1 };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Gets a unique GUID
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Process([FromForm] string files)
        {



            var contentType = Request.Headers["Content-Type"];
            var uploadOffset = Request.Headers["Upload-Offset"];
            var UploadName = Request.Headers["Upload-Name"];
            var uploadLenth = Request.Headers["Upload-Length"];

            var metaData = Request.Form["metadata"];

            return Ok(Guid.NewGuid().ToString());
        }

        [HttpPatch]
        public async Task<ActionResult> Process(IFormFile file, string patch)
        {
            using var memoryStream = new MemoryStream();
            await Request.Body.CopyToAsync(memoryStream);

            var contentType = Request.Headers["Content-Type"];
            var uploadOffset = Request.Headers["Upload-Offset"];
            var UploadName = Request.Headers["Upload-Name"];
            var uploadLenth = Request.Headers["Upload-Length"];

            return Ok();
        }

        // DELETE: api/RaffleImagesUpload/
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpDelete]
        public async Task<ActionResult> Revert()
        {

            // The server id will be send in the delete request body as plain text
            using StreamReader reader = new(Request.Body, Encoding.UTF8);
            string guid = await reader.ReadToEndAsync();
            if (string.IsNullOrEmpty(guid))
            {
                return BadRequest("Revert Error: Invalid unique file ID");
            }
            // var attachment = _context.Attachments.FirstOrDefault(i => i.Guid == guid);
            // We do some internal application validation here
            try
            {
                //// Form the request to delete from s3
                //var deleteObjectRequest = new DeleteObjectRequest
                //{
                //    BucketName = GetBucketName(), // add your own bucket name
                //    Key = guid
                //};
                //// https://docs.aws.amazon.com/sdk-for-net/v3/developer-guide/net-dg-config-netcore.html
                //await DeleteFromS3Async(deleteObjectRequest);

                //attachment.Deleted = true;
                //_context.Update(attachment);
                //await _context.SaveChangesAsync();
                return Ok();
            }
            //catch (AmazonS3Exception e)
            //{
            //    return BadRequest(string.Format("Revert Error:'{0}' when writing an object", e.Message));
            //}
            catch (Exception e)
            {
                return BadRequest(string.Format("Revert Error:'{0}' when writing an object", e.Message));
            }
        }

        [HttpGet()]
        public async Task<IActionResult> Load(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("Load Error: Invalid parameters");
            }
            //var attachment = await _context.Attachments.SingleOrDefaultAsync(i => i.Guid.Equals(id));
            //if (attachment is null)
            //{
            //    return NotFound("Load Error: File not found");
            //}

            //var imageKey = string.Format("{0}.{1}", attachment.Guid, attachment.FileType);
            //using Stream ImageStream = GetS3FileStreamAsync(GetBucketName(), imageKey);
            Response.Headers.Add("Content-Disposition", new ContentDisposition
            {
                FileName = string.Format("{0}.{1}", "MarsScreenShot.jpg", "jpg"),
                Inline = true // false = prompt the user for downloading; true = browser to try to show the file in line
            }.ToString());

            return File("/MarsScreenShot.jpg", "image/" + "jpg");
        }
    }
}