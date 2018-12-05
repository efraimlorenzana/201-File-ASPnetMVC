using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace hr_201_file.Custom_Function
{
    public static class CF
    {
        public static string Alert(string Message)
        {
            return "<script>" +
                    "alert(" + Message + ")" +
                   "</script>";
        }

        public static void CopyProperties<T>(this T fromObj, T toObj)
        {
            foreach (var p in typeof(T).GetProperties())
            {
                if (null != p.GetValue(fromObj, null))
                {
                    p.SetValue(toObj, p.GetValue(fromObj));
                }
            }
        }

        public static void Copy<T>(T from, T to)
        {
            Type t = typeof(T);
            PropertyInfo[] props = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in props)
            {
                if (!p.CanRead || !p.CanWrite) continue;

                object val = p.GetGetMethod().Invoke(from, null);
                object defaultVal = p.PropertyType.IsValueType ? Activator.CreateInstance(p.PropertyType) : null;
                if (null != defaultVal && !val.Equals(defaultVal))
                {
                    p.GetSetMethod().Invoke(to, new[] { val });
                }
            }
        }
    }
}