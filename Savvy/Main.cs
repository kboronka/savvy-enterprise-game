/* Copyright (C) 2015 Kevin Boronka
 * 
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
 * LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
 * SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
 * CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
 * POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Linq;
using System.ServiceProcess;
using System.Threading;

using sar;
using Base=sar.Base;
using sar.Tools;

namespace Savvy
{
	internal sealed class Program : Base.Program
	{
		static void Main(string[] args)
		{
			try
			{
				Base.Program.LogInfo();
				
				if (!System.Environment.UserInteractive)
				{
					ServiceBase.Run(new ServiceBase[] { new Service() });
				}
				else
				{
					try
					{
						Logger.LogToConsole = true;
						
						var thread = new Thread(Service.StartServices);
						thread.Start();
						
						var hub = new CommandHub();
						Progress.Start();
						ConsoleHelper.ApplicationShortTitle();
						hub.ProcessCommands(args);
					}
					catch (Exception ex)
					{
						ConsoleHelper.WriteException(ex);

					}
					
					Progress.Stop();
					return;
				}
			}
			catch
			{
				
			}
		}
	}
}
