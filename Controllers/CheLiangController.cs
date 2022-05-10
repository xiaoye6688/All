using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheLiangGuanLi.Models;

namespace CheLiangGuanLi.Controllers
{
    public class CheLiangController : Controller
    {
        //1、连接数据库
        CarEntity db = new CarEntity();
        #region 查询 
        // GET: CheLiang
        [HttpGet]
        public ActionResult Index()
        {
            var list = db.CarRecord.ToList();

            return View(list);
        }

        #endregion
        #region 多条件查询
        [HttpPost]
        public ActionResult Index(string CarNo, string Mobile)
        {
            var list = db.CarRecord.ToList();
            //如果车牌号不为空   
            if (!string.IsNullOrEmpty(CarNo))
            {
                //根据车牌号进行查询 
                list = list.Where(a => a.CarNo.Contains(CarNo)).ToList();
            }
            //如果电话号不为空   
            if (!string.IsNullOrEmpty(Mobile))
            {
                //根据电话号进行查询 
                list = list.Where(a => a.Mobile.Contains(Mobile)).ToList();
            }
            return View(list);
        }
        #endregion

        #region 添加
        [HttpGet]
        public ActionResult AddChe()
        {
            //绑定下拉框
            var DDLList = db.CommunityInfo.ToList();
            ViewData["ddlst"] = new SelectList(DDLList, "CId", "CommunityName");
            return View();
        }
        [HttpPost]
        public ActionResult AddChe(CarRecord mm)
        {
            //把用户输入的值添加到数据库就可以了 
            mm.DriveTime = DateTime.Now;
            db.CarRecord.Add(mm);
            int a = db.SaveChanges();
            if (a > 0)
            {
                //添加成功
                return Content(@"<script>alert('添加成功！！！');location.href='/CheLiang/AddChe'</script>");
            }
            else
            {
                //添加失败
                return Content(@"<script>alert('添加失败！！！');location.href='/CheLiang/AddChe'</script>");
            }

        }
        #endregion

        #region 删除
        [HttpPost]
        public ActionResult ShanChu(int cid)
        {
            //可以根据id进行删除
            //2、根据id找到要删除的数据 
            var car = db.CarRecord.Where(a => a.CarId == cid).FirstOrDefault();
            //3、执行删除
            db.CarRecord.Remove(car);
            //4、保存
            int i = db.SaveChanges();
            return Json(i, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 修改
        [HttpGet]
        public ActionResult EditChe(int id)
        {
            //绑定下拉框
            var DDLList = db.CommunityInfo.ToList();
            ViewData["ddlst"] = new SelectList(DDLList, "CId", "CommunityName");
            //根据id查到要修改的数据 并显示出来 
            var car = db.CarRecord.Where(a => a.CarId == id).FirstOrDefault();
            return View(car);
        }
        [HttpPost]
        public ActionResult EditChe(CarRecord mm)
        {
            //把mm(用户修改的信息)保存到数据库
            //2、根据条件将修改的数据查出来
            CarRecord car = db.CarRecord.Where(a => a.CarId == mm.CarId).FirstOrDefault();
            //3、修改   对属性重新赋值
            car.CarName = mm.CarName;
            car.CarNo = mm.CarNo;
            car.Name = mm.Name;
            car.Mobile = mm.Mobile;
            car.State = mm.State;
            car.Type = mm.Type;
            car.CId = mm.CId;
            car.CarType = mm.CarType;
            //4、保存
            int i = db.SaveChanges();
            if (i > 0)
            {
                //修改成功
                return Content(@"<script>alert('修改成功！！！');location.href='/CheLiang/Index'</script>");
            }
            else
            {
                //修改失败
                return Content(@"<script>alert('修改失败！！！');location.href='/CheLiang/Index'</script>");
            }

        }
        #endregion

        #region 授权
        [HttpPost]
        public ActionResult ShouQuan(int cid)
        {
            //授权
            //根据id查到要修改的数据 
            CarRecord car = db.CarRecord.Where(a => a.CarId == cid).FirstOrDefault();
            //修改  
            car.Type = 1;
            //保存
            int i = db.SaveChanges();
            return Json(i, JsonRequestBehavior.AllowGet);
        } 
        #endregion


    }
}