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
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

using sar;
using sar.Tools;

using Savvy.Models;

namespace Savvy
{
	public class Parameters : sar.Base.Configuration
	{
		private List<User> users;
		private List<Product> products;
		
		public List<User> Users { get { return users; } }
		public List<Product> Products { get { return products; } }
		
		protected override void InitDefaults()
		{
			this.users = new List<User>();
			this.products = new List<Product>();			
		}
		
		protected override void Deserialize(XML.Reader reader)
		{
			this.users = new List<User>();
			this.products = new List<Product>();

			try
			{
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.Element)
					{
						switch (reader.Name)
						{
							case "Users":
								this.users.Add(new User(reader));
								break;
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
		
		protected override void Serialize(XML.Writer writer)
		{
			this.Users.ForEach(u => u.Serialize(writer));
			this.Products.ForEach(p => p.Serialize(writer));
		}
	}
}
