using Group1project.Model;
using Group1project.project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Group1project.project.BLL
{
    public class AnalysisBLL
    {
        private readonly AnalysisDAL _analysisDal = new AnalysisDAL();

        public List<string> GetBrands()
        {
            return _analysisDal.GetBrands();
        }

        public List<AnalysisRowModel> GetAnalysisRows(DateTime startDate, DateTime endDate, AnalysisViewType viewType, List<string> brands, AnalysisSortType sortType, bool ascending)
        {
            List<AnalysisRowModel> rows = _analysisDal.GetAnalysisRows(startDate, endDate, viewType, brands);

            Func<AnalysisRowModel, object> sortSelector = sortType switch
            {
                AnalysisSortType.Stock => x => x.Stock,
                AnalysisSortType.DOS => x => x.DOS,
                AnalysisSortType.DemandStock => x => x.DemandStock,
                _ => x => x.Sellout
            };

            rows = ascending
                ? rows.OrderBy(sortSelector).ThenBy(x => x.Name).ToList()
                : rows.OrderByDescending(sortSelector).ThenBy(x => x.Name).ToList();

            return rows;
        }

        public List<SalesTrendPointModel> GetTrendData(TrendRange range, List<string> brands)
        {
            return _analysisDal.GetTrendData(range, brands);
        }
    }
}
