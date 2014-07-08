using System;

namespace Extensions.SafeMaybe
{

    public static class SafeMaybe
    {
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
        public static TResult SafeReturn<TInput, TResult>
            (this TInput o, Func<TInput, TResult> evaluator, TResult failureValue)
            where TInput : class
        {
            if (o == null)
                return failureValue;
            try
            {
                return evaluator(o);
            }
            catch (Exception)
            {
                return failureValue;
            }
        }

        /// <summary>
        /// Возвращает не равен ли входной параметр null.
        /// </summary>
        /// <typeparam name="TInput">Тип вхорного параметра.</typeparam>
        /// <param name="o">Входной параметр.</param>
        /// <returns></returns>
        public static bool SafeReturnSuccess<TInput>(this TInput o)
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
        public static TInput SafeIf<TInput>(this TInput o, Predicate<TInput> evaluator)
            where TInput : class
        {
            if (o == null)
                return null;

            try
            {
                return evaluator(o) ? o : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Выполняет действие.
        /// </summary>
        /// <typeparam name="TInput">Тип вхорного параметра.</typeparam>
        /// <param name="o">Входной параметр.</param>
        /// <param name="action">Операция, которую необходим выполнить.</param>
        /// <returns></returns>
        public static TInput SafeDo<TInput>(this TInput o, Action<TInput> action)
            where TInput : class
        {
            if (o == null) return null;

            try
            {
                action(o);
            }
            catch (Exception)
            {
                return null;
            }

            return o;
        }
    }
}
