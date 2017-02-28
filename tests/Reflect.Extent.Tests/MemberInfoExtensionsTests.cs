using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Reflect.Extent.Tests
{
	[TestFixture]
	public class MemberInfoExtensionsTests
	{
		[Test]
		public void Test_Type_Grabbing_Extension_Throws_On_Null()
		{
			//arrange
			MemberInfo m = null;

			//assert
			Assert.Throws<ArgumentNullException>(() => m.Type());
		}

		[Test]
		[TestCase("TestField", typeof(int))]
		[TestCase("TestProp", typeof(string))]
		[TestCase("TestMethod", typeof(double))]
		public void Test_Type_Grabbing_Extension_Reads_Correct_Type(string memberName, Type expectedType)
		{
			//arrange
			MemberInfo m = typeof(TestReflectedClass).GetMember(memberName).First();

			//act
			Type resultType = m.Type();

			//assert
			Assert.AreEqual(expectedType, resultType);
		}

		public class TestReflectedClass
		{
			public int TestField;

			public string TestProp { get; }

			public double TestMethod()
			{
				return 0;
			}
		}
	}
}
