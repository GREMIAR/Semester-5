﻿using System;
using System.Linq;

namespace Lab4
{
#pragma warning disable CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
#pragma warning disable CS0661 // Тип определяет оператор == или оператор !=, но не переопределяет Object.GetHashCode()
    class Code
    {
        public string str { get; private set; }
        public int[] code { get; private set; }
        bool digit;

        public static bool operator <=(Code a, Code b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.code[0] <= b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (b.digit)
                {
                    return false;
                }
                else
                {
                    int length;
                    if (a.code.Length <= b.code.Length)
                    {
                        length = a.code.Length;
                    }
                    else
                    {
                        length = b.code.Length;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (a.code[i] > b.code[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }
        public static bool operator >=(Code a, Code b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.code[0] >= b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (b.digit)
                {
                    return true;
                }
                else
                {
                    int length;
                    if (a.code.Length <= b.code.Length)
                    {
                        length = a.code.Length;
                    }
                    else
                    {
                        length = b.code.Length;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (a.code[i] < b.code[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }
        public static bool operator <(Code a, Code b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.code[0] < b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (b.digit)
                {
                    return false;
                }
                else
                {
                    int length;
                    if (a.code.Length <= b.code.Length)
                    {
                        length = a.code.Length;
                    }
                    else
                    {
                        length = b.code.Length;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (a.code[i] >= b.code[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }
        public static bool operator >(Code a, Code b)
        {
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.code[0] > b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (b.digit)
                {
                    return true;
                }
                else
                {
                    int length;
                    if (a.code.Length <= b.code.Length)
                    {
                        length = a.code.Length;
                    }
                    else
                    {
                        length = b.code.Length;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (a.code[i] <= b.code[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }
        public static bool operator ==(Code a, Code b)
        {
            if ((Object)a == null && (Object)b == null)
            {
                return true;
            }
            else if ((Object)a == null || (Object)b == null)
            {
                return false;
            }
            else if (a.digit)
            {
                if (b.digit)
                {
                    if (a.code[0] == b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (b.digit)
                {
                    return false;
                }
                else
                {
                    int length;
                    if (a.code.Length != b.code.Length)
                    {
                        return false;
                    }
                    else
                    {
                        length = a.code.Length;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (a.code[i] != b.code[i])
                        {
                            return false;
                        }
                    }
                    if (a.code.Length == b.code.Length)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public static bool operator !=(Code a, Code b)
        {
            if ((Object)a != null && (Object)b == null || (Object)a == null && (Object)b != null)
            {
                return true;
            }
            else if ((Object)a == null && (Object)b == null)
            {
                return false;
            }
            if (a.digit)
            {
                if (b.digit)
                {
                    if (a.code[0] != b.code[0])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (b.digit)
                {
                    return true;
                }
                else
                {
                    int length;
                    if (a.code.Length <= b.code.Length)
                    {
                        length = a.code.Length;
                    }
                    else
                    {
                        length = b.code.Length;
                    }
                    for (int i = 0; i < length; i++)
                    {
                        if (a.code[i] != b.code[i])
                        {
                            return true;
                        }
                    }
                    if (a.code.Length != b.code.Length)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public Code(string str)
        {
            this.str = str;
            digit = Int32.TryParse(str, out int code);
            if (digit)
            {
                this.code = new int[] { code };
            }
            else
            {
                this.code = str.ToCharArray().Select(x => (int)x).ToArray();
            }
        }
    }
}