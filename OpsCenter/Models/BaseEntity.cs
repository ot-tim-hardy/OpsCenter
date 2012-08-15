using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsCenter.Models {
	public class BaseEntity : IAuditable {
		public int ID { get; set; }
		public DateTime? Created { get; set; }
		public int? CreatedBy { get; set; }
		public DateTime? Updated { get; set; }
		public int? UpdatedBy { get; set; }
	}
}