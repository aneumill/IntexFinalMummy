using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexFinalMummy.Models.Filters
{
    public class SearchLogic
    {
        private IntexMummyVaultContext _context { get; set; }

        public SearchLogic(IntexMummyVaultContext con)
        {
            _context = con;
        }

        public IQueryable<MummyInfo> GetRecords(SearchModel searchModel)
            {
            //The search Filters....
                var result = _context.MummyInfos.AsQueryable();
                if (searchModel != null)
                {
                 
                    //Filters for Gender
                    if (!string.IsNullOrEmpty(searchModel.Gender))
                    {
                        result = result.Where(x => x.Sex.Contains(searchModel.Gender));
                    }
                    //Filters for Head Direction
                    if (!string.IsNullOrEmpty(searchModel.HeadDirection))
                    {
                        result = result.Where(x => x.HeadDirection.Contains(searchModel.HeadDirection));
                    }
                    //Filters for MinAge
                     if (searchModel.MinAge.HasValue)
                    {
                        result = result.Where(x => x.MinAge >= searchModel.MinAge);
                    }
                    //Filters for Max Age
                    if (searchModel.MaxAge.HasValue)
                    {
                        result = result.Where(x => x.MaxAge <= searchModel.MaxAge);
                    }
                    //Year Discovered 
                    if (searchModel.YearDiscovered.HasValue)
                    {
                        result = result.Where(x => x.YearDiscovered <= searchModel.YearDiscovered);
                    }
                    //Burial Depth
                    if (searchModel.BurialDepth.HasValue)
                    {
                        result = result.Where(x => x.BurialDepth <= searchModel.BurialDepth);
                    }
                    //Filters for has artifacts
                    if (searchModel.Artifacts.HasValue)
                    {
                        result = result.Where(x => x.Artifacts == searchModel.Artifacts);
                    }









            }



            return result;
            }
        }
    }
