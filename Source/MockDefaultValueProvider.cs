﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Moq
{
	/// <summary>
	/// A <see cref="IDefaultValueProvider"/> that returns an empty default value 
	/// for non-mockeable types, and mocks for all other types (interfaces and 
	/// non-sealed classes) that can be mocked.
	/// </summary>
	internal class MockDefaultValueProvider : EmptyDefaultValueProvider
	{
		Dictionary<MemberInfo, object> cachedMocks = new Dictionary<MemberInfo, object>();

		public override object ProvideDefault(MethodInfo member, object[] arguments)
		{
			var value = base.ProvideDefault(member, arguments);

			if (value == null &&
				member.ReturnType.IsMockeable() &&
				!cachedMocks.TryGetValue(member, out value))
			{
				var mockType = typeof(Mock<>).MakeGenericType(member.ReturnType);
				var mock = (IMock)Activator.CreateInstance(mockType);

				value = mock.Object;
				cachedMocks.Add(member, value);
			}

			return value;
		}
	}
}
