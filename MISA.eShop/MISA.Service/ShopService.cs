using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Model;
using MISA.DL;

namespace MISA.Service
{
    public class ShopService
    {


        /// <summary>
        /// Lấy danh sách cửa hàng
        /// </summary>
        /// <param name="shopId">Id cửa hàng cần lấy dữ, nếu shopId trống hoặc bằng null thì lấy tất cả dữ liệu</param>
        /// <returns>Trả về trạng thái Service</returns>
        /// CreatedBy DvCuong (23/02/2021)
        public ServiceResult GetShops(Guid? shopId=null)
        {
            var newID = new Guid();
            var serviceResult = new ServiceResult();
            var dbContext = new ShopRepository();
            serviceResult.Success = true;
            if (shopId == null || shopId == newID)
            {
                serviceResult.Data = dbContext.GetData<Shop>();
                //    //serviceResult.Data = dbContext.GetData<Shop>($"Proc_GetShopByParameter", new { ShopCodeContains = "ZCTX444" });
                

            }
            else
            {
                
                serviceResult.Data = dbContext.GetData<Shop>($"Proc_GetShopById", new { ShopId = shopId });
                //serviceResult.Data = dbContext.GetData<Shop>($"Proc_GetShopByParameter", new { ShopCodeContains = "ZCTX444" });
            }

            return serviceResult;
        }
        /// <summary>
        /// Hàm thêm mới shop, xử lý nghiệp vụ trước khi thêm
        /// </summary>
        /// <param name="shop">shop cần thêm mới</param>
        /// <returns>Success = true thì trả về số lượng bản ghi được thêm mới</returns>
        public ServiceResult InsertShop(Shop shop)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();
            var dbContext = new ShopRepository();

            //1.Validate bắt buộc nhập
            //Mã cửa hàng bắt buộc nhập
            if (shop.ShopCode == null || shop.ShopCode == string.Empty)
            {
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_Required_ShopCode;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            //Tên cửa hàng bắt buộc nhập
            if (shop.ShopName == null || shop.ShopName == string.Empty)
            {
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_Required_ShopName;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            //Địa chỉ cửa hàng bắt buộc nhập
            if (shop.Address == null || shop.Address == string.Empty)
            {
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_Required_Address;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            //2.Validate dữ liệu không được phép trùng
            //ShopCode không được phép trùng

            var isExits = dbContext.CheckShopCodeExits(shop.ShopCode, shop.ShopId);
            if (isExits == true)
            {
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_Duplicates_ShopCode;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            //Validate dữ liệu thành công thì thực hiện thêm mới:
            var res = dbContext.InsertObject(shop);
            if (res > 0)
            {
                serviceResult.Success = true;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Success;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            else
            {
                serviceResult.Success = false;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_Insert;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }

        /// <summary>
        /// Hàm sửa thông tin shop, xử lý nghiệp vụ trước khi sửa thành công!
        /// </summary>
        /// <param name="shop">đối tượng shop cần chỉnh sửa</param>
        /// <returns>Succes = true thì sửa thành công!</returns>
        public ServiceResult UpdateShop(Shop shop)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();
            var dbContext = new ShopRepository();

            //1.Validate bắt buộc nhập
            //Mã cửa hàng bắt buộc nhập
            if (shop.ShopCode == null || shop.ShopCode == string.Empty)
            {
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_Required_ShopCode;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            //Tên cửa hàng bắt buộc nhập
            if (shop.ShopName == null || shop.ShopName == string.Empty)
            {
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_Required_ShopName;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            //Địa chỉ cửa hàng bắt buộc nhập
            if (shop.Address == null || shop.Address == string.Empty)
            {
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_Required_Address;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            //2.Validate dữ liệu không được phép trùng
            //ShopCode đã tồn tại

            var isExits = dbContext.CheckShopCodeExits(shop.ShopCode,shop.ShopId);
            if (isExits == true)
            {
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_Duplicates_ShopCode;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            //Validate dữ liệu thành công thì thực hiện thêm mới:
            var res = dbContext.UpdateObject(shop);
            if (res > 0)
            {
                serviceResult.Success = true;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Success;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            else
            {
                serviceResult.Success = false;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_Insert;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }
        public ServiceResult DeleteShop(Guid ShopId)
        {
            try
            {
                var serviceResult = new ServiceResult();
                var dbContext = new DbContext();
                serviceResult.Success = true;
                serviceResult.Data = dbContext.DeleteObject(ShopId);
                return serviceResult;
            }
            catch (Exception ex)
            {
                var serviceResult = new ServiceResult();
                serviceResult.Success = false;
                return serviceResult;


            }
           
        }
    }
}
