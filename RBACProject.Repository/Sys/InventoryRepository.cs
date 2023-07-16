
using Microsoft.Office.Interop.Excel;
using RBACProject.Common;
using RBACProject.IRepository;
using RBACProject.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DataTable = System.Data.DataTable;

namespace RBACProject.Repository
{
    public class InventoryRepository : BaseRepository<InventoryModel>, IInventoryRepository
    {
        public List<InventoryModel> GetInventoryListPage(InventoryModel inventoryModel, PageInfo pageInfo, ref int totalCount)
        {

            //查询，非null则添加上去

            //获取总数量
            totalCount = SqlSugarHelper.db.Queryable<InventoryModel>()
            //.WhereIF(!string.IsNullOrEmpty(actionModel.ActionName), it => it.ActionName.Contains(actionModel.ActionName))
            //.WhereIF((actionModel.Status != null), it => it.Status == actionModel.Status)
            .ToList().Count;

            //进行分页
            List<InventoryModel> inventoryModels = SqlSugarHelper.db.Queryable<InventoryModel>()
            //.WhereIF(!string.IsNullOrEmpty(actionModel.ActionName), it => it.ActionName.Contains(actionModel.ActionName))
            //.WhereIF((actionModel.Status != null), it => it.Status == actionModel.Status)
            .ToPageList(pageInfo.page, pageInfo.limit, ref totalCount);

            return inventoryModels;
        }

        public bool WriteExcelDataToDataBase(string filePath,string createBy)
        {

            Application excelApp = new Application();
            Workbook excelWorkbook = excelApp.Workbooks.Open(filePath);
            Worksheet excelWorksheet = excelWorkbook.ActiveSheet;

            try
            {
                int rowCount = excelWorksheet.UsedRange.Rows.Count;
                int columnCount = excelWorksheet.UsedRange.Columns.Count;
                
                //开启事务
                SqlSugarHelper.db.BeginTran();
                for (int row = 2; row <= rowCount; row++) // 第一行通常是标题，从第二行开始插入数据
                {
                    //获取数据
                    
                    string column1Value = excelWorksheet.Cells[row, 1].Value.ToString();
                    string column2Value = excelWorksheet.Cells[row, 2].Value.ToString();
                    string column3Value = excelWorksheet.Cells[row, 3].Value.ToString();
                    string column4Value = excelWorksheet.Cells[row, 4].Value.ToString();
                    string column5Value = excelWorksheet.Cells[row, 5].Value.ToString();
                    string column6Value = excelWorksheet.Cells[row, 6].Value.ToString();
                    string column7Value = excelWorksheet.Cells[row, 7].Value.ToString();
                    string column8Value = excelWorksheet.Cells[row, 8].Value.ToString();

                    InventoryModel inventoryModel = new InventoryModel()
                    {
                        MeterailCode = column1Value,
                        MeterailName = column2Value,
                        MeterailLotNo = int.Parse(column3Value),
                        MeterailSupplier = column4Value,
                        MeterailQty = int.Parse(column5Value),
                        MeterailUpdateDate = DateTime.Parse(column6Value),
                        Remark = column7Value,
                        MeterailStatus = column8Value,
                        ImportBy = createBy,
                        ImportTime = DateTime.Now

                    };

                // 将读取到的值插入到数据库表中
                SqlSugarHelper.db.Insertable(inventoryModel).IgnoreColumns("Id").ExecuteCommand();  
                }
                SqlSugarHelper.db.CommitTran();
                return true;
            }
            catch (Exception ex)
            {

                SqlSugarHelper.db.RollbackTran();
                return false;
            }
            finally
            {

                excelWorkbook.Close();
                excelApp.Quit();
            }
        }


        public DataTable GetTableData(List<InventoryModel> inventoryModels) {

            // 从数据库获取数据
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("MeterailCode", typeof(string));
            table.Columns.Add("MeterailName", typeof(string));
            table.Columns.Add("MeterailLotNo", typeof(int));
            table.Columns.Add("MeterailSupplier", typeof(string));
            table.Columns.Add("MeterailQty", typeof(int));
            table.Columns.Add("MeterailUpdateDate", typeof(DateTime));
            table.Columns.Add("Remark", typeof(string));
            table.Columns.Add("MeterailStatus", typeof(string));
            table.Columns.Add("ImportBy", typeof(string));
            table.Columns.Add("ImportTime", typeof(DateTime));

            // 将List集合中的数据添加到DataTable中
            foreach (InventoryModel inventoryModel in inventoryModels)
            {
                DataRow row = table.NewRow();
                row["Id"] = inventoryModel.Id;
                row["MeterailCode"] = inventoryModel.MeterailCode;
                row["MeterailName"] = inventoryModel.MeterailName;
                row["MeterailLotNo"] = inventoryModel.MeterailLotNo;
                row["MeterailSupplier"] = inventoryModel.MeterailSupplier;
                row["MeterailQty"] = inventoryModel.MeterailQty;
                row["MeterailUpdateDate"] = inventoryModel.MeterailUpdateDate;
                row["Remark"] = inventoryModel.Remark;
                row["MeterailStatus"] = inventoryModel.MeterailStatus;
                row["ImportBy"] = inventoryModel.ImportBy;
                row["ImportTime"] = inventoryModel.ImportTime;
                table.Rows.Add(row);
            }


            return table;

        }
    }
}
