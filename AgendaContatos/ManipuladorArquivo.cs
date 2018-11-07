using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContatos
{
    public class ManipuladorArquivo
    {
        // Obter Diretório da Aplicação
        private static string EderecoArquivo = AppDomain.CurrentDomain.BaseDirectory + "contatos.txt";

        public static List<Contato> LerArquivo()
        {
            List<Contato> contatosList = new List<Contato>();

            if (File.Exists(@EderecoArquivo))
            {
                using (StreamReader sr = File.OpenText(@EderecoArquivo))
                {
                    while (sr.Peek()>=0)
                    {
                        string linha = sr.ReadLine();

                        string[] linhaContato=linha.Split(';');

                        if (linhaContato.Count()==3)
                        {
                            Contato contato = new Contato();
                            contato.Nome = linhaContato[0];
                            contato.Email = linhaContato[1];
                            contato.Telefone = linhaContato[2];
                            contatosList.Add(contato);
                        }
                    }
                }
            }

            return contatosList;
        }

        public static void EscreverArquivo(List<Contato> contatosList)
        {

            // using - limpa os buffers utilizados para utilizar o componente
            // Componente para escrever no arquivo
            using (StreamWriter sw = new StreamWriter(@EderecoArquivo, false))
            {
                foreach (Contato contato in contatosList)
                {
                    string linha = string.Format(contato.Nome + ";" + contato.Email + ";" + contato.Telefone);
                    sw.WriteLine(linha);
                }

                // Fecha o ponteiro
                sw.Close();
            }
        }

    }
}