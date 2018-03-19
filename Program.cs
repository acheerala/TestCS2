using System;
using System.Collections.Generic;

namespace TestCS
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string str1 = "name { fdf [ dfd ( fdf ) fdfd ] dfdf}";   // Valid
            string str2 = "{xyz}";                // Valid
            string str3 = "abc [ fdfd ] fdfd ( fdfd )  dfdf {}";     // Valid


            string str4 = "name { fdfd [fdfd }";                     // Invalid
            string str5 = "xyc { [ ( fdf";                           // Invalid
            string str6 = "xyc { [ ( fdf  { ) ]"; //invalid
            string str7 = "xyc { [] ( fdf  ) }"; //valid

            bool notMatched = ProcessString(str1);
            Console.WriteLine($"{str1} - Matched {!notMatched}");
            notMatched = ProcessString(str2);
            Console.WriteLine($"{str2} - Matched {!notMatched}");
            notMatched = ProcessString(str3);
            Console.WriteLine($"{str3} - Matched {!notMatched}");
            notMatched = ProcessString(str4);
            Console.WriteLine($"{str4} - Matched {!notMatched}");
            notMatched = ProcessString(str5);
            Console.WriteLine($"{str5} - Matched {!notMatched}");
            notMatched = ProcessString(str6);
            Console.WriteLine($"{str6} - Matched {!notMatched}");
            notMatched = ProcessString(str7);
            Console.WriteLine($"{str7} - Matched {!notMatched}");
        }
         
        private static bool ProcessString(string s)
        {
            Stack<char> stack = new Stack<char>();
            var ch = s.ToCharArray();
            var len = s.Length;
            char specialChar = default(char);
            bool notMatched = false;
           
            for(var i = 0; i < len; i++)
            {
                if(ch[i] == '{' || ch[i] == '[' || ch[i] == '(')
                {
                    stack.Push(ch[i]);
                }
                else 
                {
                    switch (ch[i])
                    {
                        case '}':
                            specialChar = stack.Pop();
                            if (specialChar != '{')
                                notMatched = true;
                            break;
                        case ')':
                            specialChar = stack.Pop();
                            if (specialChar != '(')
                                notMatched = true;
                            break;
                        case ']':
                            specialChar = stack.Pop();
                            if (specialChar != '[')
                                notMatched = true;
                            break;
                        default:
                            if(i==len-1 && stack.Count > 0)
                                notMatched = true;
                            break;

                    }
                }
                if (notMatched) break;            
            }
            return notMatched;
        }
    }
}
