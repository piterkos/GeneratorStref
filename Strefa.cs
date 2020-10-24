using FastReport.Barcode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
        public Strefa(string _numerDlaBarcode)
        {
            InventoryCompany = "Check";
            InventoryRoom = "Magazyn";
            InventoryDate = "21.10.2020";
            InventoryStore = "LPP - Sinsay";
            ZoneNumber = "11-" + _numerDlaBarcode;
            BarcodeEAN = "11" + _numerDlaBarcode;
        }
    }
}
