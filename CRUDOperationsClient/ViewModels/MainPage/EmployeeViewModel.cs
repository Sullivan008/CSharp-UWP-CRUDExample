using CRUDOperationsClient.Command;
using CRUDOperationsClient.DBServiceOperations;
using CRUDOperationsClient.Dialogs;
using System;
using System.ServiceModel;
using System.Windows.Input;

namespace CRUDOperationsClient.ViewModels.MainPage
{
    public class EmployeeViewModel : MainPageViewModelBase
    {
        private int? _id;
        private int? _searchId;
        private int? _age;
        private string _name;
        private string _email;

        private bool _enableInsertBtn;
        private bool _enableUpdateBtn;
        private bool _enableDeleteBtn;
        private bool _enableSearchByIdBtn;

        public EmployeeViewModel()
        {
            ClearInputProperties();
        }

        #region PROPERTIES Getters/ Setters

        public int? Id
        {
            get => _id;
            set
            {
                _id = value;
                EnableDeleteBtn = true;

                OnPropertyChanged("Id");
            }
        }

        public int? SearchId
        {
            get => _searchId;
            set
            {
                _searchId = value;
                EnableSearchByIdBtn = true;
                OnPropertyChanged("SearchId");
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;

                EnableInsertBtn = RequiredFieldsAreCompleted();
                EnableUpdateBtn = _id != null && RequiredFieldsAreCompleted();

                OnPropertyChanged("Name");
            }
        }

        public int? Age
        {
            get => _age;
            set
            {
                _age = value;

                EnableInsertBtn = RequiredFieldsAreCompleted();
                EnableUpdateBtn = _id != null && RequiredFieldsAreCompleted();

                OnPropertyChanged("Age");
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;

                EnableInsertBtn = RequiredFieldsAreCompleted();
                EnableUpdateBtn = _id != null && RequiredFieldsAreCompleted();

                OnPropertyChanged("Email");
            }
        }

        #endregion

        #region BTN Properties Getters/ Setters

        public bool EnableInsertBtn
        {
            get => _enableInsertBtn;
            set
            {
                _enableInsertBtn = value;
                OnPropertyChanged("EnableInsertBtn");
            }
        }

        public bool EnableUpdateBtn
        {
            get => _enableUpdateBtn;
            set
            {
                _enableUpdateBtn = value;
                OnPropertyChanged("EnableUpdateBtn");
            }
        }

        public bool EnableDeleteBtn
        {
            get => _enableDeleteBtn;
            set
            {
                _enableDeleteBtn = value;
                OnPropertyChanged("EnableDeleteBtn");
            }
        }

        public bool EnableSearchByIdBtn
        {
            get => _enableSearchByIdBtn;
            set
            {
                _enableSearchByIdBtn = value;
                OnPropertyChanged("EnableSearchByIdBtn");
            }
        }

        #endregion

        #region COMMANDS

        public ICommand InsertBtnClick =>
            new DelegateCommand(InsertEmployee);

        public ICommand UpdateBtnClick =>
            new DelegateCommand(UpdateEmployee);

        public ICommand DeleteBtnClick =>
            new DelegateCommand(DeleteEmployee);

        public ICommand SearchByIdBtnClick =>
            new DelegateCommand(SearchById);

        #endregion

        #region PRIVATE COMMAND Helper Methods

        private async void InsertEmployee()
        {
            try
            {
                using (DBServiceClient service = new DBServiceClient())
                {
                    if (await service.InsertEmployeeAsync(CreateInsertEmployeeDto()))
                    {
                        await new NotificationDialog("INSERT Successful",
                            "Information").ShowDialog().ShowAsync();

                        ClearInputProperties();
                    }

                    await service.CloseAsync();
                }
            }
            catch (CommunicationException)
            {
                await ServiceUnavailableNotification().ShowDialog().ShowAsync();
            }
        }

        private async void UpdateEmployee()
        {
            try
            {
                using (DBServiceClient service = new DBServiceClient())
                {
                    if (await service.UpdateEmployeeAsync(CreateUpdateEmployeeDto()))
                    {
                        await new NotificationDialog("UPDATE Successful",
                            "Information").ShowDialog().ShowAsync();

                        ClearInputProperties();
                    }

                    await service.CloseAsync();
                }
            }
            catch (CommunicationException)
            {
                await ServiceUnavailableNotification().ShowDialog().ShowAsync();
            }
        }

        private async void DeleteEmployee()
        {
            try
            {
                using (DBServiceClient service = new DBServiceClient())
                {
                    if (await service.DeleteEmployeeAsync(_id ?? throw new ArgumentNullException(nameof(_id))))
                    {
                        await new NotificationDialog("DELETE Successful",
                            "Information").ShowDialog().ShowAsync();

                        ClearInputProperties();
                    }

                    await service.CloseAsync();
                }
            }
            catch (CommunicationException)
            {
                await ServiceUnavailableNotification().ShowDialog().ShowAsync();
            }
        }

        private async void SearchById()
        {
            try
            {
                using (DBServiceClient service = new DBServiceClient())
                {
                    EmployeeDto searchedEmployeeDto =
                        await service.SelectOneEmployeeAsync(_searchId ?? throw new ArgumentNullException(nameof(_searchId)));

                    if (searchedEmployeeDto.Id == 0)
                    {
                        await new NotificationDialog("Error! No such ID exists in the database!",
                            "Information").ShowDialog().ShowAsync();

                        ClearInputProperties();
                    }
                    else
                    {
                        Id = SearchId;
                        Name = searchedEmployeeDto.Name;
                        Age = searchedEmployeeDto.Age;
                        Email = searchedEmployeeDto.Email;
                    }

                    await service.CloseAsync();
                }
            }
            catch (CommunicationException)
            {
                await ServiceUnavailableNotification().ShowDialog().ShowAsync();
            }
        }

        #endregion

        #region PRIVATE Helper Methods

        private static NotificationDialog ServiceUnavailableNotification()
        {
            return new NotificationDialog("Service unavailable. Please contact the IT Operator!",
                "Error");
        }

        private bool RequiredFieldsAreCompleted()
        {
            return _name != null && _age != null && _email != null;
        }

        private void ClearInputProperties()
        {
            Id = null;
            SearchId = null;
            Name = null;
            Age = null;
            Email = null;
        }

        private EmployeeDto CreateInsertEmployeeDto() => new EmployeeDto
        {
            Name = _name,
            Age = _age ?? throw new ArgumentNullException(nameof(_age)),
            Email = _email
        };

        private EmployeeDto CreateUpdateEmployeeDto() => new EmployeeDto
        {
            Id = _id ?? throw new ArgumentNullException(nameof(_id)),
            Name = _name,
            Age = _age ?? throw new ArgumentNullException(nameof(_age)),
            Email = _email
        };

        #endregion
    }
}