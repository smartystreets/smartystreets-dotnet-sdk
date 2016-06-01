using System;
using NUnit.Framework;

namespace SmartyStreets
{
	[TestFixture]
	public class ClientTests
	{
		[Test]
		public void InitializeClient_WhateverNameHere()
		{
			var client = new Client();
			Assert.IsNotNull(client);
		}
	}
}