using GraphQL;
using GraphQL.Execution;
using GraphQL.Language.AST;

namespace DocumentIO
{
	public class DocumentIODocumentExecuter : DocumentExecuter
	{
		protected override IExecutionStrategy SelectExecutionStrategy(ExecutionContext context)
		{
			return context.Operation.OperationType switch
			{
				OperationType.Query => (IExecutionStrategy)new SerialExecutionStrategy(),
				_ => base.SelectExecutionStrategy(context)
			};
		}
	}
}