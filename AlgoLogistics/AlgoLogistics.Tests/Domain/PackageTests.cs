using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Tests.Domain
{
	public class PackageTests
	{
		[Test]
		public void CreatedPackage_IsLightAndSmall_WihthGivenParameters()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(0.2, 0.2, 0.2, 2),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(WeightCategory.Light, package.WeightCategory);
			Assert.AreEqual(SizeCategory.Small, package.SizeCategory);
		}

		[Test]
		public void CreatedPackage_IsMediumSizeAndMediumWeight_WihthGivenParameters()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(0.2, 0.3, 0.5, 6),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(WeightCategory.Medium, package.WeightCategory);
			Assert.AreEqual(SizeCategory.Medium, package.SizeCategory);
		}

		[Test]
		public void CreatedPackage_IsHeavyAndLarge_WihthGivenParameters()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(0.8, 0.5, 0.5, 20),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(WeightCategory.Heavy, package.WeightCategory);
			Assert.AreEqual(SizeCategory.Large, package.SizeCategory);
		}

		[Test]
		public void CreatedPackage_IsHeavyAndExtraLarge_WihthGivenParameters()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(1.1, 0.5, 0.5, 20),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(WeightCategory.Heavy, package.WeightCategory);
			Assert.AreEqual(SizeCategory.ExtraLarge, package.SizeCategory);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs20_WhenSmallAndLight()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(0.1, 0.2, 0.1, 2),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(20, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs25_WhenSmallAndMedium()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(0.1, 0.2, 0.1, 6),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(25, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs30_WhenSmallAndHeavy()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(0.1, 0.2, 0.1, 16),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(30, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs25_WhenMediumSizeAndLight()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(0.4, 0.2, 0.1, 3),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(25, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs30_WhenMediumSizeAndMediumWeight()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(0.4, 0.2, 0.1, 8),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(30, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs35_WhenMediumSizeAndHeavy()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(0.4, 0.2, 0.1, 20),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(35, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs30_WhenLargeAndLight()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(0.4, 0.8, 0.1, 3),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(30, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs35_WhenLargeAndMediumWeight()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(0.4, 0.8, 0.1, 7),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(35, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs40_WhenLargeAndHeavy()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(1, 0.8, 0.4, 18),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(40, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs35_WhenExtraLargeAndLight()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(1, 1.1, 0.4, 5),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(35, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs40_WhenExtraLargeAndMediumWeight()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(1, 1.1, 0.4, 10),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(40, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryPriceIs45_WhenExtraLargeAndHeavy()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(1, 1.1, 0.4, 19),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(45, package.DeliveryPrice);
		}

		[Test]
		public void CreatedPackage_DeliveryStatusIsNotSent_WithGivenParameters()
		{
			var package = new Package(
				"desc",
				120,
				new PhysicalParameters(1, 1.1, 0.4, 19),
				new DeliveryDetails("sender", "receiver", "Lviv", "Kyiv"));

			Assert.AreEqual(DeliveryStatus.NotSent, package.Status);
		}
	}
}
