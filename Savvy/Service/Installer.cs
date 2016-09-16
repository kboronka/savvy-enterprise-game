using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

using sar.Tools;

namespace Savvy
{
	[RunInstaller(true)]
	public class ProjectInstaller : Installer
	{
		private ServiceProcessInstaller serviceProcessInstaller;
		private ServiceInstaller serviceInstaller;
		
		public ProjectInstaller()
		{
			serviceProcessInstaller = new ServiceProcessInstaller();
			serviceInstaller = new ServiceInstaller();
			serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
			serviceInstaller.ServiceName = AssemblyInfo.Name;
			serviceInstaller.StartType = ServiceStartMode.Automatic;
			
			this.Installers.AddRange(new Installer[] { serviceProcessInstaller, serviceInstaller });
		}
		
		private void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
		{
			var serviceController = new ServiceController(serviceInstaller.ServiceName);
			serviceController.Start();
		}
		
		public string GetContextParameter(string key)
		{
			string returnValue = "";
			try
			{
				returnValue = this.Context.Parameters[key].ToString();
			}
			catch
			{
				returnValue = "";
			}
			
			return returnValue;
		}		
	}
}
