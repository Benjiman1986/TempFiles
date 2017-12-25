using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryManager
{
    class Program
    {
        //两家供货商的话，必须有至少一家的库存少于总需求量的1/2，排序，从最接近的
        //三家供货商的话，必须有至少一家的库存少于总需求量的1/3
        //以此类推
        static void Main(string[] args)
        {
            var res = InitRepository();
            var sortedRes = res.OrderBy(x => x.TotalCount).ToList();
            decimal required = 72050;
            var halfReq = required / 2;

            var nearestIndex = NearestIndex(sortedRes, halfReq);
            Console.WriteLine(nearestIndex);

            //2
            string pareIndexes = string.Empty;
            decimal currentAbs = 0;
            for (int i = 0; i < nearestIndex; i++)
            {

                for (int j = nearestIndex; j < sortedRes.Count; j++)
                {
                    var jSupply = sortedRes[j].TotalCount > halfReq ? halfReq : sortedRes[j].TotalCount;
                    if (string.IsNullOrEmpty(pareIndexes))
                    {
                        pareIndexes = i + "_" + j;
                        currentAbs = Math.Abs(sortedRes[i].TotalCount + jSupply - required);
                    }
                    else
                    {
                        var abs = Math.Abs(sortedRes[i].TotalCount + jSupply - required);
                        if (abs < currentAbs)
                        {
                            pareIndexes = i + "_" + j;
                            currentAbs = abs;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(pareIndexes);
            Console.WriteLine(currentAbs);

            var splited = pareIndexes.Split('_');
            foreach (var s in splited)
            {
                foreach (var rr in sortedRes[int.Parse(s)].MergeRepository)
                {
                    Console.WriteLine(rr.Name + "_" + rr.Stock);
                }
                Console.WriteLine(sortedRes[int.Parse(s)].TotalCount);
            }

            Console.Read();
        }

        static int NearestIndex(List<Repository> res, decimal halfRequired)
        {
            //var min = res.Select(x => Math.Abs(x.TotalCount - halfRequired)).Min(x => x);
            int index = 0;
            decimal currentAbs = 0;

            for(int i=0; i < res.Count; i++){
                var abs = Math.Abs(res[i].TotalCount - halfRequired);
                if(i == 0){
                    currentAbs = abs;
                }else{
                    if (abs < currentAbs)
                    {
                        currentAbs = abs;
                        index = i;
                    }
                }
            }

            //if (res[index].TotalCount < halfRequired)
            //{
            //    index++;
            //}

            return index;
        }
        

        private static List<Repository> InitRepository()
        {
            var result = new List<Repository>();
            result.Add(new Repository {
                MergeRepository = new List<SingleRepository> { new SingleRepository{Name="大连A", Stock=39030.4M}, new SingleRepository{Name="大连B", Stock=6505.1M}
            }});
            result.Add(new Repository {
                MergeRepository = new List<SingleRepository> { new SingleRepository{Name="青岛", Stock=14311.1M}
            }});
            result.Add(new Repository {
                MergeRepository = new List<SingleRepository> { new SingleRepository{Name="济南", Stock=13010.1M}
            }});
            result.Add(new Repository {
                MergeRepository = new List<SingleRepository> { new SingleRepository{Name="厦门", Stock=9323.9M}
            }});
            result.Add(new Repository {
                MergeRepository = new List<SingleRepository> { new SingleRepository{Name="福州", Stock=26020.3M}
            }});
            result.Add(new Repository {
                MergeRepository = new List<SingleRepository> { new SingleRepository{Name="广州", Stock=27312.3M}
            }});
            result.Add(new Repository {
                MergeRepository = new List<SingleRepository> { new SingleRepository{Name="深圳", Stock=11383.9M}
            }});
            result.Add(new Repository {
                MergeRepository = new List<SingleRepository> { new SingleRepository{Name="成都", Stock=21683.5M}
            }});
            result.Add(new Repository {
                MergeRepository = new List<SingleRepository> { new SingleRepository{Name="重庆A", Stock=6505.1M}, new SingleRepository{Name="重庆B", Stock=6505.1M}
            }});
            return result;
        }
    }
}
