using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DL
{
    public class DbContext
    {
        #region DECLARE
        protected string _connectionString = "Host = 47.241.69.179; Port = 3306; Database = MF721_DVCuong_CukCuk ;User Id = dev; Password = 12345678";
        protected IDbConnection _dbConnection;
        #endregion

        #region constructor
        public DbContext()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }
        #endregion
        /// <summary>
        /// Hàm lấy dữ liệu theo paramater
        /// </summary>
        /// <typeparam name="MISAEntity">Kiểu dữ liệu</typeparam>
        /// <param name="sqlCommand">Câu truy vấn hoặc store (Lấy tất cả thì không cần truyền đối số này)</param>
        /// <param name="parameter">Đối tượng chứa tham số của Store</param>
        /// <param name="commandType">Mặc địch là store</param>
        /// <returns></returns>
        /// CreatedBy: Dvcuong(20/02/2021)
        public IEnumerable<MISAEntity> GetData<MISAEntity>(string sqlCommand = null, object parameter = null, CommandType commandType = CommandType.StoredProcedure)
        {
            //className: tên bảng dữ liệu cần lấy dữ liệu
            var className = typeof(MISAEntity).Name;
            if(sqlCommand == null)
            {
                sqlCommand = $"Proc_Get{className}s";
            }

           
            //Lấy dữ liệu
                var data = _dbConnection.Query<MISAEntity>(sqlCommand, param: parameter, commandType: commandType);
                return data;
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">object cần thêm mới</param>
        /// <returns>Số lượng bản ghi được thêm vào database</returns>
        /// CreatedBy: DvCuong (20/02/2021)
        public int InsertObject<MISAEntity>(MISAEntity entity)
        {

            var className = typeof(MISAEntity).Name;
            var res = _dbConnection.Execute($"Proc_Insert{className}", param: entity, commandType: CommandType.StoredProcedure);
            return res;
        }
        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="entity">shop cần sửa theo id</param>
        /// <returns>số lượng bản ghi thay đổi</returns>
        /// CreatedBy: DvCuong (20/02/2021)
        public int UpdateObject<MISAEntity>(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            var res = _dbConnection.Execute($"Proc_Update{className}ById", param: entity, commandType: CommandType.StoredProcedure);
            return res;
        }
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="shopId">Id shop cần xóa</param>
        /// <returns>Số lượng bản ghi thay đổi</returns>
        /// CreatedBy: Dvcuong (20/02/2021)
        public int DeleteObject(Guid ShopId)
        {
            //var parameters = new DynamicParameters();
            //parameters.Add(shopId.ToString());
            
            var res = _dbConnection.Execute("Proc_DeleteShopById", param: new { effectShopId = ShopId }, commandType: CommandType.StoredProcedure);
            return res;
        }
        
    }
}
