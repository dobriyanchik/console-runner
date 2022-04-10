﻿#if NET || NETCOREAPP
using System.Collections.Generic;
using System.Reflection;
using Unicorn.Taf.Api;
using Unicorn.Taf.Core.Engine;
using Unicorn.Taf.Core.Testing.Attributes;

namespace Unicorn.TestAdapter
{
    public class LoadContextObserver : IDataCollector
    {
        /// <summary>
        /// Gets <see cref="IOutcome"/> from specified assembly in separate assembly load context.
        /// </summary>
        /// <param name="assembly">test assembly</param>
        /// <returns>launch info as <see cref="IOutcome"/></returns>
        public IOutcome CollectData(Assembly assembly)
        {
            IEnumerable<MethodInfo> tests = TestsObserver.ObserveTests(assembly);
            ObserverOutcome outcome = new ObserverOutcome();

            foreach (var unicornTest in tests)
            {
                TestAttribute testAttribute = unicornTest.GetCustomAttribute<TestAttribute>(true);

                if (testAttribute != null)
                {
                    outcome.TestInfoList.Add(new TestInfo(unicornTest));
                }
            }

            return outcome;
        }
    }
}
#endif