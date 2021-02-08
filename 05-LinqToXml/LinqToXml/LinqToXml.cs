using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LinqToXml
{
    public static class LinqToXml
    {
        /// <summary>
        /// Creates hierarchical data grouped by category
        /// </summary>
        /// <param name="xmlRepresentation">Xml representation (refer to CreateHierarchySourceFile.xml in Resources)</param>
        /// <returns>Xml representation (refer to CreateHierarchyResultFile.xml in Resources)</returns>
        public static string CreateHierarchy(string xmlRepresentation)
        {
            var groupByCategory = XElement
                .Parse(xmlRepresentation)
                .Elements("Data")
                .GroupBy(e => e.Element("Category").Value);

            return new XElement("Root",
                    groupByCategory.Select(g =>
                        new XElement("Group",
                            new XAttribute("ID", g.Key),
                            g.Select(e =>
                                new XElement("Data",
                                    e.Element("Quantity"),
                                    e.Element("Price"))))))
                .ToString();
        }

        /// <summary>
        /// Get list of orders numbers (where shipping state is NY) from xml representation
        /// </summary>
        /// <param name="xmlRepresentation">Orders xml representation (refer to PurchaseOrdersSourceFile.xml in Resources)</param>
        /// <returns>Concatenated orders numbers</returns>
        /// <example>
        /// 99301,99189,99110
        /// </example>
        public static string GetPurchaseOrders(string xmlRepresentation)
        {
            XDocument element = XDocument.Parse(xmlRepresentation);
            XNamespace name = element.Root.GetNamespaceOfPrefix("aw");

            return element.Root
                .Elements(name + "PurchaseOrder")
                .Elements(name + "Address")
                .Where(x =>
                    x.Attribute(name + "Type").Value == "Shipping" && x.Element(name + "State").Value == "NY")
                .Select(z =>
                    z.Parent.Attribute(name + "PurchaseOrderNumber").Value)
                .Aggregate((q, w) =>
                q + "," + w);
        }

        /// <summary>
        /// Reads csv representation and creates appropriate xml representation
        /// </summary>
        /// <param name="customers">Csv customers representation (refer to XmlFromCsvSourceFile.csv in Resources)</param>
        /// <returns>Xml customers representation (refer to XmlFromCsvResultFile.xml in Resources)</returns>
        public static string ReadCustomersFromCsv(string customers)
        {
            IEnumerable<string[]> cus = customers
                .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.Split(','));

            return new XElement("Root",
                cus.Select(data =>
                new XElement("Customer",
                    new XAttribute("CustomerID", data[0]),
                    new XElement("CompanyName", data[1]),
                    new XElement("ContactName", data[2]),
                    new XElement("ContactTitle", data[3]),
                    new XElement("Phone", data[4]),
                    new XElement("FullAddress",
                        new XElement("Address", data[5]),
                        new XElement("City", data[6]),
                        new XElement("Region", data[7]),
                        new XElement("PostalCode", data[8]),
                        new XElement("Country", data[9])))))
                .ToString();
        }

        /// <summary>
        /// Gets recursive concatenation of elements
        /// </summary>
        /// <param name="xmlRepresentation">Xml representation of document with Sentence, Word and Punctuation elements. (refer to ConcatenationStringSource.xml in Resources)</param>
        /// <returns>Concatenation of all this element values.</returns>
        public static string GetConcatenationString(string xmlRepresentation)
        {
            return XDocument
                .Parse(xmlRepresentation)
                .Elements()
                .Aggregate("", (f, s) => s.Value + "");
        }

        /// <summary>
        /// Replaces all "customer" elements with "contact" elements with the same childs
        /// </summary>
        /// <param name="xmlRepresentation">Xml representation with customers (refer to ReplaceCustomersWithContactsSource.xml in Resources)</param>
        /// <returns>Xml representation with contacts (refer to ReplaceCustomersWithContactsResult.xml in Resources)</returns>
        public static string ReplaceAllCustomersWithContacts(string xmlRepresentation)
        {
            XElement el = XElement.Parse(xmlRepresentation);
            el.ReplaceAll(el
                .Elements("customer")
                .Select(x => new XElement("contact", x.Elements())));
            return el.ToString();
        }

        /// <summary>
        /// Finds all ids for channels with 2 or more subscribers and mark the "DELETE" comment
        /// </summary>
        /// <param name="xmlRepresentation">Xml representation with channels (refer to FindAllChannelsIdsSource.xml in Resources)</param>
        /// <returns>Sequence of channels ids</returns>
        public static IEnumerable<int> FindChannelsIds(string xmlRepresentation)
        {
            return XElement
                .Parse(xmlRepresentation)
                .Elements("channel")
                .Where(x => x.Elements("subscriber").Count() > 1 &&
                x.Nodes().OfType<XComment>().Any(y => y.Value.Equals("DELETE")))
                .Aggregate(new List<int>(), (x, y) =>
                {
                    x.Add(int.Parse(y.Attribute("id").Value));
                    return x;
                });
        }

        /// <summary>
        /// Sort customers in docement by Country and City
        /// </summary>
        /// <param name="xmlRepresentation">Customers xml representation (refer to GeneralCustomersSourceFile.xml in Resources)</param>
        /// <returns>Sorted customers representation (refer to GeneralCustomersResultFile.xml in Resources)</returns>
        public static string SortCustomers(string xmlRepresentation)
        {
            var a = XElement
                .Parse(xmlRepresentation)
                .Elements()
                .OrderBy(x => x.Element("FullAddress").Element("Country").Value)
                .ThenBy(x => x.Element("FullAddress").Element("City").Value);
            return new XElement("Root", a).ToString();
        }

        /// <summary>
        /// Gets XElement flatten string representation to save memory
        /// </summary>
        /// <param name="xmlRepresentation">XElement object</param>
        /// <returns>Flatten string representation</returns>
        /// <example>
        ///     <root><element>something</element></root>
        /// </example>
        public static string GetFlattenString(XElement xmlRepresentation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets total value of orders by calculating products value
        /// </summary>
        /// <param name="xmlRepresentation">Orders and products xml representation (refer to GeneralOrdersFileSource.xml in Resources)</param>
        /// <returns>Total purchase value</returns>
        public static int GetOrdersValue(string xmlRepresentation)
        {
            var products = XElement
              .Parse(xmlRepresentation)
              .Elements("products")
              .Elements()
              .ToDictionary(key => key.Attribute("Id").Value,
              value => int.Parse(value.Attribute("Value").Value));

            return XElement.Parse(xmlRepresentation)
                .Elements("Orders")
                .Elements("Order")
                .Elements("product")
                .Sum(x => products[x.Value]);
        }
    }
}
