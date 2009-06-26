using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PessoaDAL
/// </summary>
public class PessoaDAL
{
    public List<Pessoa> listar()
    {
        List<Pessoa> objList = new List<Pessoa>();
        Pessoa objPessoa = null;

        objPessoa = new Pessoa();
        objPessoa.nome = "Um Nome";
        objPessoa.sobreNome = "de Teste";
        objList.Add(objPessoa);
        objPessoa = null;


        objPessoa = new Pessoa();
        objPessoa.nome = "Nome 2";
        objPessoa.sobreNome = " Outro Teste";
        objList.Add(objPessoa);
        objPessoa = null;

        objList.Sort(delegate(Pessoa p1, Pessoa p2) { return p1.nome.CompareTo(p2.nome); });

        return objList;
    }
}
