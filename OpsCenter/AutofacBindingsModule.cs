using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using OpsCenter.Models;

namespace OpsCenter {
	public class AutofacBindingsModule : Module {
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(c => new OpsCenterDB()).As<IDatastore>();
		}
	}

}