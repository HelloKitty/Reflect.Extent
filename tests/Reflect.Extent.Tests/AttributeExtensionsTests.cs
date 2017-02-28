using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Reflect.Extent.Tests
{
	[TestFixture]
	public class AttributeExtensionsTests
	{
		[Test]
		public void Test_HasAttribute_Sees_Same_Type_Attribute()
		{
			//arrange
			MemberInfo member = typeof(TestAttributeClass).GetMember("TestField").First();

			//act
			bool result = member.HasAttribute<TestAttribute1>();

			//assert
			Assert.IsTrue(result);
		}

		[Test]
		public void Test_HasAttribute_Doesnt_See_Unmarked_Attribute()
		{
			//arrange
			MemberInfo member = typeof(TestAttributeClass).GetMember("TestField").First();

			//act
			bool result = member.HasAttribute<ApartmentAttribute>();

			//assert
			Assert.IsFalse(result);
		}

		[Test]
		public void Test_HasAttribute_Can_See_Derived_From_Base()
		{
			//arrange
			MemberInfo member = typeof(TestAttributeClass).GetMember("TestProp").First();

			//act
			bool result = member.HasAttribute<TestAttribute1>();

			//assert
			Assert.True(result);
		}

		public class TestAttribute1 : Attribute
		{
			
		}

		public class TestAttribute2 : TestAttribute1
		{
			
		}

		[TestAttribute1]
		public class TestAttributeClass
		{
			[TestAttribute1]
			public int TestField;

			[TestAttribute2]
			public double TestProp { get; }
		}
	}
}
