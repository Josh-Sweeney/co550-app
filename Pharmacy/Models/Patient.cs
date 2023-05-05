using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Models;

public class Patient
{
	[Key]
	public Guid PatientId { get; set; }

	[Column("FullName")]
	[Display(Name = "Full Name")]
	[StringLength(100)]
	public string FullName { get; set; }

	[Column("DateOfBirth", TypeName = "date")]
	[Display(Name = "Date Of Birth")]
	public DateTime DateOfBirth { get; set; }

	[Column("Address")]
	[Display(Name = "Address")]
	[StringLength(100)]
	public string Address { get; set; }

	[Column("PhoneNumber")]
	[Display(Name = "Phone Number")]
	[StringLength(10)]
	public string PhoneNumber { get; set; }

	[Column("EmailAddress")]
	[Display(Name = "Email Address")]
	[StringLength(50)]
	public string EmailAddress { get; set; }
}
