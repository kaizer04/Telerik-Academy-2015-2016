using System;
using System.Web.UI;

namespace HW4.CachingData
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.currentTime.InnerText = DateTime.Now.ToLongTimeString();
        }
    }
}