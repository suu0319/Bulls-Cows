using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAXB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Part1:產生不重複的四位數字
            int a, b, t;
            a = 0; b = 0; t = 0;
            int[] ans = new int[4];
            Random r = new Random();
            ans[0] = r.Next(1, 10);
            //Console.Write(ans[0]);
            for (int i = 1; i < 4; i++)
            {
                do
                {
                    ans[i] = r.Next(0, 10);
                }
                while (ans[i] == ans[i - 1] || ans[2] == ans[0] || ans[3] == ans[0] || ans[3] == ans[1]);
                //Console.Write(ans[i]);
            }
            Console.WriteLine();
            //Part1 end

            //Par2:猜數字
            Console.WriteLine("===================XAXB===================");
            Console.WriteLine();
            while (a != 4)
            {
                //A,B歸0
                a = 0; b = 0;
                Console.Write("猜猜一個四位數字(首位不能為0且數字不得重複):");
                //輸入的數字(string)
                string x = Console.ReadLine();
                Console.WriteLine();

                if (x.Length == 4)
                {
                    //string轉char陣列
                    char[] arr = x.ToCharArray(0, 4);
                    //char陣列轉int陣列
                    int[] Aint = Array.ConvertAll(arr, c => (int)Char.GetNumericValue(c));
                    //四位數字是否符合規則
                    bool ok = true;
                    if (Aint[0] == 0)
                    {
                        Console.WriteLine("Error:首位不得為0");
                        Console.WriteLine();
                        ok = false;
                    }
                    if (Aint[0] == -1 || Aint[1] == -1 || Aint[2] == -1 || Aint[3] == -1)
                    {
                        Console.WriteLine("Error:四位數不得有特殊符號、英文、中文");
                        Console.WriteLine();
                        ok = false;
                    }
                    else if (Aint[0] == Aint[1] || Aint[0] == Aint[2] || Aint[0] == Aint[3] || Aint[1] == Aint[2] || Aint[1] == Aint[3] || Aint[2] == Aint[3])
                    {
                        Console.WriteLine("Error:數字不得重複");
                        Console.WriteLine();
                        ok = false;
                    }
                    if (ok == true)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (Aint[i] == ans[i])
                            {
                                a++;
                            }
                            for (int j = 0; j < 4; j++)
                            {
                                if (Aint[i] == ans[j])
                                {
                                    b++;
                                }
                            }
                        }
                        t++;
                        Console.Write("{0}A", a);
                        Console.WriteLine("{0}B", b - a);
                        Console.WriteLine();
                    }
                }
                else if (x.Length != 4)
                {
                    Console.WriteLine("Error:請輸入四位數字");
                    Console.WriteLine();
                }
                //Part2 end;
            }
            Console.WriteLine("恭喜你答對!你總共嘗試{0}次", t);
            Console.Read();
        }
    }
}