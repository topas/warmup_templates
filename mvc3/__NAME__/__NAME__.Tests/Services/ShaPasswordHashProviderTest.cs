//-----------------------------------------------------------------------
// <copyright file="ShaPasswordHashProviderTest.cs" company="__COMPANY_NAME__">
//     Copyright (c) __COMPANY_NAME__. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace __NAME__.Tests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using __NAME__.Interfaces.Services;
    using NUnit.Framework;

    /// <summary>
    /// Sha password hash provider tests
    /// </summary>
    [TestFixture]
    public class ShaPasswordHashProviderTest
    {
        /// <summary>
        /// Tests CreateHash method.
        /// </summary>
        [Test]
        public void CreateHash_Test()
        {
            IPasswordHashProvider hashProvider = new __NAME__.Services.Services.ShaPasswordHashProvider();

            Assert.AreEqual(hashProvider.CreateHash("123123"), "601F1889667EFAEBB33B8C12572835DA3F027F78");
        }
    }
}
