using System.Linq;
using System.Collections.Generic;
using Phema.Validation;

namespace DocumentIO.Web
{
	public static class ValidationContextExtensions
	{
		public static IDictionary<string, string[]> FormatValidationDetails(this IValidationContext validationContext)
		{
			return validationContext.ValidationDetails
				.GroupBy(detail => detail.ValidationKey)
				.ToDictionary(
					grouping => grouping.Key,
					grouping => grouping.Select(detail => detail.ValidationMessage).ToArray());
		}
	}
}