using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Models;

public class Prescription
{
	[Key]
	public Guid PrescriptionId { get; set; }

	[ForeignKey("PatientId")]
	public Guid PatientId { get; set; }

	public decimal TotalPrice { get; set; }

	
	public Patient Patient { get; set; }
}
