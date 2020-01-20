// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Wangkanai.Detection.Models;

namespace Wangkanai.Detection.Extensions
{
    internal static class UserAgentExtensions
    {
        public static UserAgent UserAgentFromHeader(this HttpContext context)
            => new UserAgent(context.Request.Headers["User-Agent"].FirstOrDefault());

        public static bool IsNullOrEmpty(this UserAgent agent)
            => agent == null
               || string.IsNullOrEmpty(agent.ToLower());

        public static string ToLower(this UserAgent agent)
            => agent.ToString().ToLower();

        public static int Length(this UserAgent agent)
            => agent.ToString().Length;

        public static bool Contains(this UserAgent agent, string word)
            => agent.ToLower().Contains(word.ToLower());

        public static bool Contains(this UserAgent agent, string[] array)
            => !agent.IsNullOrEmpty()
               && array.Any(agent.Contains);

        public static bool Contains<T>(this UserAgent agent, T t) where T : Enum
            => agent.Contains(t.ToString().ToLower());

        public static bool StartsWith(this UserAgent agent, string word)
            => !agent.IsNullOrEmpty()
               && agent.ToLower().StartsWith(word.ToLower());

        public static bool StartsWith(this UserAgent agent, string[] array)
            => array.Any(agent.StartsWith);

        public static bool StartsWith(this UserAgent agent, string[] array, int minimum)
            => agent.Length() >= minimum
               && agent.StartsWith(array);
    }
}