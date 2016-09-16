using System;

using sar;
using sar.Tools;
using sar.Http;

namespace Savvy.Http.Controllers
{
	[SarController]
	public static class UserController
	{
		public static HttpContent LogIn(HttpRequest request)
		{
			try
			{
				return new HttpContent("TODO");
			}
			catch (Exception ex)
			{
				return new HttpErrorContent(ex);
			}
		}
		
		public static HttpContent LogOut(HttpRequest request)
		{
			try
			{
				return new HttpContent("TODO");
			}
			catch (Exception ex)
			{
				return new HttpErrorContent(ex);
			}
		}
	}
}
