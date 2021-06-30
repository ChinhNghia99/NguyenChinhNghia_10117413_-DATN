using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class HoaDonBusiness : IHoaDonBusiness
    {
        private IHoaDonRepository _res;
        private IProductBusiness _rsp;

        public HoaDonBusiness(IHoaDonRepository res, IProductBusiness rsp)
        {
            _res = res;
            _rsp = rsp;
        }

        public bool Create(HoaDonModel model)
        {
            return _res.Create(model);
        }

        public HoaDonModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public HoaDonModel GetChiTietByHoaDon(string id)
        {
            var kq = _res.GetDatabyID(id);

            kq.listjson_chitiet = _res.GetChitietbyhoadon(id);
            foreach (var item in kq.listjson_chitiet)
            {
                item.product_name = _rsp.GetDatabyID(item.product_id).product_name;
                item.product_price = _rsp.GetDatabyID(item.product_id).product_price;
            }

            return kq;
        }



        public List<HoaDonModel> GetDataAll()
        {
            return _res.GetDataAll();
        }

        public List<HoaDonModel> Search(int pageIndex, int pageSize, out long total, string ho_ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ho_ten);

        }




    }
}
