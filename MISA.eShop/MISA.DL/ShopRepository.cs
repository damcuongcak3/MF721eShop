using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.DL
{
    public class ShopRepository: DbContext
    {
        /// <summary>
        /// Kiếm tra mã cửa hàng tồn tại hay chưa
        /// </summary>
        /// <param name="shopCode">Mã cửa hàng cần kiểm tra</param>
        /// <returns>true: đã tồn tại. false: chưa có</returns>
        /// CreatedBy DvCuong (20/02/2021)
        public bool CheckShopCodeExits(string shopCode, Guid shopId)
        {
            var sql = $"Select ShopCode from Shop As S where S.ShopCode = '{shopCode}' and S.ShopId <>  '{shopId}'";
            var shopCodeExits = _dbConnection.Query<string>(sql).FirstOrDefault();
            if (shopCodeExits != null)
                return true;
            else return false;
        }
    }
}
