using GraphQL;
using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOResolveFieldContext<TSource> : ResolveFieldContext<TSource>
	{
		public DocumentIOResolveFieldContext(ResolveFieldContext<TSource> context)
		{
			Source = context.Source;
			FieldName = context.FieldName;
			FieldAst = context.FieldAst;
			FieldDefinition = context.FieldDefinition;
			ReturnType = context.ReturnType;
			ParentType = context.ParentType;
			Arguments = context.Arguments;
			Schema = context.Schema;
			Document = context.Document;
			Fragments = context.Fragments;
			RootValue = context.RootValue;
			UserContext = context.UserContext;
			Operation = context.Operation;
			Variables = context.Variables;
			CancellationToken = context.CancellationToken;
			Metrics = context.Metrics;
			Errors = context.Errors;
			SubFields = context.SubFields;
			Path = context.Path;
		}

		public TArgumentType GetArgument<TArgumentType>()
			where TArgumentType : class, new()
		{
			return Arguments.ToObject<TArgumentType>();
		}

		public TFilter GetFilter<TFilter>()
			where TFilter : class, new()
		{
			return Arguments.ToObject<TFilter>();
		}
	}
}