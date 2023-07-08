using RBACProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RBACProject.IRepository;
using RBACProject.Repository;
using RBACProject.Common;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Web.Script.Serialization;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using OfficeOpenXml;
using DataTable = System.Data.DataTable;


namespace RBACProject.Controllers
{

    [AllowAnonymous]
    /// <summary>
    /// 库存信息
    /// </summary>
    public class InventoryController : Controller
    {
        InventoryRepository inventoryRepository = new InventoryRepository();



        // GET: Inventory 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetInventoryList(PageInfo pageInfo, string MeterailCode = null, DateTime? beginTime = null, DateTime? endTime = null)
        {
            InventoryModel inventoryModel = new InventoryModel();

            int totalCount = 0;

            List<InventoryModel> inventoryModels = inventoryRepository.GetInventoryListPage(inventoryModel, pageInfo, ref totalCount);

            TableResult<InventoryModel> tableResult = new TableResult<InventoryModel>()
            {
                code = 0,
                count = totalCount,
                data = inventoryModels

            };

            return Json(tableResult, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ImportExcel()
        {
            return View();
        }



        /// <summary>
        /// 上传通用模板页
        /// </summary>
        /// <param name="KeyValue"></param>
        /// <returns></returns>
        public ActionResult ImportEdgeForm()
        {
            //var D = new me.Dal.Entity().Select<EdgeUrl>(
            //     new me.Dal.SelectPar
            //     {
            //         Where = $"type={KeyValue}",
            //         Param = null
            //     }).FirstOrDefault();
            //ViewBag.Url = D.Url;
            //ViewBag.ExcelName = D.ExcelName;
            //ViewBag.ExcelURL = D.ExcelURL.Trim() + "/" + D.Pmk.Trim() + "/" + D.ExcelName.Trim();



            //return View("~/Views/Edge/ImportEdgeForm.cshtml");


            return null;
        }


        [HttpPost]
        /// <summary>
        /// 上传原材料库存信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult ImportExcelInventory()
        {

            //获取mySession里面的登录者的信息
            //获取当前操作者的角色id
            var obj = DESEncryptNew.Decrypt(Session["mySession"].ToString());
            OperatorModel operatorModel = MyJson.ToObject<OperatorModel>(obj);

            try
            {
                //获取上传的文件
                var file = Request.Files[0];
                string rootPath = "/Content/Upload/xlsx/";
                string savePath = DateTime.Now.ToString("yyyyMMdd");

                if (file != null && file.ContentLength > 0)
                {
                    //校验是否为xlsx后缀的excel
                    if (Path.GetExtension(file.FileName)?.ToLower() != ".xlsx")
                    {
                        return Json(new { code = 400, msg = "文件类型仅限 .xlsx", });
                    }

                    //检验上传文件的大小，不能超过1MB
                    if (Convert.ToDouble(file.ContentLength / 1024) < 1024)
                    {
                        string directoryPath = Server.MapPath(rootPath + savePath);
                        //创建目录
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        // 处理上传文件，例如保存到服务器
                        string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        string filePath = Server.MapPath(rootPath + savePath + "/") + fileName;
                        file.SaveAs(filePath);

                        //把上传的excel数据导入到数据库中，然后刷新表格页面
                        inventoryRepository.WriteExcelDataToDataBase(filePath, operatorModel.UserName);
                        // 返回适当的响应
                        return Json(new { code = 200, msg = "Excel文件上传成功" });
                    }
                    else
                    {
                        return Json(new { msg = "文件大小超过1MB", code = 400 });
                    }
                }
                else
                {
                    // 处理没有上传文件的逻辑
                    return Json(new { code = 400, msg = "未选择Excel文件" });
                }
            }
            catch (Exception ex)
            {
                // 处理文件上传异常
                return Json(new { code = 401, msg = ex.Message });
            }
        }


        /// <summary>
        /// 下载excel模板
        /// </summary>
        /// <returns></returns>
        public ActionResult DownloadExcelTemplate()
        {
            string serverFilePath = Server.MapPath("~/Content/template/材料库存记录列表.xlsx");
            return File(serverFilePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Template.xlsx");

        }


        /// <summary>
        /// 导出excel数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ExportToExcel(string strId)
        {

            //传id进去吧，list<int>
            //1,2,3,4
            string[] arrs = strId.Split(',');

            List<InventoryModel> inventoryModels = new List<InventoryModel>();
            foreach (var item in arrs)
            {
                var intId = int.Parse(item);
                InventoryModel inventoryModel = inventoryRepository.QuerySingle(it => it.Id == intId);

                inventoryModels.Add(inventoryModel);

            }

            // 从数据库或其他数据源获取Layui表格的数据
            DataTable table = inventoryRepository.GetTableData(inventoryModels);

            // 创建Excel文件

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // 填充表头
                int col = 1;
                foreach (DataColumn column in table.Columns)
                {
                    worksheet.Cells[1, col].Value = column.ColumnName;
                    col++;
                }

                // 填充数据
                int row = 2;
                foreach (DataRow dataRow in table.Rows)
                {
                    col = 1;
                    foreach (var item in dataRow.ItemArray)
                    {
                        worksheet.Cells[row, col].Value = item.ToString();
                        col++;
                    }
                    row++;
                }

                // 保存 Excel 文件到内存流中
                MemoryStream stream = new MemoryStream();
                package.SaveAs(stream);

                // 设置响应内容类型为 Excel 文件
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                // 设置响应内容为 Excel 文件内容
                Response.AddHeader("content-disposition", "attachment;  filename=filename.xlsx");
                Response.BinaryWrite(stream.ToArray());
                Response.Flush();
                Response.End();

            }

            return Redirect("/inventory/index");

        }

    }
}