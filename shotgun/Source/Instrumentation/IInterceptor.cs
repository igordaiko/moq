﻿using System;
using System.ComponentModel;

namespace Moq.Instrumentation
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IInterceptor
	{
		bool Intercept(IInvocation invocation);
	}
}
