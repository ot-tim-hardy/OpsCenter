using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsCenter.Models {
	public class Configuration : BaseEntity {
		public string Environment { get; set; }
		public string ConfigKey { get; set; }
		public string Value { get; set; }
	}
}