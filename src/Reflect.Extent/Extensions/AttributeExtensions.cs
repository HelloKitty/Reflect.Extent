using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Reflect.Extent
{
	/// <summary>
	/// Extension methods for attribute reading and parsing.
	/// </summary>
    public static class AttributeExtensions
    {
		/// <summary>
		/// Checks if the provided <see cref="MemberInfo"/> <paramref name="provider"/> contains
		/// the specified <typeparamref name="TAttributeType"/>.
		/// </summary>
		/// <typeparam name="TAttributeType">The attribute type to check for.</typeparam>
		/// <param name="provider">The <see cref="MemberInfo"/> provider.</param>
		/// <returns>True if the <see cref="MemberInfo"/> is marked with the <typeparamref name="TAttributeType"/> attribute.</returns>
	    public static bool HasAttribute<TAttributeType>(this MemberInfo provider)
			where TAttributeType : Attribute

	    {
		    return provider.GetCustomAttribute<TAttributeType>() != null;
	    }

		//TODO: Maybe use?
	    private static bool CheckSubclassedAttribute(Type requested, Type acual)
	    {
		    if (requested == null) throw new ArgumentNullException(nameof(requested));
		    if (acual == null) throw new ArgumentNullException(nameof(acual));

		    return true;
	    }
    }
}
