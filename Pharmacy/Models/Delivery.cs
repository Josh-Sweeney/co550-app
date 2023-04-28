using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Models;

public class Delivery
{
	[Key]
	public Guid DeliveryId { get; set; }

	[ForeignKey("PrescriptionId")]
	public Guid PrescriptionId { get; set; }

	[ForeignKey("PatientId")]
	public Guid PatientId { get; set; }

	
	public Prescription Prescription { get; set; }

	public Patient Patient { get; set; }
}