using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CVPortal.Models
{
    public class CVPortalLogin
    {
		public long CVPortalUsersId { get; set; }
		public string UserName { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter User Email")]
		[Display(Name = "User Email")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress(ErrorMessage = "Invalid Email Address!")]
		public string UserEmail { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Password")]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string UserPassword { get; set; }
		public int IsActive { get; set; }
		public Nullable<DateTime> CreateDate { get; set; }
		public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
	}
}