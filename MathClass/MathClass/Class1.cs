using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClass
{
    //Допоміжний клас для спрощення обрахунку
    public class NumberOrSymbol
    {
        public double Number { set; get; }
        public char Operation { set; get; }
        public void SetValue(double val)
        {

            Number = val;

        }

    }


    public class MathClassDll
    {
        // Метод який переводить символи в дабл приймає стрічку прикладу та позицію з якої потрібно считувати число
        public static double CharToDouble(string str, ref int i)
        {
            string number = "";

            while (char.IsDigit(str[i]) || str[i] == '.')
            {
                number += str[i].ToString();

                i++;

            }

            number = number.Replace('.', ',');




            return double.Parse(number);

        }


        //Метод який рахує результат прикладу приймає польський вираз 
        public static double Sum(double first, double second)
        {
            return first + second;
        }
        public static double Sub(double first, double second)
        {
            return first - second;
        }
        public static double Div(double first, double second)
        {
            return first / second;
        }
        public static double Mult(double first, double second)
        {
            return first * second;
        }



        public static double Calculation(string str)
        {

            List<NumberOrSymbol> nums = new List<NumberOrSymbol>();


            double num;
            for (int i = 0; i < str.Length;)
            {
                if (str[i] == '-' || str[i] == '*' || str[i] == '+' || str[i] == '/')
                {
                    nums.Add(new NumberOrSymbol { Operation = str[i] });
                    i++;
                }
                else
                {

                    if (char.IsDigit(str[i]))
                    {
                        num = CharToDouble(str, ref i);
                        nums.Add(new NumberOrSymbol { Number = num });

                    }
                    else { i++; };
                }
            }


            bool b = true;





            while (nums.Count != 1)
            {

                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i].Operation == '+' || nums[i].Operation == '-' || nums[i].Operation == '/' || nums[i].Operation == '*') Console.Write(nums[i].Operation);
                    else
                    {
                        Console.Write(nums[i].Number);
                    }
                }
                Console.WriteLine();





                for (int i = 0; i < nums.Count; i++)
                {


                    if (nums[i].Operation == '+')
                    {
                        nums[i - 2].SetValue(nums[i - 2].Number + nums[i - 1].Number);
                        b = false;


                    }
                    if (nums[i].Operation == '-')
                    {
                        nums[i - 2].SetValue(nums[i - 2].Number - nums[i - 1].Number);
                        b = false;



                    }
                    if (nums[i].Operation == '*')
                    {
                        nums[i - 2].SetValue(nums[i - 2].Number * nums[i - 1].Number);
                        b = false;


                    }
                    if (nums[i].Operation == '/')
                    {
                        nums[i - 2].SetValue(nums[i - 2].Number / nums[i - 1].Number);
                        b = false;


                    }
                    if (b == false)
                    {
                        b = true;
                        nums.Remove(nums[i]);
                        nums.Remove(nums[i - 1]);
                        break;
                    }
                }

            }

            return nums[0].Number;
        }



    }
}
