namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ExportDto;
    using Invoices.Utilities;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var Clients = context.Clients
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .ToArray()
                .Select(c => new ExportXmlClientDto()
                {
                    Name = c.Name,
                    NumberVat = c.NumberVat,
                    InvoicesCount = c.Invoices.Count,
                    Invoices = c.Invoices
                    .OrderBy(i => i.IssueDate)
                    .ThenByDescending(i => i.DueDate)
                    .Select(i => new ExportXmlInvoiceDto()
                    {
                        Number = i.Number,
                        Amount = i.Amount,
                        DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        CurrencyType = i.CurrencyType.ToString(),
                    })
                    .ToArray()
                })
                .OrderByDescending(c => c.InvoicesCount)
                .ThenBy(c => c.Name)
                .ToArray();

            XmlHelper xmlHelper = new XmlHelper();

            string xmlRootName = "Clients";

            return xmlHelper.Serializer(Clients, xmlRootName);
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var products = context.Products
                .Where(p => p.ProductsClients.Any() &&
                p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))              
                .ToArray()
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(pc => new
                        {
                            pc.Client.Name,
                            pc.Client.NumberVat
                        })
                        .OrderBy(pc => pc.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(products, Formatting.Indented);
        }
    }
}