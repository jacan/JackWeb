﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace JackWeb.Framework.Environment.Orm.Codefirst
{
	public class NCascadeConvention : IReferenceConvention, IHasManyConvention, IHasManyToManyConvention
	{
		public void Apply(IManyToOneInstance instance)
		{
			instance.Cascade.All();
		}

		public void Apply(IOneToManyCollectionInstance instance)
		{
			instance.Cascade.All();
		}

		public void Apply(IManyToManyCollectionInstance instance)
		{
			instance.Cascade.All();
		}
	}
}
