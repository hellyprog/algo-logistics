using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Infrastructure.Persistence.DefaultData
{
	public static class DefaultDataProvider
	{
		public static List<City> GetCities()
		{
			return new List<City>
			{
				new City { CityId = 1, Name = "Lviv", Country = "Ukraine" },
				new City { CityId = 2, Name = "Uzgorod", Country = "Ukraine" },
				new City { CityId = 3, Name = "Lutsk", Country = "Ukraine" },
				new City { CityId = 4, Name = "Rivne", Country = "Ukraine" },
				new City { CityId = 5, Name = "Ternopil", Country = "Ukraine" },
				new City { CityId = 6, Name = "Ivano-Frankivsk", Country = "Ukraine" },
				new City { CityId = 7, Name = "Chernivtsi", Country = "Ukraine" },
				new City { CityId = 8, Name = "Zhytomyr", Country = "Ukraine" },
				new City { CityId = 9, Name = "Khmelnytskyi", Country = "Ukraine" },
				new City { CityId = 10, Name = "Vinnytsia", Country = "Ukraine" }
			};
		}

		public static List<PackageCategory> GetPackageCategories()
		{
			return new List<PackageCategory>
			{
				new PackageCategory
					{
						PackageCategoryId = 1,
						SizeCategory = SizeCategory.ExtraSmall,
						Length = 0.2,
						Width = 0.15,
						Height = 0.05
					},
					new PackageCategory
					{
						PackageCategoryId = 2,
						SizeCategory = SizeCategory.Small,
						Length = 0.3,
						Width = 0.2,
						Height = 0.1
					},
					new PackageCategory
					{
						PackageCategoryId = 3,
						SizeCategory = SizeCategory.Medium,
						Length = 0.3,
						Width = 0.3,
						Height = 0.2
					},
					new PackageCategory
					{
						PackageCategoryId = 4,
						SizeCategory = SizeCategory.Large,
						Length = 0.4,
						Width = 0.3,
						Height = 0.3
					},
					new PackageCategory
					{
						PackageCategoryId = 5,
						SizeCategory = SizeCategory.ExtraLarge,
						Length = 0.45,
						Width = 0.3,
						Height = 0.3
					}
			};
		}

		public static List<ApplicationConfig> GetApplicationConfigs()
		{
			return new List<ApplicationConfig>
			{
				new ApplicationConfig
				{
					ApplicationConfigId = 1,
					ConfigName = "BaseDeliveryPrice",
					ConfigValue = "20"
				}
			};
		}
	}
}
