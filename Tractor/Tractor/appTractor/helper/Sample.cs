using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace appTractor.helper
{
    class Sample
    {
        public Sample()
        {
            //snippet
            //MySqlDataReader reader = cmd.ExecuteReader();

            // add to collection
            List<MyReportClass> myReportClassCollection = new List<MyReportClass>();

            //while (reader.Read())
            //{
            // populate entity
            var myReportClass = new MyReportClass();
            // set properties, skipping DBNull checking for quickness
            myReportClass.ID = 1;//(int)reader["ID"];
            myReportClass.Name = "Test";//(string) reader["Name"];

            myReportClassCollection.Add(myReportClass);
            //}

            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = Path.Combine(Environment.CurrentDirectory, "Report\\crBalanceReport.rdlc");
            viewer.LocalReport.DataSources.Add(new ReportDataSource("myDataSource", myReportClassCollection));
            //viewer.LocalReport.Render("PDF", "", out mimeType, out encoding, out extension, out streamIds, out warnings);
        }
    }

    public class MyReportClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
