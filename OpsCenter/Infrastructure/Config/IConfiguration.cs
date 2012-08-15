using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsCenter.Infrastructure.Config {
	public interface IConfiguration {
		string Get(string key);
	}
}