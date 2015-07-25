using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string name = TextBox1.Text;

        int salary = Convert.ToInt16(TextBox1.Text); ;

        int age = Convert.ToInt16(TextBox3.Text); ;


       

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
}