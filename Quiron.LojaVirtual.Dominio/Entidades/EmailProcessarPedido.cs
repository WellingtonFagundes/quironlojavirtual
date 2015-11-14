using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfiguracoes)
        {
            _emailConfiguracoes = emailConfiguracoes;


        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using (var smtpclient = new SmtpClient())
            {
                smtpclient.EnableSsl = _emailConfiguracoes.UsarSsl;
                smtpclient.Host = _emailConfiguracoes.ServidorSmtp;
                smtpclient.Port = _emailConfiguracoes.ServidorPorta;
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario,
                    _emailConfiguracoes.ServidorSmtp);

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    smtpclient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpclient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                    smtpclient.EnableSsl = false;

                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Novo Pedido")
                    .AppendLine("-----------")
                    .AppendLine("Itens");

                foreach (var item in carrinho.ItensCarrinho)
                {
                    var subtotal = item.Produto.Preco*item.Quantidade;
                    body.AppendFormat("{0} x {1} x {2:c}", 
                                     item.Quantidade, item.Produto.Nome, subtotal);
                }

                body.AppendFormat("Valor total do pedido {0:c}", carrinho.ObterValorTotal())
                    .AppendLine("----------------------------------------------")
                    .AppendLine("Enviar para:")
                    .AppendLine(pedido.NomeCliente)
                    .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? "")
                    .AppendLine(pedido.Cidade ?? "")
                    .AppendLine(pedido.Complemento ?? "")
                    .AppendLine("-----------------------------------------------")
                    .AppendFormat("Embrulhar para presente? {0}", pedido.EmbrulhaPresente ? "Sim" : "Não");

                MailMessage mailMessage = new MailMessage(
                    _emailConfiguracoes.De,
                    _emailConfiguracoes.Para,
                    "Novo Pedido",
                    body.ToString());

                
                if (_emailConfiguracoes.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                smtpclient.Send(mailMessage);

            }
        }
    }
}