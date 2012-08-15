using System;
using System.Collections.Generic;

namespace OpsCenter.Models {
	public class Environment : BaseEntity {
		public string Name { get; set; }
		public string Description { get; set; }
	}
}