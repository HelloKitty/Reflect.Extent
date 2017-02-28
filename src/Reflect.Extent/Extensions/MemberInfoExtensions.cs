using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Reflect.Extent
{
	/// <summary>
	/// Extension methods for the <see cref="MemberInfo"/> type.
	/// </summary>
	public static class MemberInfoExtensions
	{
		/// <summary>
		/// Gets the type of the actual member.
		/// </summary>
		/// <param name="memberInfo">The member info to get the type from.</param>
		/// <exception cref="ArgumentNullException">If <see cref="MemberInfo"/> is null.</exception>
		/// <exception cref="NotSupportedException">If the member type is unsupported.</exception>
		/// <returns>Returns the type of the actual member.</returns>
		public static Type Type(this MemberInfo memberInfo)
		{
			if (memberInfo == null) throw new ArgumentNullException(nameof(memberInfo));

			//We don't have access to the MemberType in netstandard1.3
			FieldInfo field = memberInfo as FieldInfo;
			if (field != null)
				return field.FieldType;

			PropertyInfo property = memberInfo as PropertyInfo;
			if (property != null)
				return property.PropertyType;

			MethodInfo method = memberInfo as MethodInfo;
			if (method != null)
				return method.ReturnType;

			EventInfo e = memberInfo as EventInfo;
			if (e != null)
				return e.EventHandlerType;

			throw new NotSupportedException($"The type of the {nameof(memberInfo)} with Name: {memberInfo.Name} on Type: {memberInfo.DeclaringType} does not delcare a type.");
		}
	}
}
