using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensions.Extens
{
    public static class Extens
    {
        /// <summary>
        /// Добавляет форматированую строчку в построитель строк.
        /// </summary>
        /// <param name="sb">Построитель строк.</param>
        /// <param name="format">Формат, который необходимо добавить.</param>
        /// <param name="args">Аргументы форматированой строчки.</param>
        /// <returns></returns>
        public static StringBuilder AppendFormatLine(this StringBuilder sb,
            string format, params object[] args)
        {
            return sb.AppendFormat(format, args).AppendLine();
        }

        /// <summary>
        /// Добавляет перечень объектов в список.
        /// </summary>
        /// <typeparam name="T">Тип типизированого списка.</typeparam>
        /// <param name="list">Список.</param>
        /// <param name="objects">Объекты, которые необходимо добавить.</param>
        /// <returns></returns>
        public static IList<T> AddRange<T>(this IList<T> list, params T[] objects)
        {
            foreach (var o in objects)
                list.Add(o);
            return list;
        }

        /// <summary>
        /// Добавляет перечисляемое множество в список.
        /// </summary>
        /// <typeparam name="T">Тип типизированого списка.</typeparam>
        /// <param name="list">Список.</param>
        /// <param name="other">Перечисляемое множество.</param>
        /// <returns></returns>
        public static IList<T> AddRange<T>(this IList<T> list, IEnumerable<T> other)
        {
            foreach (var o in other)
                list.Add(o);
            return list;
        }

        /// <summary>
        /// Преобразует последовательность байт в НЕХ-строку.
        /// </summary>
        /// <param name="data">Последовательность байт.</param>
        /// <returns></returns>
        public static string ToHexString(this IList<byte> data)
        {
            var sb = new StringBuilder();
            foreach (var b in data)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        /// <summary>
        /// Преобразует НЕХ-последовательность в массив байт.
        /// </summary>
        /// <param name="hexString">НЕХ-строка.</param>
        /// <returns></returns>
        public static byte[] FromHexString(this string hexString)
        {
            var data = new byte[hexString.Length / 2];
            for (var i = 0; i < data.Length; i++)
                data[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return data;
        }

        /// <summary>
        /// Проверяет на равенство два набора байт с указаных символов.
        /// </summary>
        /// <param name="data1">Первый набор байт.</param>
        /// <param name="data2">Второй набор байт.</param>
        /// <param name="index1">Индекс, с которого начинается отсчет в первом наборе.</param>
        /// <param name="index2">Индекс, с которого начинается отсчет во втором наборе.</param>
        /// <returns></returns>
        public static bool SequenceEquals(this IList<byte> data1, IList<byte> data2, int index1, int index2)
        {
            if (data1 == null || data2 == null)
                return false;

            for (int i = index1, j = index2; i < data1.Count() && j < data2.Count(); i++, j++)
                if (data1[i] != data2[j])
                    return false;
            return true;
        }

        /// <summary>
        /// Удаляет символы, запрещенные в пути.
        /// </summary>
        /// <param name="s">Входная строка.</param>
        /// <returns></returns>
        public static string ClearPath(this string s)
        {
            return new[] { "\\", "//", ":", "*", "?", "\"", ">", "<", "|" }
                .Aggregate(s, (current, ss) => current.Replace(ss, ""));
        }
    }
}
