﻿using KursovayaMAIN.Helper;
using KursovayaMAIN.Model;
using KursovayaMAIN.ViewModel;
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

namespace KursovayaMAIN.View
{
    /// <summary>
    /// Логика взаимодействия для ConsumablesUC.xaml
    /// </summary>
    public partial class ConsumablesUC : UserControl
    {
        public ConsumablesUC()
        {

            InitializeComponent();

            DataContext = new MainViewModel();

        }
    }
}