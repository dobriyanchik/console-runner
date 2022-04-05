﻿using System;
using System.Collections.Generic;
using Unicorn.Taf.Api;

namespace Unicorn.TestAdapter
{
    /// <summary>
    /// Represents outcome of tests observer.
    /// </summary>
    [Serializable]
    public class ObserverOutcome : IOutcome
    {
        /// <summary>
        /// Gets list of observed test infos.
        /// </summary>
        public List<TestInfo> TestInfoList { get; } = new List<TestInfo>();
    }
}
