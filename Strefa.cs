using FastReport.Barcode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace GeneratorStref
{
    public class Strefa
    {
        public string InventoryCompany { get; set; }
        public string InventoryRoom { get; set; }
        public string InventoryDate { get; set; }
        public string InventoryStore { get; set; }
        public string ZoneNumber { get; set; }
        public string BarcodeEAN { get; }
        public Strefa(string firma, string pomieszczenie, string date, string filia, string zoneNumber, string ean)
        {
            InventoryCompany = firma;
            InventoryRoom = pomieszczenie;
            InventoryDate = date;
            InventoryStore = filia;
            ZoneNumber = zoneNumber;
            BarcodeEAN = ean;
        }
    }
}
