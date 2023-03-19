using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.Data.DataModels;
using robert_baxter_c969.Data.Models;
using robert_baxter_c969.Data.ViewModels;
using robert_baxter_c969.DependencyInjection;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace robert_baxter_c969.Forms
{
    public partial class CustomerForm : BaseForm<CustomerForm>
    {
        public CustomerViewModel SelectedCustomer { get; set; }

        public CustomerForm(
        IFormFactory formFactory,
        ILogger<CustomerForm> logger,
            IDataRepository dataRepository) : base(logger, dataRepository, formFactory)
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private async void SaveButton_Click(object sender, System.EventArgs e)
        {
            var requiredFields = new List<string>
            {
                nameof(NameValue), nameof(AddressLine1Value), nameof(CityValue), nameof(PhoneNumberValue), nameof(CountryValue), nameof(PostalCodeValue)
            };

            var hasErrors = false;

            foreach(var field in requiredFields)
            {
                hasErrors |= ValidateField(field);
            }

            if (hasErrors) { return; }

            await SaveCustomer();
            Close();
        }

        private async Task SaveCustomer()
        {
            await ExecuteAsync(async () =>
            {
                // check if country exists already
                var country = (await _dataRepository.Get<Country>(new Dictionary<string, string>
                {
                    { nameof(Country.Name), CountryValue.Text },
                }))?.FirstOrDefault() ?? new Country
                {
                    Name = CountryValue.Text,
                };

                var city = new City();

                if (country.Id > 0)
                {
                    // check if city already exists in this country
                    var cities = await _dataRepository.Get<City>(new Dictionary<string, string>
                    {
                        { nameof(City.CountryId), country.Id.ToString() },
                    });

                    city = cities.FirstOrDefault(c => c.Name.ToLower() == CityValue.Text.ToLower()) ?? new City
                    {
                        CountryId = country.Id,
                        Name = CityValue.Text
                    };
                }
                else
                {
                    // if no country found, add one
                    _logger.LogInformation("No country found by the name of {country}, adding...", country.Name);
                    country = await _dataRepository.Insert(country);
                }

                // if no city was found, add one 
                if (city.Id == 0)
                {
                    city.Name = CityValue.Text;
                    city.CountryId = country.Id;

                    _logger.LogInformation("No city found by the name of {city}, adding...", city.Name);
                    city = await _dataRepository.Insert(city);
                }

                // find customer if it exists
                var customer = SelectedCustomer is null ? new Customer() : await _dataRepository.GetById<Customer>(SelectedCustomer.Id);

                var address = await _dataRepository.GetById<Address>(customer.Id) ?? new Address();
                address.CityId = city.Id;
                address.AddressLine1 = AddressLine1Value.Text;
                address.AddressLine2 = AddressLine2Value.Text;
                address.PhoneNumber = PhoneNumberValue.Text;
                address.ZipCode = PostalCodeValue.Text;

                address = address.Id > 0 ? await _dataRepository.Update(address) : await _dataRepository.Insert(address);

                // can safely add or update customer now
                customer.CustomerName = NameValue.Text;
                customer.AddressId = address.Id;
                customer.Active = true;

                _logger.LogInformation("Saving customer with name {name}", customer.CustomerName);
                customer = customer.Id > 0 ? await _dataRepository.Update(customer) : await _dataRepository.Insert(customer);

                // success if new id generated
                return customer?.Id > 0;

            }, "Successfully saved customer", "Failed to save customer");
        }

        private void LoadCustomerData(object sender, System.EventArgs e)
        {
            if (SelectedCustomer != null)
            {
                NameValue.Text = SelectedCustomer.Name;
                AddressLine1Value.Text = SelectedCustomer.AddressLine1;
                AddressLine2Value.Text = SelectedCustomer.AddressLine2;
                CityValue.Text = SelectedCustomer.City;
                PhoneNumberValue.Text = SelectedCustomer.PhoneNumber;
                CountryValue.Text = SelectedCustomer.Country;
                PostalCodeValue.Text = SelectedCustomer.ZipCode;
            }
        }

        private bool ValidateField(string fieldName)
        {
            var hasError = false;

            switch (fieldName)
            {
                case nameof(NameValue):
                    hasError = string.IsNullOrWhiteSpace(NameValue.Text);
                    NameValue.BackColor = hasError ? Color.Salmon : Color.White;
                    break;
                case nameof(AddressLine1Value):
                    hasError = string.IsNullOrWhiteSpace(AddressLine1Value.Text);
                    AddressLine1Value.BackColor = hasError ? Color.Salmon : Color.White;
                    break;
                case nameof(CityValue):
                    hasError = string.IsNullOrWhiteSpace(CityValue.Text);
                    CityValue.BackColor = hasError ? Color.Salmon : Color.White;
                    break;
                case nameof(PhoneNumberValue):
                    hasError = string.IsNullOrWhiteSpace(PhoneNumberValue.Text);
                    PhoneNumberValue.BackColor = hasError ? Color.Salmon : Color.White;
                    break;
                case nameof(CountryValue):
                    hasError = string.IsNullOrWhiteSpace(CountryValue.Text);
                    CountryValue.BackColor = hasError ? Color.Salmon : Color.White;
                    break;
                case nameof(PostalCodeValue):
                    hasError = string.IsNullOrWhiteSpace(PostalCodeValue.Text);
                    PostalCodeValue.BackColor = hasError ? Color.Salmon : Color.White;
                    break;
            }

            SaveButton.Enabled = !hasError;

            return hasError;
        }

        private void FieldFocusOut(object sender, System.EventArgs e)
        {
            var name = sender.GetType().GetProperty("Name").GetValue(sender, null).ToString();
            ValidateField(name);
        }
    }
}
