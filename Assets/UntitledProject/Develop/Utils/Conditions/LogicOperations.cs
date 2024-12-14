using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.UntitledProject.Develop.Utils.Conditions
{
	public static class LogicOperations
	{
		public static bool And(bool value1, bool value2) => value1 && value2;

		public static bool Or(bool value1, bool value2) => value1 || value2;
	}
}
