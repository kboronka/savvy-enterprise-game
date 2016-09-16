/*
 * Created by SharpDevelop.
 * User: kboronka
 * Date: 9/16/2016
 * Time: 11:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

using sar;
using sar.Tools;

namespace Savvy.Models
{
	public class Product
	{
		#region static

		private static string Path
		{
			get
			{
				var root = ApplicationInfo.CurrentDirectory;
				
				#if DEBUG
				root += @"\..\..\Models";
				#else
				root += @"\models";
				#endif
				
				return root + @"\products.xml";
			}
		}
		
		public static List<Product> GetProducts()
		{
			var products = new List<Product>();
			
			if (File.Exists(Path))
			{
				try
				{
					var reader = new XML.Reader(Path);
					
					while (reader.Read())
					{
						if (reader.NodeType == XmlNodeType.Element)
						{
							switch (reader.Name)
							{
								case "Product":
									products.Add(new Product(reader));
									break;
							}
						}
					}
				}
				catch(Exception ex)
				{
					Logger.Log(ex);
				}
			}
			
			return products;
		}
		
		public static void SaveProducts(List<Product> products)
		{
			try
			{
				var writer = new XML.Writer(Path);
				products.ForEach(p => p.Serialize(writer));
				writer.Close();
			}
			catch(Exception ex)
			{
				Logger.Log(ex);
			}
		}

		#endregion
		
		public Product(XML.Reader reader)
		{
		}
		
		public Product()
		{
			
		}
		
		public void Serialize(XML.Writer writer)
		{
			
		}
	}
}
