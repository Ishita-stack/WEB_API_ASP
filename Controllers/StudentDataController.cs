using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Web.Http;
using DBWebApi.Models;


namespace DBWebApi.Controllers
{
    public class StudentDataController : ApiController
    {
        StudentDBEntities1 dbs = new StudentDBEntities1();
        public IHttpActionResult GetStudent()
        {
            var studdisplay = dbs.students.ToList();
            return Ok(studdisplay);
        }

        public IHttpActionResult GetstudentResult(int id)
        {
            var studdisp = dbs.students.Find(id);
            if(studdisp == null)
            {
                return NotFound();
            }
            return Ok(studdisp);
        }
       
        public IHttpActionResult DeleteStudent(int id)
        {
            var studdel = dbs.students.Find(id);

            if (studdel == null)
            {
                return NotFound();
            }
            else
            {
                dbs.students.Remove(studdel);
                dbs.SaveChanges();
                return Ok(studdel);
            }
        }
        public IHttpActionResult PostStudent([FromBody] student tbladd)
        {
            if (tbladd == null)
            {
                return BadRequest();
            }
            else
            {
                dbs.students.Add(tbladd);
                //tbladd.Total=tbladd.Mark1 + tbladd.Mark2 + tbladd.Mark3;
                //tbladd.Per = tbladd.Total / 3;
                dbs.SaveChanges();
                return Ok(tbladd);
            }
        }
        public IHttpActionResult PutStudents(int id, [FromBody] student tblupdate)
        {
            var tblstudupdate = dbs.students.Find(id);

            if (tblstudupdate == null)
            {
                return NotFound();
            }
            else
            {
                tblstudupdate.Id = tblupdate.Id;
                tblstudupdate.Name = tblupdate.Name;
                dbs.SaveChanges();
                return Ok(tblstudupdate);
            }
        }
    }
}
