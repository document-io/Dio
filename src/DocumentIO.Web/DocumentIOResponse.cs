using System.Collections.Generic;
using System.Linq;
using Phema.Validation;

namespace DocumentIO.Web
{
	public class DocumentIOResponse
	{
		public IDictionary<string, string[]> Errors { get; set; }
		
		public static DocumentIOResponse From(IValidationContext validationContext)
		{
			return new DocumentIOResponse
			{
				Errors = validationContext.ValidationDetails
					.GroupBy(detail => detail.ValidationKey)
					.ToDictionary(
						grouping => grouping.Key,
						grouping => grouping.Select(detail => detail.ValidationMessage).ToArray())
			};
		}

		public static DocumentIOResponse<TPayload> From<TPayload>(TPayload payload)
		{
			return new DocumentIOResponse<TPayload>
			{
				Payload = payload
			};
		}
	}

	public class DocumentIOResponse<TPayload> : DocumentIOResponse
	{
		public TPayload Payload { get; set; }
	}
}