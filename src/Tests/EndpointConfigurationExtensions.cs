﻿using System;
using System.Collections.Generic;
using System.Reflection;
using NServiceBus;

public static class EndpointConfigurationExtensions
{
    public static void SetTypesToScan(this EndpointConfiguration configuration, IEnumerable<Type> typesToScan)
    {
        var methodInfo = typeof(EndpointConfiguration).GetMethod("TypesToScanInternal", BindingFlags.NonPublic | BindingFlags.Instance);
        if (methodInfo == null)
        {
            throw new Exception("Could not find 'TypesToScanInternal' field.");
        }
        methodInfo.Invoke(configuration, new object[]
        {
            typesToScan
        });
    }
}