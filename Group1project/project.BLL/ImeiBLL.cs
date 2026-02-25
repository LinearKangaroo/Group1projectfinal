using Group1project.Model;
using Group1project.project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Group1project.project.BLL
{
    public class ImeiBLL
    {
        private readonly ImeiDAL _imeiDal = new ImeiDAL();

        public List<imeiModel> GetAllImei() => _imeiDal.GetAllImeiWithProduct();

        public List<ProductModel> GetSkuOptions() => _imeiDal.GetSkuOptions();

        public List<imeiModel> SearchByImei(List<imeiModel> source, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return source;
            }

            string normalized = keyword.Trim();
            return source
                .Where(x => !string.IsNullOrWhiteSpace(x.imei)
                         && x.imei.Contains(normalized, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public int AddImei(imeiModel model)
        {
            model.status = NormalizeStatus(model.status);
            return _imeiDal.AddImei(model);
        }

        public bool ExistsImei(string imei)
        {
            if (string.IsNullOrWhiteSpace(imei))
            {
                return false;
            }

            return _imeiDal.ExistsImei(imei.Trim());
        }

        public int UpdateImei(imeiModel model, string originalImei)
        {
            model.status = NormalizeStatus(model.status);
            return _imeiDal.UpdateImei(model, originalImei);
        }

        public int CountSold(List<imeiModel> source) => source.Count(x => string.Equals(x.status, "sold", StringComparison.OrdinalIgnoreCase));

        public int CountInStock(List<imeiModel> source) => source.Count(x => string.Equals(x.status, "instock", StringComparison.OrdinalIgnoreCase));

        public (int insertedCount, int duplicateCount) Import(string filePath) => _imeiDal.ImportImei(filePath);

        public void Export(string filePath) => _imeiDal.ExportImei(filePath);

        private static string NormalizeStatus(string? status)
        {
            return string.Equals(status?.Trim(), "sold", StringComparison.OrdinalIgnoreCase) ? "sold" : "instock";
        }
    }
}
