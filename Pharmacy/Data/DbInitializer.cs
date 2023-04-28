using System;
using System.Linq;
using Pharmacy.Models;

namespace Pharmacy.Data;

public static class DbInitializer
{
	public static void Initialize(PharmacyContext context)
	{
		if (context.Patients.Any() || context.Prescriptions.Any() || context.Deliveries.Any())
			return;

		var patients = new Patient[]
		{
			new Patient
			{
				FullName = "John Doe",
				DateOfBirth = new DateTime(1980, 1, 1),
				Address = "123 Main St, Anytown, USA",
				PhoneNumber = "1234567890",
				EmailAddress = "johndoe@gmail.com"
			},
			new Patient
			{
				FullName = "Jane Doe",
				DateOfBirth = new DateTime(1980, 1, 1),
				Address = "123 Main St, Anytown, USA",
				PhoneNumber = "1234567890",
				EmailAddress = "janedoe@gmail.com"
			},
			new Patient
			{
				FullName = "John Smith",
				DateOfBirth = new DateTime(1980, 1, 1),
				Address = "123 Main St, Anytown, USA",
				PhoneNumber = "1234567890",
				EmailAddress = "johnsmith@gmail.com"
			}
		};

		context.AddRange(patients);

		var prescriptions = new Prescription[]
		{
			new Prescription
			{
				TotalPrice = 100.00m,
				Patient = patients[0]
			},
			new Prescription
			{
				TotalPrice = 200.00m,
				Patient = patients[1]
			},
			new Prescription
			{
				TotalPrice = 300.00m,
				Patient = patients[2]
			}
		};

		context.AddRange(prescriptions);

		var deliveries = new Delivery[]
		{
			new Delivery
			{
				Prescription = prescriptions[0],
				Patient = patients[0]
			},
			new Delivery
			{
				Prescription = prescriptions[1],
				Patient = patients[1]
			},
			new Delivery
			{
				Prescription = prescriptions[2],
				Patient = patients[2]
			}
		};

		context.AddRange(deliveries);
		context.SaveChanges();
	}
}