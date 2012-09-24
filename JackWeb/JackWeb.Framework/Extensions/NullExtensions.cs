using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackWeb.Framework.Extensions
{
	public static class NullExtensions
	{
		public static bool IsNull(this object theObject)
		{
			return theObject == null;
		}

		public static bool IsNotNull(this object theObject)
		{
			return theObject != null;
		}
	}
}
