/*
	This file is part of Airplane++ /L
		© 2022-2023 by:
			LisiasT : http://lisias.net <support@lisias.net>

	THIS FILE is licensed to you under:

	* WTFPL - http://www.wtfpl.net
		* Everyone is permitted to copy and distribute verbatim or modified
			copies of this license document, and changing it is allowed as long
			as the name is changed.

	THIS FILE is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/
using System;
using KSPe.Util.Log;
using System.Diagnostics;

#if DEBUG
using System.Collections.Generic;
#endif

namespace AirplanePlus
{
	public static class Log
	{
		private static readonly Logger log = Logger.CreateForType<Startup>();

		public static void force(string msg, params object[] @params)
		{
			log.force(msg, @params);
		}

		public static void info(string msg, params object[] @params)
		{
			log.info(msg, @params);
		}

		public static void warn(string msg, params object[] @params)
		{
			log.warn(msg, @params);
		}

		public static void detail(string msg, params object[] @params)
		{
			log.detail(msg, @params);
		}

		public static void error(object offended, Exception e)
		{
			log.error(offended, e);
		}

		public static void error(string msg, params object[] @params)
		{
			log.error(msg, @params);
		}

		[ConditionalAttribute("DEBUG")]
		public static void dbg(string msg, params object[] @params)
		{
			log.trace(msg, @params);
		}

#if DEBUG
		private static readonly HashSet<string> DBG_SET = new HashSet<string>();
#endif

		[ConditionalAttribute("DEBUG")]
		public static void dbgOnce(string msg, params object[] @params)
		{
			string new_msg = string.Format(msg, @params);
#if DEBUG
			if (DBG_SET.Contains(new_msg)) return;
			DBG_SET.Add(new_msg);
#endif
			log.trace(new_msg);
		}
	}
}
