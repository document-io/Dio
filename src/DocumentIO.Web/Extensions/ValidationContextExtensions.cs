using System.Collections.Generic;
using System.Linq;
using Phema.Validation;

namespace DocumentIO.Web
{
	public static class ValidationContextExtensions
	{
		public static IDictionary<string, IEnumerable<string>> Into(this IValidationContext validationContext)
		{
			return validationContext.ValidationDetails
				.GroupBy(detail => detail.ValidationKey)
				.ToDictionary(detail => detail.Key, detail => detail.Select(d => d.ValidationMessage));
		}
	}
}