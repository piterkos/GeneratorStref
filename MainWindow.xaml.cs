﻿using Check.Reports.Framework;
using Check.Reports.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace GeneratorStref
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Dater.Text = DateTime.Today.ToShortDateString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int poczatkowaStrefa = Convert.ToInt32(PoczatekStref.Text);
            int liczbaStrefDoDruku = Convert.ToInt32(Strefy.Text);
            List<Strefa> listaStrefDoDruku = new List<Strefa>();
            for (int i = poczatkowaStrefa; i < poczatkowaStrefa + liczbaStrefDoDruku ; i++)
            {
                
                string strefa = ((i).ToString()).PadLeft(4, '0');
                listaStrefDoDruku.Add(new Strefa("Check", Pomieszczenie.Text, Dater.SelectedDate.Value.ToShortDateString(),Filia.Text,prefix.Text+"-"+strefa, prefix.Text+strefa));
            }
            BarcodeReport barcodeReport = new BarcodeReport(listaStrefDoDruku);
            ReportService reportService = new ReportService(barcodeReport);
            reportService.OrderReport();
        }
    }
}
