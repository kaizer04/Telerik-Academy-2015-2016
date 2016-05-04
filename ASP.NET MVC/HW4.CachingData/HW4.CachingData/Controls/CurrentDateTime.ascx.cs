using System;
using System.Web.UI;

namespace HW4.CachingData.Controls
{
    public partial class CurrentDateTime : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ctrlCurrentDateTime.InnerText = DateTime.Now.ToLongTimeString();
        }
    }
}