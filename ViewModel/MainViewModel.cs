using KursovayaMAIN.Helper;
using KursovayaMAIN.Model;
using KursovayaMAIN.View;
using KursovayaMAIN.WindowsNew;
using KursovayaMAIN.WindowUser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace KursovayaMAIN.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ApplicationContext db = new ApplicationContext(); //контекст данных

        public MainViewModel vmMain; //объект класса взаимодействия

        //списки данных моделей данных в виде коллекции List
        private List<Weapons> weaponss;
        private List<Consumables> consumabless;
        private List<Equipments> equipmentss;
        private List<Orders> orderss;

        //свойство для обеспечения открытия страниц UserControl
        private object currentPage;
        public object CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (currentPage != value)
                {
                    currentPage = value;
                    OnPropertyChanged("CurrentPage");
                }
            }
        }

        //свойства ICommand для осуществления сортировки страниц моделей данных
        public ICommand SortAscendingCommandUser { get; }
        public ICommand SortDescendingCommandUser { get; }

        public ICommand SortAscendingCommandWeapon { get; }
        public ICommand SortDescendingCommandWeapon { get; }

        public ICommand SortAscendingCommandEquipment { get; }
        public ICommand SortDescendingCommandEquipment { get; }

        public ICommand SortAscendingCommandConsumable { get; }
        public ICommand SortDescendingCommandConsumable { get; }

        //свойство для обеспечения работоспособности команды смены страниц при нажатии на кнопки меню
        public ICommand ChangePageCommand { get; }

        //предварительная загрузка данных в приложение из базы данных перед открытием его страниц
        public MainViewModel()
        {
            LoadData();
            ChangePageCommand = new RelayCommand(ChangePageExecute);
            //инициализация главной страницы как стартовой
            CurrentPage = new MainSheetUC();

            //присваивание свойствам сортировки функционала методов сортировки

            SortAscendingCommandUser = new RelayCommand(SortUsersAscending);
            SortDescendingCommandUser = new RelayCommand(SortUsersDescending);

            SortAscendingCommandWeapon = new RelayCommand(SortWeaponsAscending);
            SortDescendingCommandWeapon = new RelayCommand(SortWeaponsDescending);

            SortAscendingCommandEquipment = new RelayCommand(SortEquipmentsAscending);
            SortDescendingCommandEquipment = new RelayCommand(SortEquipmentsDescending);

            SortAscendingCommandConsumable = new RelayCommand(SortConsumablesAscending);
            SortDescendingCommandConsumable = new RelayCommand(SortConsumablesDescending);

        }

        //инициализация списков в виде графической коллекции ICollectionView и списков данных Observable Collection
        // для хранения данных в них из соответствующих таблиц базы данных
        public ICollectionView UsersCollectionView { get; set; }
        public ObservableCollection<Users> _usList = new ObservableCollection<Users>();

        public ICollectionView WeaponsCollectionView { get; set; }
        public ObservableCollection<Weapons> _weaponList = new ObservableCollection<Weapons>();

        public ICollectionView EquipmentsCollectionView { get; set; }
        public ObservableCollection<Equipments> _equipList = new ObservableCollection<Equipments>();

        public ICollectionView ConsumablesCollectionView { get; set; }
        public ObservableCollection<Consumables> _consList = new ObservableCollection<Consumables>();

        public ICollectionView ShortOrdersCollectionView { get; set; }
        public ObservableCollection<Orders> _shortordersList = new ObservableCollection<Orders>();

        public ICollectionView FullOrdersCollectionView { get; set; }
        public ObservableCollection<Weapons_Equipments_Consumable_OrdersDPO> _fullorderList = new ObservableCollection<Weapons_Equipments_Consumable_OrdersDPO>();

        public ICollectionView FullOrdersNoDPOCollectionView { get; set; }
        public ObservableCollection<Weapons_Equipments_Consumables_Orders> _fullordersnoList = new ObservableCollection<Weapons_Equipments_Consumables_Orders>();

        //метод для загрузки данных в графические списки пользовательских страниц моделей данных
        //из списков коллекции ObservableCollection.
        public void LoadData()
        {
            _usList = new ObservableCollection<Users>(db.Users);
            UsersCollectionView = CollectionViewSource.GetDefaultView(_usList);

            _consList = new ObservableCollection<Consumables>(db.Consumables);
            ConsumablesCollectionView = CollectionViewSource.GetDefaultView(_consList);

            _equipList = new ObservableCollection<Equipments>(db.Equipments);
            EquipmentsCollectionView = CollectionViewSource.GetDefaultView(_equipList);

            _weaponList = new ObservableCollection<Weapons>(db.Weapons);
            WeaponsCollectionView = CollectionViewSource.GetDefaultView(_weaponList);

            _fullorderList = new ObservableCollection<Weapons_Equipments_Consumable_OrdersDPO>(db.Weapons_Equipments_Consumables_Orders);

            //рассчёт стоимости заказов из списка с помощью LINQ запросов
            foreach(var item in _fullorderList)
            {
                var weaponName = (from weapon in db.Weapons
                                  where weapon.weaponId == item.WeaponId
                                  select weapon.WeaponName).FirstOrDefault();
                var consumableName = (from consumable in db.Consumables
                                  where consumable.consumableId == item.ConsumableId
                                  select consumable.ConsumableName).FirstOrDefault();
                var equipmentName = (from equipment in db.Equipments
                                  where equipment.equipmentId == item.EquipmentId
                                  select equipment.EquipmentName).FirstOrDefault();

                var standardOrderPrice = (from order in db.Orders
                                     where order.TariffName == "Стандартный"
                                     select order.TariffPrice).FirstOrDefault();
                var premiumOrderPrice = (from order in db.Orders
                                          where order.TariffName == "Премиальный"
                                          select order.TariffPrice).FirstOrDefault();

                var consumPrice = (from consumable in db.Consumables
                                   where consumable.consumableId == item.ConsumableId
                                   select consumable.ConsumablePrice).FirstOrDefault();
                var weaponPrice = (from weapon in db.Weapons
                                   where weapon.weaponId == item.WeaponId
                                   select weapon.WeaponPrice).FirstOrDefault();
                var equipmentPrice = (from equipment in db.Equipments
                                      where equipment.equipmentId == item.EquipmentId
                                      select equipment.EquipmentPrice).FirstOrDefault();
                var countBalls = (from order in db.Orders
                                  where order.orderId == item.OrderId
                                  select order.CountBalls).FirstOrDefault();

                int priceOneBall = 3;

                var priceBalls = priceOneBall * countBalls;

                string? typeOrd = ""; //тип заявки

                double fullOrdPrice;

                //если тип заявки Стандартный, то
                if (typeOrd == (from order in db.Orders
                               where order.TariffName == "Стандартный"
                               select order.TariffName).FirstOrDefault())
                {
                    fullOrdPrice = weaponPrice + equipmentPrice + consumPrice + priceBalls + standardOrderPrice;
                }
                //если тип заявки Преимальный, то
                else
                {
                    fullOrdPrice = weaponPrice + equipmentPrice + consumPrice + priceBalls + premiumOrderPrice;
                }
                // Установка названия оружия в объекте Weapons_Equipments_Consumable_OrdersDPO
                item.WeaponName = weaponName;
                item.ConsumableName = consumableName;
                item.EquipmentName = equipmentName;
                item.OrderCost = fullOrdPrice;
                
            }
            FullOrdersCollectionView = CollectionViewSource.GetDefaultView(_fullorderList);

            _shortordersList = new ObservableCollection<Orders>(db.Orders);
            ShortOrdersCollectionView = CollectionViewSource.GetDefaultView (_shortordersList);

        }

        //метод для обеспечения переключения по страницам приложения
        private void ChangePageExecute(object pageName)
        {
            switch (pageName)
            {
                case "MainSheetUC":
                    CurrentPage = new MainSheetUC();
                    break;
                case "UsersUC":
                    CurrentPage = new UsersUC();
                    break;
                case "WeaponsUC":
                    CurrentPage = new WeaponsUC();
                    break;
                case "EquipmentsUC":
                    CurrentPage = new EqipmentsUC();
                    break;
                case "ConsumablesUC":
                    CurrentPage = new ConsumablesUC();
                    break;
                case "OrdersUC":
                    CurrentPage = new OrdersUC();
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #region User

        private Users _selectedUser;
        public Users SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
                EditUser.CanExecute(true);
            }
        }

        //нахождение пользователя с максимальным ID
        public int MaxIdUsers()
        {
            int max = 0;
            foreach (var u in this._usList)
            {
                if (max < u.userId)
                {
                    max = u.userId;
                };
            }
            return max;
        }
        
        //сортировка по возрастанию для списка страницы "Пользователи"
        private void SortUsersAscending(object parameter)
        {
            // Определение критериев сортировки
            SortDescription sortName = new SortDescription("NameUser", ListSortDirection.Ascending);
            SortDescription sortSurname = new SortDescription("SurnameUser", ListSortDirection.Ascending);

            // Применение критериев сортировки к представлению данных
            UsersCollectionView.SortDescriptions.Clear();
            UsersCollectionView.SortDescriptions.Add(sortName);
            UsersCollectionView.SortDescriptions.Add(sortSurname);
            UsersCollectionView.Refresh();
        }

        //сортировка по убыванию для списка страницы "Пользователи"
        private void SortUsersDescending(object parameter)
        {
            // Определение критериев сортировки
            SortDescription sortName = new SortDescription("NameUser", ListSortDirection.Descending);
            SortDescription sortSurname = new SortDescription("SurnameUser", ListSortDirection.Descending);

            // Применение критериев сортировки к представлению данных
            UsersCollectionView.SortDescriptions.Clear();
            UsersCollectionView.SortDescriptions.Add(sortName);
            UsersCollectionView.SortDescriptions.Add(sortSurname);
            UsersCollectionView.Refresh();
        }

        //команда добваления пользователя в список

        private RelayCommand adUser;
        public RelayCommand AdUser
        {
            get
            {
                return adUser ??
                 (adUser = new RelayCommand(obj =>
                 {
                     WindowNewUser wnUser = new WindowNewUser
                     {
                         Title = "Новый пользователь",
                     };

                     // формирование кода новой должности
                     int maxIdUser = MaxIdUsers() + 1;
                     Users user = new Users { userId = maxIdUser };

                     wnUser.DataContext = user;
                     if (wnUser.ShowDialog() == true)
                     {
                         _usList.Add(user);

                         AddUser(user);

                     }
                     SelectedUser = user;

                     UsersCollectionView.Refresh();

                 }));
            }
        }

        //команда изменения выбранного пользователя в списке

        private RelayCommand editUser;
        public RelayCommand EditUser
        {
            get
            {
                return editUser ??
                (editUser = new RelayCommand(obj =>
                {
                    WindowNewUser wnUser = new WindowNewUser
                    { Title = "Редактирование пользователя" };

                    Users user = SelectedUser;
                    Users tempUser = new Users();

                    tempUser = user.ShallowCopy();
                    wnUser.DataContext = tempUser;
                    if (wnUser.ShowDialog() == true)
                    {
                        // сохранение данных в оперативной памяти
                        user.NameUser = tempUser.NameUser;
                        user.SurnameUser = tempUser.SurnameUser;
                        user.SeriesPassport = tempUser.SeriesPassport;
                        user.NumberPassport = tempUser.NumberPassport;
                        //SaveChangesJson(_usersList);

                        db.Users.Update(user);
                        db.SaveChanges();

                        UsersCollectionView.Refresh();
                        LoadUsers();


                    }
                }, (obj) => SelectedUser != null && _usList.Count > 0));
            }
        }


        //команда удаления выбранного пользователя из списка

        private RelayCommand deleteUser;
        public RelayCommand DeleteUser
        {
            get
            {
                return deleteUser ??
                (deleteUser = new RelayCommand(obj =>
                {
                    Users users = SelectedUser;
                    MessageBoxResult result = MessageBox.Show("Удалить данные по пользователю: " + users.userId, "Предупреждение",
                        MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        _usList.Remove(users);

                        RemoveUser(users);
                        LoadUsers();
                        db.SaveChanges();
                        UsersCollectionView.Refresh();
                    }
                }, (obj) => SelectedUser != null && _usList.Count > 0));
            }
        }

        //функция добавления пользователя в таблицу базы данных и обновление данных граф. списка
        public void AddUser(Users user)
        {

            db.Users.Add(user);
            db.SaveChanges();
            LoadUsers(); // Обновляем список пользователей после добавления нового пользователя

        }

        //функция удаления выбранного пользователя из списка таблицы базы данных и обновление данных граф. списка
        public void RemoveUser(Users user)
        {

            db.Users.Remove(user);
        }

        //функция обновления списка пользователей из списка таблицы базы данных и обновление данных граф. списка
        public void UpdateUser(Users user)
        {

            LoadUsers();
        }

        private void LoadUsers()
        {
            _usList = new ObservableCollection<Users>(db.Users);
        }

        
        #endregion DBmethods



        #region Weapons

        private Weapons _selectedWeapon;
        internal Weapons SelectedWeapon
        {
            get { return _selectedWeapon; }
            set
            {
                _selectedWeapon = value;
                OnPropertyChanged("SelectedWeapon");
            }
        }

        private void SortWeaponsAscending(object parameter)
        {
            // Определение критериев сортировки
            SortDescription sortName = new SortDescription("WeaponName", ListSortDirection.Ascending);

            // Применение критериев сортировки к представлению данных
            WeaponsCollectionView.SortDescriptions.Clear();
            WeaponsCollectionView.SortDescriptions.Add(sortName);
            WeaponsCollectionView.Refresh();
        }

        private void SortWeaponsDescending(object parameter)
        {
            // Определение критериев сортировки
            SortDescription sortName = new SortDescription("WeaponName", ListSortDirection.Descending);

            // Применение критериев сортировки к представлению данных
            WeaponsCollectionView.SortDescriptions.Clear();
            WeaponsCollectionView.SortDescriptions.Add(sortName);
            WeaponsCollectionView.Refresh();
        }

        #endregion


        #region FullOrders

        #region VIEWmethods

        private Weapons_Equipments_Consumable_OrdersDPO _selectedFullOrderDPO;
        public Weapons_Equipments_Consumable_OrdersDPO SelectedFullOrderDPO
        {
            get { return _selectedFullOrderDPO; }
            set
            {
                _selectedFullOrderDPO = value;
                OnPropertyChanged("SelectedFullOrderDPO");
                EditFullOrder.CanExecute(true);
            }
        }


        public int MaxIdFullOrders()
        {
            int max = 0;
            foreach (var u in this._fullorderList)
            {
                if (max < u.weaponsEquipmentsConsumablesOrdersId)
                {
                    max = u.weaponsEquipmentsConsumablesOrdersId;
                };
            }
            return max;
        }




        private RelayCommand adFullOrder;
        public RelayCommand AdFullOrder
        {
            get
            {
                return adFullOrder ??
                 (adFullOrder = new RelayCommand(obj =>
                 {
                     WindowNewOrder wnFullOrder = new WindowNewOrder
                     {
                         Title = "Новый заказ",
                     };

                     // формирование кода новой должности
                     int maxIdFullOrder = MaxIdFullOrders() + 1;
                     Weapons_Equipments_Consumable_OrdersDPO fullorderDPO = new Weapons_Equipments_Consumable_OrdersDPO
                     {
                         weaponsEquipmentsConsumablesOrdersId = maxIdFullOrder
                     };

                     wnFullOrder.DataContext = fullorderDPO;

                     vmMain = new MainViewModel();
                     weaponss = vmMain._weaponList.ToList();
                     wnFullOrder.CbWeapon.ItemsSource = weaponss;
                     consumabless = vmMain._consList.ToList();
                     wnFullOrder.CbConsumable.ItemsSource = consumabless;
                     equipmentss = vmMain._equipList.ToList();
                     wnFullOrder.CbEquipment.ItemsSource = equipmentss;
                     orderss = vmMain._shortordersList.ToList();
                     wnFullOrder.CbOrder.ItemsSource = orderss;


                     if (wnFullOrder.ShowDialog() == true)
                     {
                         // Получаем выбранное оружие из ComboBox
                         Weapons selectedWeapon = (Weapons)wnFullOrder.CbWeapon.SelectedItem;
                         Consumables selectedConsumable = (Consumables)wnFullOrder.CbConsumable.SelectedItem;
                         Equipments selectedEquipment = (Equipments)wnFullOrder.CbEquipment.SelectedItem;
                         // Устанавливаем ID выбранного оружия вместо его названия
                         fullorderDPO.WeaponId = selectedWeapon.weaponId;
                         fullorderDPO.ConsumableId = selectedConsumable.consumableId;
                         fullorderDPO.EquipmentId = selectedEquipment.equipmentId;

                         _fullorderList.Add(fullorderDPO);

                         AddFullOrder(fullorderDPO);

                     }
                     SelectedFullOrderDPO = fullorderDPO;

                     FullOrdersCollectionView.Refresh();

                 }));
            }
        }



        private RelayCommand editFullOrder;
        public RelayCommand EditFullOrder
        {
            get
            {
                return editFullOrder ??
                (editFullOrder = new RelayCommand(obj =>
                {
                    WindowNewOrder wnFullOrder = new WindowNewOrder
                    { Title = "Редактирование заказа" };

                    Weapons_Equipments_Consumable_OrdersDPO fullorderDPO = SelectedFullOrderDPO;
                    Weapons_Equipments_Consumable_OrdersDPO tempFullOrder = new Weapons_Equipments_Consumable_OrdersDPO();

                    tempFullOrder = fullorderDPO.ShallowCopy();
                    wnFullOrder.DataContext = tempFullOrder;

                    vmMain = new MainViewModel();
                    weaponss = vmMain._weaponList.ToList();
                    wnFullOrder.CbWeapon.ItemsSource = weaponss;
                    consumabless = vmMain._consList.ToList();
                    wnFullOrder.CbConsumable.ItemsSource = consumabless;
                    equipmentss = vmMain._equipList.ToList();
                    wnFullOrder.CbEquipment.ItemsSource = equipmentss;
                    orderss = vmMain._shortordersList.ToList();
                    wnFullOrder.CbOrder.ItemsSource = orderss;

                    if (wnFullOrder.ShowDialog() == true)
                    {
                        Weapons w = (Weapons)wnFullOrder.CbWeapon.SelectedValue;
                        Consumables c = (Consumables)wnFullOrder.CbConsumable.SelectedValue;
                        Equipments e = (Equipments)wnFullOrder.CbEquipment.SelectedValue;
                        Orders o = (Orders)wnFullOrder.CbOrder.SelectedValue;
                        if (w != null & e != null & c != null & o != null) 
                        {
                            fullorderDPO.WeaponName = w.WeaponName;
                            fullorderDPO.EquipmentName = e.EquipmentName;
                            fullorderDPO.ConsumableName = c.ConsumableName;
                            fullorderDPO.OrderId = o.orderId;
                        }
                        // сохранение данных в оперативной памяти
                        FindFullOrders finder = new FindFullOrders(fullorderDPO.weaponsEquipmentsConsumablesOrdersId);

                        List<Weapons_Equipments_Consumables_Orders> listFullOrder = _fullordersnoList.ToList();
                        Weapons_Equipments_Consumables_Orders? nw = listFullOrder.Find(new Predicate<Weapons_Equipments_Consumables_Orders>(finder.FullOrdersPredicate));

                        Weapons selectedWeapon = (Weapons)wnFullOrder.CbWeapon.SelectedItem;
                        Consumables selectedConsumable = (Consumables)wnFullOrder.CbConsumable.SelectedItem;
                        Equipments selectedEquipment = (Equipments)wnFullOrder.CbEquipment.SelectedItem;
                        // Устанавливаем ID выбранного оружия вместо его названия
                        fullorderDPO.WeaponId = selectedWeapon.weaponId;
                        fullorderDPO.ConsumableId = selectedConsumable.consumableId;
                        fullorderDPO.EquipmentId = selectedEquipment.equipmentId;

                        db.Weapons_Equipments_Consumables_Orders.Update(fullorderDPO);
                        db.SaveChanges();

                        FullOrdersCollectionView.Refresh();
                        UpdateFullOrder();

                    }
                }, (obj) => SelectedFullOrderDPO != null && _fullorderList.Count > 0));
            }
        }

        private RelayCommand deleteFullOrder;
        public RelayCommand DeleteFullOrder
        {
            get
            {
                return deleteFullOrder ??
                (deleteFullOrder = new RelayCommand(obj =>
                {
                    Weapons_Equipments_Consumable_OrdersDPO fullorders = SelectedFullOrderDPO;
                    MessageBoxResult result = MessageBox.Show("Удалить данные по заказу: " + fullorders.weaponsEquipmentsConsumablesOrdersId, "Предупреждение",
                        MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        _fullorderList.Remove(fullorders);

                        RemoveFullOrder(fullorders);
                        LoadFullOrders();
                        FullOrdersCollectionView.Refresh();
                    }
                }, (obj) => SelectedFullOrderDPO != null && _fullorderList.Count > 0));
            }
        }
        #endregion

        #region DBmethods
        public void AddFullOrder(Weapons_Equipments_Consumable_OrdersDPO fullorder)
        {

            db.Weapons_Equipments_Consumables_Orders.AddRange(fullorder);
            db.SaveChanges();
            LoadFullOrders(); // Обновляем список пользователей после добавления нового пользователя

        }

        public void RemoveFullOrder(Weapons_Equipments_Consumable_OrdersDPO fullorder)
        {

            db.Weapons_Equipments_Consumables_Orders.Remove(fullorder);
            db.SaveChanges();
        }

        public void UpdateFullOrder()
        {

            LoadFullOrders();
        }

        private void LoadFullOrders()
        {
            _fullorderList = new ObservableCollection<Weapons_Equipments_Consumable_OrdersDPO>(db.Weapons_Equipments_Consumables_Orders);
        }
        #endregion DBmethods

        #endregion

        #region ShortOrders
        #endregion

        #region Consumables

        private Consumables _selectedConsumable;
        internal Consumables SelectedConsumable
        {
            get { return _selectedConsumable; }
            set
            {
                _selectedConsumable = value;
                OnPropertyChanged("SelectedConsumable");
            }
        }

        private void SortConsumablesAscending(object parameter)
        {
            // Определение критериев сортировки
            SortDescription sortName = new SortDescription("ConsumableName", ListSortDirection.Ascending);

            // Применение критериев сортировки к представлению данных
            ConsumablesCollectionView.SortDescriptions.Clear();
            ConsumablesCollectionView.SortDescriptions.Add(sortName);
            ConsumablesCollectionView.Refresh();
        }

        private void SortConsumablesDescending(object parameter)
        {
            // Определение критериев сортировки
            SortDescription sortName = new SortDescription("ConsumableName", ListSortDirection.Descending);

            // Применение критериев сортировки к представлению данных
            ConsumablesCollectionView.SortDescriptions.Clear();
            ConsumablesCollectionView.SortDescriptions.Add(sortName);
            ConsumablesCollectionView.Refresh();
        }

        #endregion

        #region Equipments

        private Equipments _selectedEquipment;
        internal Equipments SelectedEquipment
        {
            get { return _selectedEquipment; }
            set
            {
                _selectedEquipment = value;
                OnPropertyChanged("SelectedEquipment");
            }
        }

        private void SortEquipmentsAscending(object parameter)
        {
            // Определение критериев сортировки
            SortDescription sortName = new SortDescription("EquipmentName", ListSortDirection.Ascending);

            // Применение критериев сортировки к представлению данных
            EquipmentsCollectionView.SortDescriptions.Clear();
            EquipmentsCollectionView.SortDescriptions.Add(sortName);
            EquipmentsCollectionView.Refresh();
        }

        private void SortEquipmentsDescending(object parameter)
        {
            // Определение критериев сортировки
            SortDescription sortName = new SortDescription("EquipmentName", ListSortDirection.Descending);

            // Применение критериев сортировки к представлению данных
            EquipmentsCollectionView.SortDescriptions.Clear();
            EquipmentsCollectionView.SortDescriptions.Add(sortName);
            EquipmentsCollectionView.Refresh();
        }

        #endregion

        

        //методы для ТЕСТОВ
        #region Tests 

        public bool UserAdd(Users user)
        {
            
            
            _usList.Add(user);
            try
            {
                AddUser(user);
            }
            catch
            {
                return false;
            }
            return true;
        }
        
        public bool UserEdit(Users user, string surname)
        {
            try
            {
                if (_usList.Contains(user))
                {
                    user.SurnameUser = surname;
                    _usList.Remove(user);
                    _usList.Add(user);
                }
            }
            catch
            {
                return false; // false при ошибке
            }
            return true;

        }

        public double AddOrderPrice(Weapons_Equipments_Consumable_OrdersDPO order, Users user, Consumables consumable, Weapons weapon, Equipments equipment, Orders orderr)
        {

            db.Users.Add(user);
            db.Weapons.Add(weapon);
            db.Consumables.Add(consumable);
            db.Equipments.Add(equipment);
            db.Orders.Add(orderr);
            db.Weapons_Equipments_Consumables_Orders.Add(order);
            db.SaveChanges();


                // Получаем данные из базы данных
                var orderPrice = (from ord in db.Orders
                                          select ord.TariffPrice).FirstOrDefault();
                var consumPrice = (from consum in db.Consumables
                                   where consum.ConsumableName == order.ConsumableName
                                   select consum.ConsumablePrice).FirstOrDefault();
                var weaponPrice = (from weap in db.Weapons
                                   where weap.WeaponName == order.WeaponName
                                   select weap.WeaponPrice).FirstOrDefault();
                var equipmentPrice = (from equip in db.Equipments
                                      where equip.EquipmentName == order.EquipmentName
                                      select equip.EquipmentPrice).FirstOrDefault();
                var countBalls = (from ord in db.Orders
                                  where ord.orderId == order.OrderId
                                  select ord.CountBalls).FirstOrDefault();

                double priceOneBall = 3;
                var priceBalls = priceOneBall * countBalls;

                // Расчет полной стоимости заказа
                double fullPrice = weaponPrice + equipmentPrice + consumPrice + priceBalls + orderPrice;
                return fullPrice;
            
        }
        #endregion
        
    }
}