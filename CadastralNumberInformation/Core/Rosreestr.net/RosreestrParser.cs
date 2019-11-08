using System;
using System.Linq;
using AngleSharp.Html.Dom;
using CadastralNumberInformation.Model;

namespace CadastralNumberInformation.Core.Rosreestr.net
{
    public class RosreestrParser : IParser<CadastralInformation>
    {
        public CadastralInformation Parse(IHtmlDocument document)
        {
            var cadastralInformation = new CadastralInformation();

            var items = document.QuerySelectorAll("div").Where(a => a.ClassName != null && a.ClassName.Contains("test__data"));

            foreach (var item in items)
            {
                var b = item.QuerySelectorAll("div");

                foreach (var asd in b)
                {
                    if (asd.TextContent.Contains("Тип"))
                    {
                        var type = asd.QuerySelector("strong").TextContent.Trim();

                        if (type.Length > 0)
                        {
                            type = Char.ToUpper(type[0]) + type.Substring(1).ToLower();
                        }

                        cadastralInformation.Type = type;
                    }

                    if (asd.TextContent.Contains("Статус"))
                    {
                        var status = asd.QuerySelector("strong").TextContent.Trim();

                        if (status.Length > 0)
                        {
                            status = Char.ToUpper(status[0]) + status.Substring(1).ToLower();
                        }

                        cadastralInformation.Status = status;
                    }

                    if (asd.TextContent.Contains("Регион"))
                    {
                        var region = asd.QuerySelector("strong").TextContent.Trim();

                        cadastralInformation.Region = region;
                    }

                    if (asd.TextContent.Contains("Кадастровый район"))
                    {
                        var сadastralDistrict = asd.QuerySelector("strong").TextContent.Trim();

                        cadastralInformation.CadastralDistrict = сadastralDistrict;
                    }

                    if (asd.TextContent.Contains("Почтовый индекс"))
                    {
                        var postcode = asd.QuerySelector("strong").TextContent.Trim();

                        cadastralInformation.Postcode = postcode;
                    }

                    if (asd.TextContent.Contains("Адрес полный"))
                    {
                        var addressFull = asd.QuerySelector("strong").TextContent.Trim();

                        cadastralInformation.AddressFull = addressFull;
                    }

                    if (asd.TextContent.Contains("Адрес по документам"))
                    {
                        var addressDocument = asd.TextContent.Replace("Адрес по документам:", "").Trim();

                        cadastralInformation.AddressDocument = addressDocument;
                    }

                    if (asd.TextContent.Contains("Площадь"))
                    {
                        var result2 = decimal.TryParse(asd.QuerySelector("strong").TextContent.Trim().Split(' ').FirstOrDefault(), out decimal area);

                        cadastralInformation.Area = area;
                    }

                    if (asd.TextContent.Contains("Кадастровая стоимость"))
                    {
                        var result = decimal.TryParse(string.Join("", asd.QuerySelector("strong").TextContent.Trim().Where(c => char.IsDigit(c))), out decimal cadastralValue);

                        cadastralInformation.CadastralValue = cadastralValue;
                    }

                    if (asd.TextContent.Contains("Дата постановки на учёт"))
                    {
                        var result = asd.QuerySelector("strong").TextContent.Trim();
                        var dateRegistration = default(DateTime?);

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            if (DateTime.TryParse(result, out DateTime date))
                            {
                                dateRegistration = date;
                            }                            
                        }

                        cadastralInformation.DateRegistration = dateRegistration;
                    }

                    if (asd.TextContent.Contains("Дата обновления информации"))
                    {
                        var result = asd.QuerySelector("strong").TextContent.Trim();
                        var dateInformationUpdate = default(DateTime?);

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            if (DateTime.TryParse(result, out DateTime date))
                            {
                                dateInformationUpdate = date;
                            }
                        }

                        cadastralInformation.DateInformationUpdate = dateInformationUpdate;
                    }

                    if (asd.TextContent.Contains("Дата определения стоимости"))
                    {
                        var result = asd.QuerySelector("strong").TextContent.Trim();
                        var dateCosting = default(DateTime?);

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            if (DateTime.TryParse(result, out DateTime date))
                            {
                                dateCosting = date;
                            }
                        }

                        cadastralInformation.DateCosting = dateCosting;
                    }

                    if (asd.TextContent.Contains("Дата внесения стоимости в базу"))
                    {
                        var result = asd.QuerySelector("strong").TextContent.Trim();
                        var dateAddValueToDatabase = default(DateTime?);

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            if (DateTime.TryParse(result, out DateTime date))
                            {
                                dateAddValueToDatabase = date;
                            }
                        }

                        cadastralInformation.DateAddValueToDatabase = dateAddValueToDatabase;
                    }

                    if (asd.TextContent.Contains("Дата утверждения стоимости"))
                    {
                        var result = asd.QuerySelector("strong").TextContent.Trim();
                        var dateValidation = default(DateTime?);

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            if (DateTime.TryParse(result, out DateTime date))
                            {
                                dateValidation = date;
                            }
                        }

                        cadastralInformation.DateValidation = dateValidation;
                    }

                    if (asd.TextContent.Contains("Кадастровый иженер"))
                    {
                        var cadastralEngineer = asd.QuerySelector("strong").TextContent.Trim();

                        cadastralInformation.CadastralEngineer = cadastralEngineer;
                    }

                    if (asd.TextContent.Contains("По документу числится"))
                    {
                        var accordingDocumentListed = asd.QuerySelector("strong").TextContent.Trim();

                        if (accordingDocumentListed.Length > 0)
                        {
                            accordingDocumentListed = Char.ToUpper(accordingDocumentListed[0]) + accordingDocumentListed.Substring(1).ToLower();
                        }

                        cadastralInformation.AccordingDocumentListed = accordingDocumentListed;
                    }

                    if (asd.TextContent.Contains("Категория земель"))
                    {
                        var landCategory = asd.QuerySelector("strong").TextContent.Trim();

                        if (landCategory.Length > 0)
                        {
                            landCategory = Char.ToUpper(landCategory[0]) + landCategory.Substring(1).ToLower();
                        }

                        cadastralInformation.LandCategory = landCategory;
                    }

                    if (asd.TextContent.Contains("Кадастровый номер"))
                    {
                        var cadastralNumber = asd.QuerySelector("strong").TextContent.Trim();

                        cadastralInformation.CadastralNumber = cadastralNumber;
                    }
                }
            }

            return cadastralInformation;
        }
    }
}
