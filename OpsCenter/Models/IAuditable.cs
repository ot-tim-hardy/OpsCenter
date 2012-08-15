﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpsCenter.Models {
	public interface IAuditable {
		DateTime? Created { get; set; }
		int? CreatedBy { get; set; }
		DateTime? Updated { get; set; }
		int? UpdatedBy { get; set; }
	}

	public static class AuditableImplementation {
		public static void AuditForCreate(this IAuditable entity, int? userID) {
			entity.Created = DateTime.Now;
			if (userID != null) {
				entity.CreatedBy = userID.Value;
			}
		}

		public static void AuditForUpdate(this IAuditable entity, int? userID) {
			entity.Updated = DateTime.Now;
			if (userID != null) {
				entity.UpdatedBy = userID.Value;
			}
		}
	}
}