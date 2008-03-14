﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moq.Language
{
	/// <summary>
	/// Defines the <c>Verifiable</c> verb.
	/// </summary>
	public interface IVerifies : IHideObjectMembers
	{
		/// <summary>
		/// Marks the expectation as verifiable, meaning that a call 
		/// to <see cref="Mock{T}.Verify"/> will check if this particular 
		/// expectation was met.
		/// </summary>
		/// <example>
		/// The following example marks the expectation as verifiable:
		/// <code>
		/// mock.Expect(x => x.Execute("ping"))
		///     .Returns(true)
		///     .Verifiable();
		/// </code>
		/// </example>
		void Verifiable();
	}
}
