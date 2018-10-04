using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaFilmes.Models
{
	public class Filme
	{
		public string Id { get; set; }

		public string Titulo { get; set; }

		public int Ano { get; set; }

		public double Nota { get; set; }
	}
}