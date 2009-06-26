using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;
using AjaxPro.Services;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Utility.RegisterTypeForAjax(typeof(_Default));
    }

    [AjaxMethod]
    public String listar()
    {
        PessoaDAL DALPessoa = new PessoaDAL();
        List<Pessoa> objPessoa = DALPessoa.listar();
        String str = JavaScriptSerializer.Serialize(objPessoa);

        return str;
    }
}
