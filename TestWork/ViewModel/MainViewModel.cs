using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using TestWork.Helpes;
using TestWork.Model;

namespace TestWork.ViewModel
{
    public class MainViewModel: ObservableObject
    {
        public ObservableCollection<Record> Records { get; set; }
        public ObservableCollection<RecordInfo> RecordsInfos { get; set; }
        public DateFormatConverter DateFormatConverter { get; set; }
        private Record selectedRecord;
        private Window mainWindow;

        public MainViewModel(Window mainWindow)
        {
            Records = new ObservableCollection<Record>();
            RecordsInfos = new ObservableCollection<RecordInfo>();
            PropertyChanged += MainViewModel_ChangeRecord;
            mainWindow.Loaded += MainWindow_Loaded;           
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void MainViewModel_ChangeRecord(object sender, PropertyChangedEventArgs e)
        {                             
            using (DataBaseOrdersContainer db = new DataBaseOrdersContainer())
            {
                try
                {
                    List<OrderLine> ordersLines = db.OrderLines.Where(item => item.Order.Id == SelectedRecord.OrderNumber).ToList<OrderLine>();
                    RecordsInfos.Clear();
                    foreach (var item in ordersLines)
                    {
                        RecordInfo recordInfo = new RecordInfo
                        {
                            Product = item.Product.Name,
                            Price = item.Price,
                            Quantity = item.Quantity
                        };
                        RecordsInfos.Add(recordInfo);
                    }
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }                           
        }

        public Record SelectedRecord
        {
            get { return selectedRecord; }
            set
            {
                if (selectedRecord != value)
                {
                    selectedRecord = value;
                    OnPropertyChanged(nameof(SelectedRecord));
                }              
            }
        }
        private void LoadData()
        {
            using (DataBaseOrdersContainer db = new DataBaseOrdersContainer())
            {
                try
                {
                    var order = db.Orders.ToList<Order>();
                    foreach (var item in order)
                    {
                        Record record = new Record
                        {
                            OrderNumber = item.Id,
                            User = item.User.Name,
                            LineQuantity = item.OrderLines.Count,
                            Sum = item.OrderLines.Sum(inner => inner.Price),
                            Created = item.CreatedOn,
                            Modified = item.ModifiedOn
                        };
                        Records.Add(record);                      
                    }
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show(ex.Message);                   
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }           
        }
    }
}
