using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace OpsCenter.Infrastructure.Config {
	public class FileBasedConfig : IConfiguration {
		public string Get(string key) {
			return ConfigurationManager.AppSettings.Get(key);
		}
	}
}