using Business_Watch.DynamicFilter;
using Business_Watch.Helper;
using Business_Watch.Utils;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Business_Watch.Extension
{
    public class ExpressionData
    {
        public static ExpressionData Empty = new ExpressionData(null);
        Func<Type, object> _compiledExpression;
        public ExpressionData(LambdaExpression expression)
        {
            Expression = expression;
            _compiledExpression = FuncEx.Create((Type delegateType) =>
            {
                if (this.Expression == null)
                    return null;
                var delegatedExpressionType = typeof(Expression<>).MakeGenericType(delegateType);
                var compileMethod = delegatedExpressionType.GetMethod("Compile", Type.EmptyTypes);
                var compiledExpr = compileMethod.Invoke(this.Expression, null);
                return compiledExpr;
            });
            //.Memoize(true);
        }

        public LambdaExpression Expression { get; private set; }
        public TDelegate CompiledAs<TDelegate>()
        {
            return (TDelegate)_compiledExpression(typeof(TDelegate));
        }
        public bool IsEmpty { get { return this.Expression == null; } }
    }

    public static class ExpressionEx
    {
        public static readonly Expression EmptyGuid = Guid.Empty.AsConstantExpression(parameterised: true);
        public static readonly Expression False = false.AsConstantExpression();
        public static readonly Expression True = true.AsConstantExpression();
        public static readonly Expression[] BoolConstants = new[] { False, True };
        public static Expression BoolConstantOf(bool value) { return BoolConstants[value ? 1 : 0]; }
        public static bool IsFalseResultLambda(this LambdaExpression lambda)
        {
            return lambda.IsBoolConstantMatchResultLambda(false);
        }
        public static bool IsTrueResultLambda(this LambdaExpression lambda)
        {
            return lambda.IsBoolConstantMatchResultLambda(true);
        }
        public static bool IsConstantExpressionOfValue(this LambdaExpression lambda, object value)
        {
            var body = lambda == null ? null : lambda.Body;
            var constantExpression = body as ConstantExpression;
            var match = constantExpression != null && object.Equals(constantExpression.Value, value);
            return match;
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
        }

        static bool IsBoolConstantMatchResultLambda(this LambdaExpression lambda, bool value)
        {
            var body = lambda == null ? null : lambda.Body;
            var constantExpression = body as ConstantExpression;
            var match = constantExpression != null && object.Equals(constantExpression.Value, value);
            return match;
        }

        public static Expression<Func<TArg1, TRes>> Expr<TArg1, TRes>(Expression<Func<TArg1, TRes>> expr)
        {
            return expr;
        }
        public static Expression<Func<T, bool>> Expr<T>(Expression<Func<T, bool>> expr)
        {
            return expr;
        }
        public static Expression<Func<T>> Expr<T>(Expression<Func<T>> expr) { return expr; }
        public static Expression<Func<TArg1, TRes>> Create<TArg1, TRes>(Expression<Func<TArg1, TRes>> expr) { return expr; }
        public static Expression<Func<TArg1, TArg2, TRes>> Create<TArg1, TArg2, TRes>(Expression<Func<TArg1, TArg2, TRes>> expr) { return expr; }
        public static Expression<Func<TArg1, TArg2, TArg3, TRes>> Create<TArg1, TArg2, TArg3, TRes>(Expression<Func<TArg1, TArg2, TArg3, TRes>> expr) { return expr; }
        public static Expression<Func<TArg1, TArg2, TArg3, TArg4, TRes>> Create<TArg1, TArg2, TArg3, TArg4, TRes>(Expression<Func<TArg1, TArg2, TArg3, TArg4, TRes>> expr) { return expr; }
        public static Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TRes>> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TRes>(Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TRes>> expr) { return expr; }
        public static Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TRes>> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TRes>(Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TRes>> expr) { return expr; }
        public static Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TRes>> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TRes>(Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TRes>> expr) { return expr; }
        public static Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TRes>> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TRes>(Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TRes>> expr) { return expr; }
        public static Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TRes>> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TRes>(Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TRes>> expr) { return expr; }
        public static Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Targ10, TRes>> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Targ10, TRes>(Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Targ10, TRes>> expr) { return expr; }
        public static Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Targ10, TArg11, TRes>> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Targ10, TArg11, TRes>(Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Targ10, TArg11, TRes>> expr) { return expr; }
        public static Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Targ10, TArg11, TArg12, TRes>> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Targ10, TArg11, TArg12, TRes>(Expression<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, Targ10, TArg11, TArg12, TRes>> expr) { return expr; }

        public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> expr)
        {
            return expr;
        }

        public static Expression AsConstantExpression(this object value, bool parameterised = false)
        {
            if (!parameterised)
            {
                return Expression.Constant(value);
            }

            var valueType = value.GetType();

            var makeTuple =
                ExpressionEx.Converter(typeof(object), v =>
                    typeof(Expression).Call("Constant", new Type[] { }, typeof(Tuple).Call("Create", new[] { valueType }, v.CastAs(valueType)))
                )
                .Compile()
                .AsConstantExpression();

            var makeConstantExpression =
                ExpressionEx.Converter(typeof(object), v =>
                    typeof(Expression).Call("Property", new Type[] { }, Expression.Invoke(makeTuple, v), "Item1".AsConstantExpression())
                )
                .Compile();

            var res = ((Func<object, MemberExpression>)makeConstantExpression)(value);
            return (Expression)res;
        }

        public static ConstantExpression AsConstantExpressionTyped<T>(this T value)
        {
            return Expression.Constant(value, typeof(T));
        }

        public static MethodCallExpression Call(this Expression expression, string methodName, Type[] typeArguments, params Expression[] arguments)
        {
            return Expression.Call(expression, methodName, typeArguments, arguments);
        }
        public static MethodCallExpression CallExtension(this Expression target, Type extensionType, string extensionName, Type[] typeArguments, params Expression[] arguments)
        {
            return Expression.Call(extensionType, extensionName, typeArguments, new[] { target }.Concat(arguments.EmptyIfNull()).ToArray());
        }

        public static ParameterExpression AsParameter(this Type type, string name = null)
        {
            return Expression.Parameter(type, name);
        }

        public static MethodCallExpression Call(this Type tp, string methodName, Type[] typeArguments, params Expression[] arguments)
        {
            return Expression.Call(tp, methodName, typeArguments, arguments);
        }

        public static MethodCallExpression Call(this Expression expression, string methodName, params Expression[] arguments)
        {
            return Expression.Call(expression, methodName, null, arguments);
        }

        public static LambdaExpression AsLambda(this Expression expression, ParameterExpression parameter)
        {
            return Func(parameter, arg => expression);
        }

        public static LambdaExpression Func(Expression body)
        {
            var ftype = typeof(Func<>).MakeGenericType(body.Type);
            var res = Expression.Lambda(ftype, body);
            return res;
        }

        public static LambdaExpression Func(ParameterExpression parameter, Func<ParameterExpression, Expression> bodyFactory)
        {
            var body = bodyFactory(parameter);
            var ftype = typeof(Func<,>).MakeGenericType(parameter.Type, body.Type);
            var res = Expression.Lambda(ftype, body, parameter);
            return res;
        }

        public static LambdaExpression Func(ParameterExpression parameter1, ParameterExpression parameter2, Func<ParameterExpression, ParameterExpression, Expression> bodyFactory)
        {
            var body = bodyFactory(parameter1, parameter2);
            var ftype = typeof(Func<,,>).MakeGenericType(parameter1.Type, parameter2.Type, body.Type);
            var res = Expression.Lambda(ftype, body, parameter1, parameter2);
            return res;
        }

        public static LambdaExpression AsLambda(this Expression expression)
        {
            var ftype = typeof(Func<>).MakeGenericType(expression.Type);
            var res = Expression.Lambda(ftype, expression);
            return res;
        }

        public static ExpressionData AsExpressionData(this LambdaExpression expr)
        {
            return new ExpressionData(expr);
        }

        public static MemberExpression Property(this Expression instance, string propertyName)
        {
            try
            {
                return Expression.PropertyOrField(instance, propertyName);
            }
            catch (AmbiguousMatchException)
            {
                var property = instance.Type.GetProperties().Where(p => p.Name.Equals(propertyName)).FirstOrDefault();
                return Expression.Property(instance, property);
            }
        }

        public static Expression Coalesce(this Expression left, Expression right)
        {
            return Expression.Coalesce(left, right);
        }

        public static Expression Concat(this Expression aseq, Expression bseq)
        {
            var itemType = aseq.Type.GetEnumerableItemType();
            var res = aseq.CallEnumerable("Concat", new[] { itemType }, bseq);
            return res;
        }

        public static Type GetEnumerableItemType(this Type enumerableType)
        {
            var itemType = enumerableType.HasElementType ? enumerableType.GetElementType() : enumerableType.GetGenericArguments().Last();//[0];
            return itemType;
        }

        public static MethodCallExpression CallEnumerable(this Expression items, string enumerableMethodName, Type[] methodTypeArguments, params Expression[] args)
        {
            return Expression.Call(typeof(Enumerable), enumerableMethodName, methodTypeArguments, new[] { items }.Concat(args).ToArray());
        }

        public static LambdaExpression Converter(Type inputType, Func<ParameterExpression, Expression> body, Type outputType = null)
        {
            var inputParameter = Expression.Parameter(inputType);
            var b = body(inputParameter);

            if (b == null)
                return null;

            if (outputType == null)
                outputType = b.Type;

            var delegateType = typeof(Func<,>).MakeGenericType(inputType, outputType);
            var lambda = Expression.Lambda(delegateType, b, inputParameter);
            return lambda;
        }

        public static LambdaExpression Predicate(Type itemType, Func<ParameterExpression, Expression> body)
        {
            return Converter(itemType, body, outputType: typeof(bool));
        }

        public static UnaryExpression CastAs(this Expression instance, Type tp)
        {
            var res = Expression.MakeUnary(ExpressionType.Convert, instance, tp);
            return res;
        }

        public static UnaryExpression TypeAs(this Expression instance, Type tp)
        {
            var res = Expression.TypeAs(instance, tp);
            return res;
        }

        public static UnaryExpression CastAsNullable(this Expression instance)
        {
            return instance.CastAs(typeof(Nullable<>).MakeGenericType(instance.Type));
        }

        public static bool IsConstantExpressionOfValue(this Expression expr, object value)
        {
            var constExpr = expr as ConstantExpression;
            if (constExpr == null)
                return false;

            var res = object.Equals(constExpr.Value, value);
            return res;
        }

        static Expression BoolOpCombine(this IEnumerable<Expression> expressions, Func<Expression, Expression, Expression> op, bool boolValueToShortcut)
        {
            expressions = expressions.EmptyIfNull().Where(a => a != null);
            if (expressions.Where(expr => expr.IsConstantExpressionOfValue(boolValueToShortcut)).Any())
                return BoolConstantOf(boolValueToShortcut);

            if (expressions.Any() && expressions.All(a => a.IsConstantExpressionOfValue(!boolValueToShortcut)))
                return BoolConstantOf(!boolValueToShortcut);

            return expressions.Aggregate((Expression)null, (left, right) =>
            {
                if (left == null)
                    return right;

                if (right == null)
                    return left;

                return op(left, right);
            });
        }

        static LambdaExpression BoolOpCombineLambdas(this IEnumerable<LambdaExpression> expressions, Func<IEnumerable<Expression>, Expression> op, string parameterName = null)
        {
            var exprs = expressions.Where(e => e != null).ToList();
            //if parameterName is specified, we have to skip the optimisation and create a new lambda with a parameter carrying the requested parameterName
            if (exprs.IsEmpty() || exprs.Count == 1 && !parameterName.HasValue())
                return exprs.FirstOrDefault();

            var first = exprs.First();
            var parameterType = first.Parameters.First().Type;
            var param = Expression.Parameter(parameterType, parameterName);
            var body = op(exprs.Select(l => ForParameter(l, param).Body));
            return Expression.Lambda(body, param);
        }

        public static Expression Or(this IEnumerable<Expression> expressions)
        {
            return expressions.BoolOpCombine((left, right) => Expression.Or(left, right), boolValueToShortcut: true);
        }
        public static Expression And(this IEnumerable<Expression> expressions)
        {
            return expressions.BoolOpCombine((left, right) => Expression.And(left, right), boolValueToShortcut: false);
        }

        public static Expression<Func<T, bool>> And<T>(this IEnumerable<Expression<Func<T, bool>>> expressions)
        {
            return (Expression<Func<T, bool>>)expressions.BoolOpCombineLambdas(exprs => exprs.And());
        }

        public static LambdaExpression And(this IEnumerable<LambdaExpression> expressions)
        {
            return expressions.BoolOpCombineLambdas(exprs => exprs.And());
        }

        public static LambdaExpression Or(this IEnumerable<LambdaExpression> expressions)
        {
            return expressions.BoolOpCombineLambdas(exprs => exprs.Or());
        }

        public static LambdaExpression ForParameter(this LambdaExpression l1, ParameterExpression p)
        {
            var result = new ReplaceParamVisitor(l1.Parameters.First(), p).Visit(l1);
            return (LambdaExpression)result;
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            return (Expression<Func<T, bool>>)Expression.Lambda(expression.Body.Not(), expression.Parameters.Single());
        }

        public static Expression Or(this Expression left, Expression right)
        {
            return new[] { left, right }.Or();
        }

        public static UnaryExpression Quote(this Expression expression)
        {
            return Expression.Quote(expression);
        }
        public static UnaryExpression Not(this Expression expression)
        {
            return Expression.Not(expression);
        }

        public static ConditionalExpression IfElse(this Expression test, Expression ifTrue, Expression ifFalse)
        {
            return Expression.Condition(test, ifTrue, ifFalse);
        }

        public static BinaryExpression IsNull(this Expression expr)
        {
            return Expression.Equal(expr, Expression.Constant(null, expr.Type));
        }

        public static Expression NewTuple(Expression item1, Expression item2)
        {
            var items = new[] { item1, item2 };
            var tupleType = typeof(WriteableTuple<,>).MakeGenericType(item1.Type, item2.Type);
            var properties = tupleType.GetProperties();
            var res =
                Expression.MemberInit(
                    Expression.New(tupleType),
                    properties.Zip(items, (property, value) => new { property, value })
                    .Select(a => Expression.Bind(a.property, a.value))
                    .ToArray()
                );

            return res;
        }
        public static Expression NewTuple(Expression item1, Expression item2, Expression item3)
        {
            var items = new[] { item1, item2, item3 };
            var tupleType = typeof(WriteableTuple<,,>).MakeGenericType(item1.Type, item2.Type, item3.Type);
            var properties = tupleType.GetProperties();

            var res =
                Expression.MemberInit(
                    Expression.New(tupleType),
                    properties.Zip(items, (property, value) => new { property, value })
                    .Select(a => Expression.Bind(a.property, a.value))
                    .ToArray()
                );
            return res;
        }

        public static string GetPropertyName<T>(Expression<Func<T, Object>> expression)
        {
            MemberExpression memberExpression = null;

            // test first of all for nullable types which will have an implicit cast (i.e. c => Convert(c.Property))
            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null && unaryExpression.NodeType == ExpressionType.Convert)
            {
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                // all other expressions are expected to be direct member access
                memberExpression = expression.Body as MemberExpression;
            }

            if (memberExpression == null)
            {
                throw new ArgumentException(string.Format("Unsupported column expression type: {0}", expression.Body.GetType().Name));
            }

            return memberExpression.Member.Name;
        }

        public static object GetExpressionValue(Expression exp)
        {
            var ce = exp as ConstantExpression;
            if (ce != null)
                return ce.Value;

            var me = exp as MemberExpression;
            if (me != null)
                return me.Expression == null ? me.Member.GetValue(null) : me.Member.GetValue(GetExpressionValue(me.Expression));

            throw new Exception(string.Format("expected constant or member expression, received this: {0}", exp));
        }

        static Type LinqExtensionsClassSelector(Type items)
        {
            return items.IsAssignableTo(typeof(IQueryable)) ? typeof(Queryable) : items.IsAssignableTo(typeof(System.Collections.IEnumerable)) ? typeof(Enumerable) : Helpers.FailWith<Type>(string.Format("Expected IEnumerable or IQueryable, received {0}", items.FullName));
        }

        public static Expression Where(this Expression items, LambdaExpression predicate)
        {
            if (predicate == null)
                return items;

            var itemType = items.Type.GetEnumerableItemType();

            var res = Expression.Call(LinqExtensionsClassSelector(items.Type), "Where", new Type[] { itemType }, items, predicate);
            return res;
        }

        public static Expression Where(this Expression items, Func<ParameterExpression, Expression> predicate)
        {
            if (predicate == null)
                return items;

            var itemType = items.Type.GetEnumerableItemType();
            return items.Where(Predicate(itemType, predicate));
        }

        public static Expression Any(this Expression items, Func<ParameterExpression, Expression> predicate = null)
        {
            var itemType = items.Type.GetEnumerableItemType();

            if (predicate == null)
                return Expression.Call(LinqExtensionsClassSelector(items.Type), "Any", new Type[] { itemType }, items);

            var res = Expression.Call(LinqExtensionsClassSelector(items.Type), "Any", new Type[] { itemType }, items, Predicate(itemType, predicate));
            return res;
        }

        public static MethodCallExpression Select(this Expression source, Func<ParameterExpression, Expression> selector)
        {
            var itemType = source.Type.GetEnumerableItemType();
            var selectorExpr = ExpressionEx.Func(itemType.AsParameter(), selector);
            var res = source.CallEnumerable("Select", new[] { itemType, selectorExpr.ReturnType }, selectorExpr);
            return res;
        }

        public static Expression Take(this Expression items, int count)
        {
            var itemType = items.Type.GetEnumerableItemType();
            var res = items.CallEnumerable("Take", new[] { itemType }, count.AsConstantExpression());
            return res;
        }

        public static MemberExpression Property(this Expression instance, PropertyInfo property)
        {
            return Expression.Property(instance, property);
        }

        public static BinaryExpression Eq(this Expression expr, Expression v)
        {
            return expr.BinaryExpression(v, Expression.Equal);
        }

        public static BinaryExpression Gt(this Expression expr, Expression v)
        {
            return expr.BinaryExpression(v, Expression.GreaterThan);
        }

        public static BinaryExpression Gte(this Expression expr, Expression v)
        {
            return expr.BinaryExpression(v, Expression.GreaterThanOrEqual);
        }

        public static BinaryExpression Lt(this Expression expr, Expression v)
        {
            return expr.BinaryExpression(v, Expression.LessThan);
        }

        public static BinaryExpression Lte(this Expression expr, Expression v)
        {
            return expr.BinaryExpression(v, Expression.LessThanOrEqual);
        }

        private static BinaryExpression BinaryExpression(this Expression expr, Expression v, Func<Expression, Expression, BinaryExpression> binaryExpression)
        {
            var ltype = expr.Type;
            var rtype = v.Type;

            if (ltype != rtype)
                v = v.CastAs(ltype);

            var res = binaryExpression(expr, v);
            return res;
        }

        public static BinaryExpression Eq(this Expression expr, object v)
        {
            return expr.Eq(Expression.Constant(v));
        }

        //public static MethodCallExpression Call(this LambdaExpression func, params Expression[] arguments)
        //{
        //    return Expression.Call(
        //        typeof(LinqExt.Linq.Extensions),
        //        "Invoke",
        //        func.Type.GetGenericArguments(),
        //        new[] { func }.Concat(arguments.EmptyIfNull()).ToArray()
        //    );
        //}

        public static MethodCallExpression OrderBy(this Expression source, Func<ParameterExpression, Expression> keySelector, bool firstKey = true, bool descending = false)
        {
            var methodName = firstKey ? "OrderBy" : "ThenBy";
            if (descending)
                methodName += "Descending";

            var itemType = source.Type.GetEnumerableItemType();
            var keySelectorExpr = ExpressionEx.Func(itemType.AsParameter(), keySelector);
            var res = source.CallEnumerable(methodName, new[] { itemType, keySelectorExpr.ReturnType }, keySelectorExpr);
            return res;
        }

        public static Expression<Func<T, bool>> ConstructAndExpressionTree<T>(List<ExpressionFilter> filters, bool applyAndOpertor)
        {
            if (filters == null || filters.Count == 0)
                return null;
            // create parameter
            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = ExpressionRetriever.GetExpression<T>(param, filters[0], filters[0].PropertyType);
            for (int i = 1; i < filters.Count; i++)
            {
                if (applyAndOpertor)
                {
                    exp = Expression.And(exp, ExpressionRetriever.GetExpression<T>(param, filters[i], filters[i].PropertyType));
                }
                else
                {
                    exp = Expression.Or(exp, ExpressionRetriever.GetExpression<T>(param, filters[i], filters[i].PropertyType));
                }
            }
            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        public static Expression<Func<T, bool>> CombineExpressions<T>(List<ExpressionFilter> filters, bool applyAndOpertor)
        {
            if (filters != null && filters.Count > 0)
            {
                foreach (var item in filters)
                {
                    item.ActualPropertyName = item.PropertyName.Pascalize();
                    var proInfo = typeof(T).GetPropertyEx(item.ActualPropertyName);
                    item.PropertyType = proInfo.PropertyType;
                    var type = proInfo.PropertyType;
                    if (item.Comparison == ComparisonOperator.In)
                    {
                        type = typeof(List<>).MakeGenericType(proInfo.PropertyType);
                        var result = ((IEnumerable)item.Value);
                        item.ActualValue = EnumerationEx.CastFromJson(item.Value, proInfo.PropertyType);
                        item.PropertyType = type;
                    }
                    else
                    {
                        item.ActualValue = type.GetFromJson(item.Value);
                    }


                }
                return ConstructAndExpressionTree<T>(filters, applyAndOpertor);
            }
            return null;
        }

        public static Expression ListContains(this Expression list, Expression item)
        {
            var lt = list.Type;
            var listItemType = lt.GetEnumerableItemType();
            if (item.Type != listItemType)
                item = item.CastAs(listItemType);

            var res = Expression.Call(typeof(Enumerable), "Contains", new[] { item.Type }, list, item);
            return res;
        }

    }

    internal class ReplaceParamVisitor : ExpressionVisitor
    {
        public ReplaceParamVisitor(ParameterExpression oldParam, Expression replacement)
        {
            Param = oldParam;
            Replacement = replacement;
        }

        ParameterExpression Param;
        Expression Replacement;

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == Param)
                return Replacement;
            else
                return node;
        }
    }

    public class WriteableTuple<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
    }
    public class WriteableTuple<T1, T2, T3>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public T3 Item3 { get; set; }
    }

    public static class EnumerationEx
    {
        [System.Diagnostics.DebuggerStepThrough]
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> items)
        {
            return items ?? Enumerable.Empty<T>();
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.EmptyIfNull().Any();
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static IEnumerable<T> SeparateWith<T>(this IEnumerable<T> items, T separator)
        {
            var first = true;
            foreach (var item in items.EmptyIfNull())
            {
                if (first)
                    first = false;
                else
                    yield return separator;
                yield return item;
            }
        }

        public static Option<T> FirstOrNone<T>(this IEnumerable<T> items)
        {
            foreach (var item in items.EmptyIfNull())
            {
                return Option.Some(item);
            }

            return Option<T>.None;
        }

        public static IEnumerable Cast(this IEnumerable self, Type innerType)
        {
            var methodInfo = typeof(Enumerable).GetMethod("Cast");
            var genericMethod = methodInfo.MakeGenericMethod(innerType);
            return genericMethod.Invoke(null, new[] { self }) as IEnumerable;
        }

        public static IEnumerable CastFromJson(object o, Type innerType)
        {
            var list = o as ICollection<Newtonsoft.Json.Linq.JToken>;
            return list.Select(s => s.ToObject(innerType));
        }
    }

    public static class MemberInfoEx
    {
        public static IEnumerable<T> OfExactType<T>(this IEnumerable<T> attributes)
            where T : Attribute
        {
            return attributes.Where(a => a.GetType() == typeof(T));
        }

        public static object GetValue(this MemberInfo m, object obj, bool memberCanBeStatic = false)
        {
            var fi = m as FieldInfo;
            if (fi != null)
                memberCanBeStatic = fi.IsStatic;

            if (m == null || (!memberCanBeStatic && obj == null))
                return null;

            if (fi != null)
                return fi.GetValue(obj);

            {
                var vg = m as PropertyInfo;
                if (vg != null)
                    return vg.GetValue(obj, null);
            }

            return null;
        }

        public static void SetValue(this MemberInfo m, object instance, object value)
        {
            if (instance == null)
                return;

            {
                var vg = m as PropertyInfo;
                if (vg != null)
                    vg.SetValue(instance, value, null);
            }

            {
                var vg = m as FieldInfo;
                if (vg != null)
                    vg.SetValue(instance, value);
            }
        }

        public static Type Type(this MemberInfo m)
        {
            {
                var vg = m as PropertyInfo;
                if (vg != null)
                    return vg.PropertyType;
            }

            {
                var vg = m as FieldInfo;
                if (vg != null)
                    return vg.FieldType;
            }

            return null;
        }

        public static bool IsReadonly(this MemberInfo m)
        {
            {
                var vg = m as PropertyInfo;
                if (vg != null)
                    return !vg.CanWrite;
            }

            {
                var vg = m as FieldInfo;
                if (vg != null)
                    return vg.IsInitOnly;
            }

            return true;
        }

        public static PropertyInfo GetPropertyEx(this Type type, string propertyName)
        {
            return type.GetProperties().Where(p => p.Name == propertyName).OrderBy(p => p.DeclaringType == type ? 0 : 1).First();
        }

        public static IEnumerable<PropertyInfo> GetAllProperties(this Type type)
        {
            return type.GetProperties();
        }

        public static bool DoesTypeSupportInterface(this Type type, Type inter)
        {
            if (inter.IsAssignableFrom(type))
                return true;
            if (type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == inter))
                return true;
            return false;
        }

        public static string GetPropertyName<TType, TDataType>(this TType type, System.Linq.Expressions.Expression<Func<TType, TDataType>> propertyNameGetter)
        {
            var property = propertyNameGetter.Body as System.Linq.Expressions.MemberExpression;
            if (property == null)
            {
                throw new ArgumentException("Invalid expression format");
            }

            return property.Member.Name;
        }

        public static bool IsAsync(this MethodInfo methodInfo)
        {
            Type asyncAttrType = typeof(AsyncStateMachineAttribute);
            return methodInfo.GetCustomAttribute(asyncAttrType) != null;
        }
    }

    public static class TypeEx
    {
        public static bool IsAssignableTo(this Type type, Type destType)
        {
            return destType.IsAssignableFrom(type);
        }

        public static bool IsGenericOf(this Type tp, Type genericType)
        {
            return tp.IsGenericType && tp.GetGenericTypeDefinition() == genericType;
        }

        public static bool IsProxyType(this Type tp)
        {
            return tp.Assembly.IsDynamic;
        }

        public static Type SkipProxyType(this Type tp)
        {
            if (tp.IsProxyType())
                return tp.BaseType;

            return tp;
        }

        public static object ChangeType(this Type type, object value)
        {
            if (value == null && type.IsGenericType) return Activator.CreateInstance(type);
            if (value == null) return null;
            if (type == value.GetType()) return value;
            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                else
                    return Enum.ToObject(type, value);
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = innerType.ChangeType(value);
                return Activator.CreateInstance(type, new object[] { innerValue });
            }
            if (value is string && type == typeof(Guid)) return new Guid(value as string);
            if (value is string && type == typeof(Version)) return new Version(value as string);
            if (!(value is IConvertible)) return value;
            return Convert.ChangeType(value, type);
        }

        /// <summary>
        /// Get Object from Json object
        /// </summary>
        /// <param name="type">Type convert to</param>
        /// <param name="value">Json value</param>
        /// <returns></returns>
        public static object GetFromJson(this Type type, object value)
        {
            var json = value as Newtonsoft.Json.Linq.JToken;
            if (json != null)
                return json.ToObject(type);
            var data = type.ChangeType(value);
            return data;
        }
    }

    public static class StringEx
    {
        public static int LengthEx(this string value)
        {
            return value == null ? 0 : value.Length;
        }
        public static bool IsNumeric(this string input)
        {
            decimal value;
            return decimal.TryParse(input, out value);
        }

        public static bool IsJson(this string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}") || input.StartsWith("[") && input.EndsWith("]");
        }

        public static bool IsInteger(this string input)
        {
            int value;
            return int.TryParse(input, out value);
        }

        public static string Append(this string input, string value)
        {
            return string.Concat(input, value);
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static string Concatenate(this IEnumerable<string> strings, string separator)
        {
            return string.Concat(strings.SeparateWith(separator));
        }

        /// <summary>
		/// Get a substring of the first N characters.
		/// </summary>
		/// <example>
		/// Implementation: "cat".Truncate(1);
		/// Output: "c"
		/// </example>
        public static string Truncate(this string source, int length)
        {
            return source.Length <= length ? source : source.Substring(0, length);
        }

        /// <summary>
        /// Get a substring of the first N characters.
        /// </summary>
        /// <example>
        /// Implementation: "cat".Truncate(1);
        /// Output: "c"
        /// </example>
        public static string Elipsis(this string source, int length)
        {
            return source.EmptyIfNull().Length <= length ? source : source.Substring(0, length) + "...";
        }

        //from Newtonsoft.Json.Utilities.StringUtilities
        public static string ToCamelCase(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            if (!char.IsUpper(s[0]))
                return s;

            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                bool hasNext = (i + 1 < s.Length);
                if ((i == 0 || !hasNext) || char.IsUpper(s[i + 1]))
                {
                    char lowerCase;
#if !(NETFX_CORE || PORTABLE)
                    lowerCase = char.ToLower(s[i], System.Globalization.CultureInfo.InvariantCulture);
#else
                    lowerCase = char.ToLower(s[i]);
#endif

                    sb.Append(lowerCase);
                }
                else
                {
                    sb.Append(s.Substring(i));
                    break;
                }
            }

            return sb.ToString();
        }

        public static string EmptyIfNull(this string value)
        {
            return value ?? String.Empty;
        }

        public static string NullIfEmpty(this string value)
        {
            return string.IsNullOrEmpty(value) ? null : value;
        }

        public static string Alt(this string value, string altValue)
        {
            return value.HasValue() ? value : altValue;
        }

        public static string Alt(this string value, Func<string> altValue)
        {
            return value.HasValue() ? value : altValue();
        }

        public static bool HasValue(this string value)
        {
            return !String.IsNullOrEmpty(value);
        }

        public static string ToUpperEx(this string value)
        {
            return value == null ? value : value.ToUpper();
        }

        public static string ToLowerEx(this string value)
        {
            return value == null ? null : value.ToLower();
        }

        /// <summary>
		/// Determines if the string is made up of alpha numeric characters only (Spaces are allowed)
		/// </summary>
		/// <param name="s">The string to test for alpha numeric only characters</param>
		/// <returns></returns>
		public static bool IsAlphaNumeric(this string value)
        {
            if (string.IsNullOrEmpty(value)) return true;

            var r = new Regex("^(\\w| )+$");
            return r.IsMatch(value);
        }

        public static bool IsNumberCharsAt(this string value, int startIndex, int length)
        {
            int n;
            return value.LengthEx() > startIndex + length && int.TryParse(value, out n);
        }

        public static bool IsNumberCharAt(this string value, int index)
        {
            return value.LengthEx() > index && char.IsNumber(value[index]);
        }

        /// <summary>
		/// Determines if the string is made up of alpha numeric characters only (Spaces are allowed)
		/// </summary>
		/// <param name="s">The string to test for alpha numeric only characters</param>
		/// <returns></returns>
		public static bool IsValidFirstLastName(this string value)
        {
            if (string.IsNullOrEmpty(value)) return true;

            var r = new Regex("^(\\w|[- '\\(\\)])+$");
            return r.IsMatch(value);
        }

        /// <summary>
		/// Determines if the string is made up of ASCII only characters
		/// </summary>
		/// <param name="s">The string to test for ASCII only characters</param>
		/// <returns></returns>
		public static bool IsValidAscii(this string s)
        {
            for (var i = (s == null ? 0 : s.Length) - 1; i >= 0; i--)
            {
                var c = s[i];

                //(IS) have to consider \r and \n as they are part of the 'valid' input
                switch (c)
                {
                    case '\n':
                    case '\r':
                    case '\t':
                        continue;
                }

                var inValidRange = ((int)c).BetweenEx(32, 126);
                if (!inValidRange)
                    return false;
            }

            return true;
        }

        public static string Pascalize(this string input)
        {
            return Regex.Replace(input, "(?:^|_)(.)", match => match.Groups[1].Value.ToUpper());
        }

        /// <summary>
        /// Same as Pascalize except that the first character is lower case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Camelize(this string input)
        {
            var word = Pascalize(input);
            return word.Substring(0, 1).ToLower() + word.Substring(1);
        }
    }

    public static class IntEx
    {
        /// <summary>
        /// Determines if the Int input is between two values. 
        /// By default the lower and upper are NOT inclusive.
        /// An optional Inclusive bool is supplied if you would like the lower and upper bounds to be included in the test.
        /// </summary>
        public static bool Between(this int input, int lower, int upper, bool inclusive = false)
        {
            if (inclusive)
            {
                lower--;
                upper++;
            }
            return (input > lower && input < upper);
        }

        public static bool BetweenEx(this int value, int? lo, int? hi)
        {
            return (lo == null || value >= lo) && (hi == null || value <= hi);
        }

        public static int GetCurrentYear(this int currentYear, int year)
        {
            if (currentYear == 0)
                return DateTime.Now.Year + 1;
            return currentYear;
        }
    }

    public static class FuncEx
    {
        [DebuggerStepThrough]
        public static Func<TRes> Create<TRes>(Func<TRes> f) { return f; }
        [DebuggerStepThrough]
        public static Func<TArg1, TRes> Create<TArg1, TRes>(Func<TArg1, TRes> f) { return f; }
        [DebuggerStepThrough]
        public static Func<TArg1, TArg2, TRes> Create<TArg1, TArg2, TRes>(Func<TArg1, TArg2, TRes> f) { return f; }
        [DebuggerStepThrough]
        public static Func<TArg1, TArg2, TArg3, TRes> Create<TArg1, TArg2, TArg3, TRes>(Func<TArg1, TArg2, TArg3, TRes> f) { return f; }
        [DebuggerStepThrough]
        public static Func<TArg1, TArg2, TArg3, TArg4, TRes> Create<TArg1, TArg2, TArg3, TArg4, TRes>(Func<TArg1, TArg2, TArg3, TArg4, TRes> f) { return f; }
        [DebuggerStepThrough]
        public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TRes> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TRes>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TRes> f) { return f; }
        [DebuggerStepThrough]
        public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TRes> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TRes>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TRes> f) { return f; }
        [DebuggerStepThrough]
        public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TRes> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TRes>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TRes> f) { return f; }
        [DebuggerStepThrough]
        public static Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TRes> Create<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TRes>(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TRes> f) { return f; }

        [DebuggerStepThrough]
        public static TRes Invoke<TRes>(Func<TRes> f) { return f(); }
    }
}
