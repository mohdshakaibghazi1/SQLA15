using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
 
using ErrorHandlingEx;
using System.Web.UI.WebControls;

namespace ErrorHandlingEx
{
    public partial class Home : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label1.Visible=false;  
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;

            try
            {

                int dividend = int.Parse(TextBox1.Text);

                int divisor = int.Parse(TextBox2.Text);

                int result = dividend / divisor; // This will cause a divide by zero exception

                Label1.Text = "Result after Division: " + result.ToString();

                // You can also throw a custom exception

                if (result > 5)
                {

                    throw new Exception("Result is greater than 5.");
                }
            }

            catch (DivideByZeroException ex)
            {
                Session["error"] = "Divide by zero error occured." + ex.Message;
                Response.Redirect("Error.aspx");
            }

            catch (Exception ex)
            {



                Session["error"] = "An error occured." + ex.Message;
                Response.Redirect("Error.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Datanbinding.aspx");
        }
    }
}