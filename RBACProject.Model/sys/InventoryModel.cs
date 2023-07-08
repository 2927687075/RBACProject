using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SqlSugar;

namespace RBACProject.Model
{
    [SugarTable("t_inventory")]
    public class InventoryModel
    {

        [SugarColumn(IsPrimaryKey = true)]
        /// <summary>
        /// 自增id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 材料编码
        /// </summary>
        public string MeterailCode { get; set; }

        /// <summary>
        /// 材料名称
        /// </summary>
        public string MeterailName { get; set; }

        /// <summary>
        /// 材料批次
        /// </summary>
        public int MeterailLotNo { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public string MeterailSupplier { get; set; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public int MeterailQty { get; set; }

        /// <summary>
        /// 库存更新时间
        /// </summary>
        public DateTime MeterailUpdateDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string MeterailStatus { get; set; }

        /// <summary>
        /// 导入人
        /// </summary>
        public string ImportBy { get; set; }

        /// <summary>
        /// 导入时间
        /// </summary>
        public DateTime ImportTime { get; set; }

    }
}