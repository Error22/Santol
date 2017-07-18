﻿using System.Collections.Generic;
using Santol.IR;

namespace Santol
{
    public static class Extensions
    {
        public static void AddOpt<T>(this IList<T> list, T value)
        {
            if (!list.Contains(value))
                list.Add(value);
        }

        public static void AddOpt<T>(this IList<T> list, T[] values)
        {
            foreach (T value in values)
                list.AddOpt(value);
        }

        public static bool SignatureMatches(this IMethod method, IMethod otherMethod)
        {
            if (!method.ReturnType.Equals(otherMethod.ReturnType))
                return false;
            if (method.Arguments.Length != otherMethod.Arguments.Length)
                return false;
            for (int i = 0; i < method.Arguments.Length; i++)
                if (!method.Arguments[i].Equals(otherMethod.Arguments[i]))
                    return false;
            return true;
        }
    }
}