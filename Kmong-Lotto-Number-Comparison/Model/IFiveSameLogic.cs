using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kmong_Lotto_Number_Comparison.Model
{
    static class combiGenerator
    {
        public static IEnumerable<(IList<byte>, byte)> Gen(List<byte> numberList)
        {
            for(int i=0; i<numberList.Count; i++)
            {
                List<byte> result= new List<byte>();
                for (int j=0; j<numberList.Count; j++)
                {
                    if (i != j) result.Add(numberList[j]);
                }
                yield return (result, numberList[i]);
            }
        }
    }


    public abstract class IFiveSameLogic 
    {
        public void doCalc(List<List<byte>> numberList)
        {
            StreamWriter[] sw =
            {   new  StreamWriter($"./result-2.txt", true ),
                new  StreamWriter($"./result-3.txt", true ),
                new  StreamWriter($"./result-4.txt", true ),
                new  StreamWriter($"./result-5.txt", true ),
                new  StreamWriter($"./result-6.txt", true ),
                new  StreamWriter($"./result-7.txt", true ),
                new  StreamWriter($"./result-100.txt", true ),
            };
            for (int i=0; i<numberList.Count; i++)
            {
                var list = numberList[i];
                foreach (var key in combiGenerator.Gen(list))
                {
                    int count = 0;
                    IList<byte> shouldBeInList = key.Item1;
                    byte donotSame = key.Item2;

                    for (int j = i + 1; j < numberList.Count; j++)
                    {
                        var compareList = numberList[j];
                        bool[] isThere = new bool[100];

                        foreach (var k in compareList) isThere[k] = true;

                        // should be same all
                        bool same = true;
                        foreach (var k in shouldBeInList)
                        {
                            same &= isThere[k];
                            if (!same) break;
                        }
                        if (!same) continue;

                        // last one should be diff
                        same &= !isThere[donotSame];

                        if (same)
                        {
                            count++;
                        }
                    }


                    if ( count == 2 || count == 3 || count == 4|| count == 5 || count == 6 || count == 7 || count >= 100) 
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach(var k in shouldBeInList )
                        {
                            sb.Append(k);
                            sb.Append(" ");
                        }
                        sb.Remove(sb.Length - 1, 1);
                        if (count <= 7) sw[count - 2].WriteLineAsync(sb.ToString());
                        else if (count >= 100)
                        {
                            count = 100;
                            sw[6].WriteLineAsync(sb.ToString());
                            //{
                            //    using (StreamWriter sww = new StreamWriter($"./result-{count}.txt", true))
                            //    {
                            //        sww.WriteLineAsync(sb.ToString());
                            //    }
                            //}
                        }
                    }
                }
            }
            foreach (var s in sw) s.Close();
        }
    }

    public class samethree : IFiveSameLogic
    {
        public void doCalc(List<List<byte>> numberList)
        {
            base.doCalc(numberList);
        }
    }

    public class sameFour : IFiveSameLogic
    {
        public void doCalc(List<List<byte>> numberList)
        {
            base.doCalc(numberList);
        }
    }

    public class sameFive : IFiveSameLogic
    {
        public void doCalc(List<List<byte>> numberList)
        {
            base.doCalc(numberList);
            throw new System.NotImplementedException();
        }
    }

    public class sameSix : IFiveSameLogic
    {
        public void doCalc(List<List<byte>> numberList)
        {
            base.doCalc(numberList);
        }
    }

    public class sameSeven : IFiveSameLogic
    {
        public void doCalc(List<List<byte>> numberList)
        {
            base.doCalc(numberList);
        }
    }

    public class sameHundred : IFiveSameLogic
    {
        public void doCalc(List<List<byte>> numberList)
        {
            base.doCalc(numberList);
        }
    }
}
