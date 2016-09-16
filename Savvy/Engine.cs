using System;
using System.Collections.Generic;
using System.Threading;

using sar;
using sar.Timing;
using sar.Http;
using sar.Tools;

namespace Savvy
{
	public static class Engine
	{
		public static Parameters Parameters { get; private set; }
		public static HttpServer Server { get; private set; }
		
		
		public static void ReadXMLParameters()
		{
			try
			{
				Logger.Log("Loading XML Parameters");
				Engine.Parameters = new Parameters();
				Logger.Log("Parameters Loaded");
			}
			catch (Exception ex)
			{
				Logger.Log(ex);
			}
		}
		
		public static void StartTreads()
		{
			try
			{
				var root = ApplicationInfo.CurrentDirectory;
				
				#if DEBUG
				root += @"\..\..\Http\Views";
				#else
				root += @"\views";
				#endif
				Engine.Server = new HttpServer(root);
				
				Logger.Log("Starting LED Updater thread");
				engineShutdown = false;
				engineThread = new Thread(Loop);
				engineThread.IsBackground = true;
				engineThread.Start();
				Logger.Log("Started LED Updater");
			}
			catch (Exception ex)
			{
				Logger.Log(ex);
			}
		}
		
		public static void StopThreads()
		{
			try
			{
				Logger.Log("Stopping Led Updater");
				engineShutdown = true;
				engineThread.Join();
				Logger.Log("Stopped Led Updater");
			}
			catch (Exception ex)
			{
				Logger.Log(ex);
			}
		}
		
		#region turn engine
		
		private static Thread engineThread;
		private static bool engineShutdown = false;
		
		private static void Loop()
		{
			
			var turn = new Interval(1000 * 60 * 60, 10);
			
			while (!engineShutdown)
			{
				try
				{
					if (turn.Ready)
					{
						// TODO: calculate turn
					}
					
					Thread.Sleep(1);
				}
				catch (Exception ex)
				{
					Logger.Log(ex);
					Thread.Sleep(10000);
				}
			}
		}

		#endregion
		
	}
}
