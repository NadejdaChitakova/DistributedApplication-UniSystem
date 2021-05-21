using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helper
{
    public class LoadDataUnilities
    {
        public static SelectList LoadSpecialities()
        {
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                return new SelectList(service.GetSpecialities(),"Id","Name");
            }
        }
        public static SelectList LoadFaculties()
        {
            using (SoapService.Service1Client service = new SoapService.Service1Client())
            {
                return new SelectList(service.GetFaculties(), "Id", "Name");
            }
        }
    }
}