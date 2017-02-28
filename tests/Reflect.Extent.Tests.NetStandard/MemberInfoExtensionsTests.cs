using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reflect.Extent.Tests
{
	[TestClass]
	public class MemberInfoExtensionsTests
	{
		[TestMethod]
		public void Test_Type_Grabbing_Extension_Throws_On_Null()
		{
			//arrange
			MemberInfo m = null;

			//assert
			Assert.ThrowsException<ArgumentNullException>(() => m.Type());
		}
	}
}
