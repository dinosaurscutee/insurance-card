using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace InsuranceCard1.App_Start
{
    public class BundleConfig
    {
        public static void Notify(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Script/bootstrap.js","~/Script/toastr.min.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/icofont.min.css", "~/Content/toastr.min.css", "~/Content/site.css"));
        }
    }
}
