using System;

using sar;
using sar.Tools;
using sar.Http;

namespace Savvy.Http.Controllers
{
	[SarController]
	[PrimaryController]
	public static class DashboardController
	{
		[PrimaryView]
		public static HttpContent View(HttpRequest request)
		{
			try
			{
				return HttpContent.Read(request.Server, @"Dashboard.html");
			}
			catch (Exception ex)
			{
				return new HttpErrorContent(ex);
			}
		}
	}
}
