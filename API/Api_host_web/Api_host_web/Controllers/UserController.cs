using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api_host_web.Models;
using Newtonsoft.Json;

namespace Api_host_web.Controllers
{
    [RoutePrefix("api")]
    public class UserController : ApiController
    {
        database_helper data = new database_helper();
        DataTable res = new DataTable();
        [Route("User")]
        [HttpGet]
        public IHttpActionResult GetLogin(UserAcc user)
        {
            res = new DataTable();
            res = data.Get_form_sql("SELECT id , [username],[password] FROM [dbo].[User]");

            for (int i = 0; i < res.Rows.Count; i++)
            {
                if (user.username == res.Rows[i]["username"].ToString() && user.password == res.Rows[i]["password"].ToString())
                {
                    res = data.Get_form_sql("INSERT INTO [dbo].[SessionLog] ([session_name],[date_time_singin],[id_user]) VALUES ('" + res.Rows[i]["username"].ToString() + "' , " + DateTime.Now.ToString("yyyy-MM-dd") + "," + res.Rows[i]["id"].ToString() + ")");
                
                    object ressponse = JsonConvert.SerializeObject(res);
                    return Ok(ressponse);
                }
            }
            return NotFound();
        }

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult PostCreate(UserAcc user)
        {
            res = new DataTable();
            res = data.Get_form_sql("INSERT INTO [dbo].[User] ( [username],[password],[Email]) VALUES (  '" + user.username + "','" + user.password + "','" + user.Email + "')");
            object response = JsonConvert.SerializeObject(res);
            return Ok(response);
        }


        [Route("Log")]
        [HttpPost]
        public IHttpActionResult DeleteLogout(UserAcc user)
        {
            res = new DataTable();
            res = data.Get_form_sql("DELETE [dbo].[SessionLog] where  id_user = " + user.id + "");
            object response = JsonConvert.SerializeObject(res);
            return Ok(response);
        }

        [Route("Profile")]
        [HttpGet]
        public IHttpActionResult PostProfile([FromUri]string id)
        {
            res = new DataTable();
            res = data.Get_form_sql(@"
                                SELECT[id]
                                        ,[post]
                                        ,[datetimepost]
                                        ,[like_post]
                                        ,[like_post_count]
                                        ,[edit_post]
                                        ,[edit_post_count]
                                        ,[User_id]
                                    FROM[dbo].[Post_] where User_id = " + id + "");
            object response = JsonConvert.SerializeObject(res);
            return Ok(res);
        }

        [Route("Write_Profile")]
        [HttpPost]
        public IHttpActionResult PostWriteProfile(Profile pro)
        {
            res = new DataTable();

            res = data.Get_form_sql(@"INSERT INTO [dbo].[Post_]
                                    ([post]
                                   ,[datetimepost]
                                   ,[like_post]
                                   ,[like_post_count]
                                   ,[edit_post]
                                   ,[edit_post_count]
                                   ,[User_id])
                             VALUES
                                   ('"+pro.post+"',"+
                                    ""+DateTime.Now.ToString("yyyy-MM-dd")+" "+
                                   ",'"+pro.like_post+"'"+
                                   ", "+pro.like_post_count+""+
                                   ",'"+pro.edit_post+"'"+
                                   ","+pro.edit_post_count+""+
                                   ","+pro.User_id+") ");
            object response = JsonConvert.SerializeObject(res);
            return Ok(res);
        }


    }
}