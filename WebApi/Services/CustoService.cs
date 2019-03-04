using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;
using WebApi.Repositorios;
using ClosedXML.Excel;

namespace WebApi.Services
{
    public class CustoService
    {
        CustoRepositorio repositorio = new CustoRepositorio();

        public List<Custo> Get()
        {
            return repositorio.Get();
        }

        public List<Custo> GetByFuncionarioId(int funcionarioId)
        {
            return repositorio.GetByFuncionarioId(funcionarioId);
        }

        public List<Custo> GetByDescricao(string descricao)
        {
            if (String.IsNullOrEmpty(descricao))
                return  Get();

            return repositorio.GetByDescricao(descricao);
        }

        public void Create(Custo custo)
        {
            repositorio.Create(custo);
        }

        public void ImportarExcel(string file)
        {       

            var wb = new XLWorkbook(@"h:\root\home\bolaoarte-001\www\projetoll\temp\" + file);

            var planilha = wb.Worksheet(1);

            //linha que começa os a ler os dados, pois a primeira é o cabeçalho
            var linha = 2;

            List<Custo> custos = new List<Custo>();

            while (true)
            {
                Custo custo = new Custo();

                var funcionarioId = planilha.Cell("A" + linha.ToString()).Value.ToString();

                //se não houver informação, a planilha termina.
                if (String.IsNullOrEmpty(funcionarioId)) break;

                custo.FuncionarioId = Convert.ToInt32(funcionarioId);    

                custo.Descricao = planilha.Cell("C" + linha.ToString()).Value.ToString();
                custo.Valor = Convert.ToDecimal(planilha.Cell("D" + linha.ToString()).Value.ToString());

                custos.Add(custo);

                linha++;
            }
            
            wb.Dispose();

            repositorio.ImportarExcel(custos);
            
        }
    
    }
}