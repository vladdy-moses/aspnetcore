﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Patterns;

namespace Microsoft.AspNetCore.Routing
{
    internal static class EndpointFactory
    {
        public static RouteEndpoint CreateRouteEndpoint(
            string template,
            object defaults = null,
            object policies = null,
            object requiredValues = null,
            int order = 0,
            string displayName = null,
            params object[] metadata)
        {
            var routePattern = RoutePatternFactory.Parse(template, defaults, policies, requiredValues);

            return CreateRouteEndpoint(routePattern, order, displayName, metadata);
        }

        public static RouteEndpoint CreateRouteEndpoint(
            RoutePattern routePattern = null,
            int order = 0,
            string displayName = null,
            IList<object> metadata = null)
        {
            return new RouteEndpoint(
                TestConstants.EmptyRequestDelegate,
                routePattern,
                order,
                new EndpointMetadataCollection(metadata ?? Array.Empty<object>()),
                displayName);
        }
    }
}
