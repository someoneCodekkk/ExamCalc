using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClass;

namespace AnalizerClass
{
    public class AnilizerClassDll
    {
        public static double RunCalculation(string str)
        {

           
            if (Validation(str) == true)
            {
                string polandstring = ToPolandString(str);
                return MathClassDll.Calculation(polandstring);
            }
            else
            {


                return 0;
            }
        }



        // Приймає стрічку прикладу яку потрібно перевірити на коректність
   public  static bool Validation(string str)
        {
            bool b = false;
            int v = 0, z = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (char.IsDigit(str[i])) b = true;
                if (i == str.Length - 1 && b == false) return b;
                if (!char.IsDigit(str[i]) && str[i] != ')' && str[i + 1] == '\0') return false;
                if (!char.IsDigit(str[i]) && str[i + 1] == '0' && !char.IsDigit(str[i])) return false;
                if ((str[i] == '+' || str[i] == '/' || str[i] == '*' || str[i] == '-' )&& (str[i+1] == '+' || str[i + 1] == '/' || str[i + 1] == '*' || str[i + 1] == '-')) return false;
                if (char.IsDigit(str[i]) && str[i + 1] == '(') return false;
                if (str[i] == ')' && char.IsDigit(str[i + 1])) return false;
                if (str[i] == '(') v++;
                if (str[i] == ')') z++;
                if (str[i] == '/' && str[i + 1] == '0') return false;
                if (str[i] == '.' && i == 0) return false;
                if (str[i] == '.')
                {
                    if (str[i] == '.' && char.IsDigit(str[i + 1]) != true || char.IsDigit(str[i - 1]) != true) return false;
                }
                if (str[i] != '(' && str[i] != ')' && !char.IsDigit(str[i]) && str[i] != '+' && str[i] != '/' && str[i] != '*' && str[i] != '-' && str[i] != '.') { return false; }
                if (z > v) return false;


            }


            if (v != z) return false;
            return true;
        }



        //Робить реверс стрічки викликається у методі ToPolandString
        public static string ReverceString(string input)
        {
            string output = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }

            return output;

        }

        //Приймає приклад у вигляді правльної стрічки стрічки перед цим меодом викликати метод Validation якщо результат true викликати цей метод
        public static string ToPolandString(string str)
        {
            Stack<char> operation = new Stack<char>();
            Stack<char> nums = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {

                if (char.IsDigit(str[i]) || str[i] == '.') nums.Push(str[i]);
                else
                {
                    nums.Push(' ');
                    if (str[i] == ')')
                    {

                        while (true)
                        {
                            if (operation.Peek() == '(') { operation.Pop(); break; }
                            else
                            {
                                nums.Push(operation.Pop());
                            }

                        }



                    }


                    else
                    {
                        if (str[i] == '(') operation.Push(str[i]);
                        else
                        {
                            if (operation.Count == 0) operation.Push(str[i]);
                            else
                            {
                                if ((operation.Peek() == '+' || operation.Peek() == '-') && (str[i] == '*' || str[i] == '/')) operation.Push(str[i]);
                                else
                                {
                                    if (operation.Peek() == '(') operation.Push(str[i]);
                                    else
                                    {

                                        if ((operation.Peek() == '*' || operation.Peek() == '/') && (str[i] == '*' || str[i] == '/')) nums.Push(operation.Pop());

                                        else
                                        {
                                            while (true)
                                            {
                                                if (operation.Count == 0) break;
                                                else
                                                {
                                                    if (operation.Peek() == '(') break;
                                                    else
                                                    {
                                                        nums.Push(operation.Pop());
                                                    }
                                                }



                                            }
                                        }


                                        operation.Push(str[i]);
                                    }



                                }










                            }
                        }



                    }
                }
            }


            while (operation.Count != 0)
            {

                nums.Push(operation.Pop());
            }
            string PolandString = "";


            while (nums.Count != 0)
            {
                PolandString += nums.Pop().ToString();

            }





            return ReverceString(PolandString);



        }







    }
}
