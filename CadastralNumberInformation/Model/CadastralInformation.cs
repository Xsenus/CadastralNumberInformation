using System;

namespace CadastralNumberInformation.Model
{
    public class CadastralInformation
    {
        public CadastralInformation() { }

        /// <summary>
        /// Тип.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Статус.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Регион.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Кадастровый район.
        /// </summary>
        public string CadastralDistrict { get; set; }

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Адрес полный.
        /// </summary>
        public string AddressFull { get; set; }

        /// <summary>
        /// Адрес по документам.
        /// </summary>
        public string AddressDocument { get; set; }

        /// <summary>
        /// Площадь м².
        /// </summary>
        public decimal Area { get; set; }

        /// <summary>
        /// Дата постановки на учет.
        /// </summary>
        public DateTime? DateRegistration { get; set; }

        /// <summary>
        /// Дата обновления информации.
        /// </summary>
        public DateTime? DateInformationUpdate { get; set; }

        /// <summary>
        /// Кадастровая стоимость.
        /// </summary>
        public decimal CadastralValue { get; set; }

        /// <summary>
        /// Дата определения стоимости.
        /// </summary>
        public DateTime? DateCosting { get; set; }

        /// <summary>
        /// Дата внесения стоимости в базу.
        /// </summary>
        public DateTime? DateAddValueToDatabase { get; set; }

        /// <summary>
        /// Дата утверждения стоимости.
        /// </summary>
        public DateTime? DateValidation { get; set; }

        /// <summary>
        /// Кадастровый инженер.
        /// </summary>
        public string CadastralEngineer { get; set; }

        /// <summary>
        /// По документу числится.
        /// </summary>
        public string AccordingDocumentListed { get; set; }

        /// <summary>
        /// Категория земель.
        /// </summary>
        public string LandCategory { get; set; }

        /// <summary>
        /// Кадастровый номер.
        /// </summary>
        public string CadastralNumber { get; set; }

        public override string ToString()
        {
            return $"Кадастровый номер: {CadastralNumber}\nТип: {Type}\nСтатус: {Status}\nПлощадь: {Area}\n";
        }
    }
}
