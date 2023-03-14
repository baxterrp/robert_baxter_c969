using Microsoft.Extensions.Logging;
using robert_baxter_c969.Data;
using robert_baxter_c969.Data.DataModels;
using robert_baxter_c969.Data.Models;
using robert_baxter_c969.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace robert_baxter_c969.Forms
{
    public partial class UserForm : BaseForm<UserForm>
    {
        public UserForm(
        IFormFactory formFactory,
        ILogger<UserForm> logger,
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

                City city = new City();

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
                    country = await _dataRepository.Insert(country);
                }

                // if no city was found, make one 
                if (city.Id == 0)
                {
                    city.Name = CityValue.Text;
                    city.CountryId = country.Id;

                    city = await _dataRepository.Insert(city);
                }

                // lets just always add the new address
                var address = new Address
                {
                    CityId = city.Id,
                    AddressLine1 = AddressLine1Value.Text,
                    AddressLine2 = AddressLine2Value.Text,
                    PhoneNumber = PhoneNumberValue.Text,
                    ZipCode = PostalCodeValue.Text,
                };

                address = await _dataRepository.Insert(address);

                // can safely add new customer now
                var customer = new Customer
                {
                    CustomerName = NameValue.Text,
                    AddressId = address.Id,
                    Active = true,
                };

                customer = await _dataRepository.Insert(customer);

                // success if new id generated
                return customer?.Id > 0;

            }, "Successfully saved new customer", "Failed to save new customer");

            Close();
        }
    }
}
