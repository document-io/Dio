using System;
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
				OperationType.Mutation => new SerialExecutionStrategy(),
				OperationType.Subscription => new SubscriptionExecutionStrategy(),
				_ => throw new InvalidOperationException($"Unexpected OperationType {context.Operation.OperationType}")
			};
		}
	}
}