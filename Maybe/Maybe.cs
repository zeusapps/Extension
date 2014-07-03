using System;

namespace Extensions.Maybe
{

    public static class Maybe
    {
        /// <summary>
        /// Возвращает результат выполнения операции.
        /// </summary>
        /// <typeparam name="TInput">Тип вхорного параметра.</typeparam>
        /// <typeparam name="TResult">Тип результата выполнения операции.</typeparam>
        /// <param name="o">Входной параметр.</param>
        /// <param name="evaluator">Опереация преобразования входного параметра в результат.</param>
        /// <returns></returns>
        public static TResult With<TInput, TResult>
            (this TInput o, Func<TInput, TResult> evaluator)
            where TInput : class
            where TResult : class
        {
            return o == null ? null : evaluator(o);
        }

        /// <summary>
        /// Возвращает результат выполнения операции, в случае ошибки возвращает null.
        /// </summary>
        /// <typeparam name="TInput">Тип вхорного параметра.</typeparam>
        /// <typeparam name="TResult">Тип результата выполнения операции.</typeparam>
        /// <param name="o">Входной параметр.</param>
        /// <param name="evaluator">Опереация преобразования входного параметра в результат.</param>
        /// <returns></returns>
        public static TResult SafeWith<TInput, TResult>
            (this TInput o, Func<TInput, TResult> evaluator)
            where TInput : class
            where TResult : class
        {
            if (o == null)
                return null;
            try
            {
                return evaluator(o);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Возвращает результат выполнения операции.
        /// </summary>
        /// <typeparam name="TInput">Тип вхорного параметра.</typeparam>
        /// <typeparam name="TResult">Тип результата выполнения операции.</typeparam>
        /// <param name="o">Входной параметр.</param>
        /// <param name="evaluator">Опереация преобразования входного параметра в результат.</param>
        /// <param name="failureValue">Значение которое будет возвращено по умолчанию.</param>
        /// <returns></returns>
        public static TResult Return<TInput, TResult>
            (this TInput o, Func<TInput, TResult> evaluator, TResult failureValue)
            where TInput : class
        {
            return o == null ? failureValue : evaluator(o);
        }

        /// <summary>
        /// Возвращает не равен ли входной параметр null.
        /// </summary>
        /// <typeparam name="TInput">Тип вхорного параметра.</typeparam>
        /// <param name="o">Входной параметр.</param>
        /// <returns></returns>
        public static bool ReturnSuccess<TInput>(this TInput o)
            where TInput : class
        {
            return o != null;
        }

        /// <summary>
        /// Проверяет выполняется ли условие.
        /// </summary>
        /// <typeparam name="TInput">Тип вхорного параметра.</typeparam>
        /// <param name="o">Входной параметр.</param>
        /// <param name="evaluator">Опереация преобразования входного параметра в результат.</param>
        /// <returns></returns>
        public static TInput If<TInput>(this TInput o, Predicate<TInput> evaluator)
            where TInput : class
        {
            if (o == null)
                return null;

            return evaluator(o) ? o : null;
        }

        /// <summary>
        /// Выполняет действие.
        /// </summary>
        /// <typeparam name="TInput">Тип вхорного параметра.</typeparam>
        /// <param name="o">Входной параметр.</param>
        /// <param name="action">Операция, которую необходим выполнить.</param>
        /// <returns></returns>
        public static TInput Do<TInput>(this TInput o, Action<TInput> action)
            where TInput : class
        {
            if (o == null) return null;
            action(o);
            return o;
        }
    }
}
