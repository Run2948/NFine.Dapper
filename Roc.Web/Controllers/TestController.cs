using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roc.Data;
using Roc.Model.Entity.SystemManage;
using System.Linq.Expressions;

namespace Roc.Web.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            //SqlBuilder buider = new SqlBuilder();
            //var template = buider.AddTemplate("select age , name,/**select**/ from tablea as a /**leftjoin**/  /**where**/ /**orderby**/");
            //buider = buider.Select("abc").Where("age>@age and name=@name", new { age = 100, name = "张三" }).Where(" sex='男' ").LeftJoin(" tableb as b on a.id=b.id ").OrderBy("id, name desc");
            SqlLam<UserEntity> sql = new SqlLam<UserEntity>().Where(m => m.F_Id == "1" && m.F_NickName.Contains("roc")).Select(m => new { m.F_ManagerId, m.F_Id, m.F_IsAdministrator });

            var data = new { SQL = sql.SqlString, Parameters = sql.Parameters };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update()
        {
            UserEntity model = new UserEntity();
            model.F_NickName = "abc";
            model.F_IsAdministrator = true;
            model.F_ManagerId = "ddddddddddd";

            SqlLam<UserEntity> sql = new SqlLam<UserEntity>()
            .Update(new { F_NickName = "chengpeng", F_IsAdministrator = false, F_ManagerId = "id09" }).Where(u => u.F_MobilePhone == "123");

            var data = new { SQL = sql.SqlString, Parameters = sql.Parameters };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            SqlLam<UserEntity> sql = new SqlLam<UserEntity>().Where(u => u.F_Id == "a" && u.F_NickName == "a");
            sql.And(u => u.F_MobilePhone == "123").OrderBy(u => u.F_RoleId);

            var data = new { SQL = sql.QueryPage(10, 2), Parameters = sql.Parameters };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public Expression<Func<UserEntity>> GetUserEntity()
        {
            Expression<Func<UserEntity>> exp = () => new UserEntity() { };
            return exp;
        }

        private bool Where(UserEntity m)
        {
            return false;
        }
    }
}
