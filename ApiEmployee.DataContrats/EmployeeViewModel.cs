using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEmployee.DataContrats
{
	[Table("employee")]
	public partial class EmployeeViewModel
	{
		public EmployeeViewModel()
		{
			//Bosses = new HashSet<EmployeeViewModel>();
		}
		[Key]
		[Column("pk_employee")]
		public long IdEmployee { get; set; }
		[Column("fullname")]
		public string FullName { get; set; }
		[Column("position")]
		public string Position {get;set;}
		[Column("fk_employee")]
		public long? IdBoss { get; set; }
		[Column("boss")]
		public bool IsBoss { get; set; }
		[Column("fhcreated")]
		public DateTime FHcreated { get; set; }
		//public ICollection<EmployeeViewModel> Bosses { get; set; }
	}
}
