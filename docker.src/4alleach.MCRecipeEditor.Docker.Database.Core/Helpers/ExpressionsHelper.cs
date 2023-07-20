using System.Linq.Expressions;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Helpers;
internal static class ExpressionsHelper
{
    internal static Func<TResult> BuildLambdaWithConstructor<TResult>(params object[] args)
        where TResult : class
    {
        var type = typeof(TResult);
        var length = args.Length + 1;

        var variables = new ParameterExpression[length];
        var argExpressions = new Expression[length - 1];
        var argExpressionTypes = new Type[length - 1];

        for (int i = 1; i < length; i++)
        {
            var j = i - 1;
            var arg = args[j];
            var argType = arg.GetType();

            variables[i] = Expression.Variable(argType, $"var_{i}");
            argExpressions[j] = Expression.Assign(variables[i], Expression.Constant(arg));
            argExpressionTypes[j] = argType;
        }

        var ctor = Expression.New(type.GetConstructor(argExpressionTypes)!, argExpressions);

        variables[0] = Expression.Variable(type, "obj");
        var expression = Expression.Assign(variables[0], ctor);

        var block = Expression.Block(variables: variables, expression);
        var lambda = Expression.Lambda<Func<TResult>>(block);

        return lambda.Compile();
    }

    internal static Func<TResult> BuildLambda<TResult>(params object[] args)
        where TResult : class
    {
        var type = typeof(TResult);
        var ctor = Expression.New(type);
        var length = args.Length + 1;

        var variables = new ParameterExpression[length - 1];
        var expressions = new Expression[length];

        variables[0] = Expression.Variable(type, "obj");
        expressions[0] = Expression.Assign(variables[0], ctor);

        for (int i = 1; i < length; i++)
        {
            variables[i] = Expression.Variable(type, $"var_{i}");
            expressions[i] = Expression.Assign(variables[i], Expression.Constant(args[i - 1]));
        }

        var block = Expression.Block(variables: variables, expressions);
        var lambda = Expression.Lambda<Func<TResult>>(block);

        return lambda.Compile();
    }


}
