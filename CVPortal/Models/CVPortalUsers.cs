using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CVPortal.Models
{
    public class CVPortalUsers
    {
		public long CVPortalUsersId { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter User Name")]
		[Display(Name = "User Name")]
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

		[Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Confirmed Password")]
		[Display(Name = "Confirmed Password")]
		[DataType(DataType.Password)]
		[Compare("UserPassword", ErrorMessage = "Password and Confirmed Password should be same!")]
		public string UserRePassword { get; set; }

		public int IsActive { get; set; }
		public Nullable<DateTime> CreateDate { get; set; }
        public string SuccessMessage { get; set; }
		public string ErrorMessage { get; set; }
	}
}