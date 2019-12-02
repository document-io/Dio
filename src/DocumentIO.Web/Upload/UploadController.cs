using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO.Web
{
	[Route("uploads")]
	public class UploadController : ControllerBase
	{
		private readonly DatabaseContext databaseContext;

		public UploadController(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		[HttpPost("{fileId}")]
		public async Task UploadFile(Guid fileId, [FromForm(Name = "file")] IFormFile formFile)
		{
			await using (var memory = new MemoryStream())
			{
				await formFile.CopyToAsync(memory);

				var file = await databaseContext.Files.FirstAsync(x => x.Id == fileId);

				file.FileName = formFile.FileName;
				file.ContentType = formFile.ContentType;
				file.ContentDisposition = formFile.ContentDisposition;
				file.Length = formFile.Length;
				file.Content = memory.ToArray();

				await databaseContext.SaveChangesAsync();
			}
		}

		[HttpGet("{fileId}")]
		public async Task<IActionResult> DownloadFile(Guid fileId)
		{
			var file = await databaseContext.Files.FirstAsync(x => x.Id == fileId);

			return File(file.Content, file.ContentType, file.FileName);
		}
	}
}
