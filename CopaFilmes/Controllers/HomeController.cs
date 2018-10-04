using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CopaFilmes.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CopaFilmes.Controllers
{
	public class HomeController : Controller
	{
		
		private List<Filme> GetAllFilmes()
		{
			try
			{
				string URI = "http://copafilmes.azurewebsites.net/api/filmes";

				var ListaFilmes = new List<Filme>();

				using (var client = new HttpClient())
				{

					using (var response = client.GetAsync(URI).Result)
					{
						if (response.IsSuccessStatusCode)
						{
							var FilmeJsonString = response.Content.ReadAsStringAsync().Result;
							ListaFilmes = JsonConvert.DeserializeObject<Filme[]>(FilmeJsonString).ToList();
						}

					}
				}
				return ListaFilmes;

			}
			catch (Exception ex)
			{

				throw;
			}
		}

		
		public ActionResult Index()
		{
			//Filme filmes = new Filme();
			
			
		   var filmes =   GetAllFilmes();
			filmes = filmes.OrderBy(c => c.Titulo).ToList();

			return View(filmes);
		}


		private List<Filme> ComparaTitulo(List<Filme> lista)
	    {
			var grupo1 = new List<Filme>();
			var grupo2 = new List<Filme>();
			var grupo3 = new List<Filme>();
			var vencedores = new List<Filme>();
			int meio = (lista.Count / 2);
			
			for (int i = 0; i < lista.Count; i++)			
			{
				if (i < meio)
				{
					grupo1.Add(lista[i]);
				}
				else
				{
					grupo2.Add(lista[i]);
				}

			}

			
			for (int i = 0; i < grupo1.Count; i++) 
			{
				if (grupo1[i].Nota > grupo2[(grupo2.Count - 1) - i].Nota)				
				{
					grupo3.Add(grupo1[i]);
				}
				else // compara grupo1 com grupo2
				{
					if (grupo1[i].Nota < grupo2[(grupo2.Count - 1) - i].Nota)
					{
						grupo3.Add(grupo2[(grupo2.Count - 1) - i]);
					}
					else
					{
						if (grupo1[i].Titulo == grupo2[(grupo2.Count - 1) - i].Titulo)
						{
							if (grupo1[i].Titulo.ToLower().CompareTo(grupo2[(grupo2.Count - 1) - i].Titulo.ToLower()) < 0)
							{
								grupo3.Add(grupo1[i]);
							}
							else
							{
								grupo3.Add(grupo2[(grupo2.Count - 1) - i]);
							}

						}
					}

				}
			}

			meio = (grupo3.Count / 2);
			   
			for (int i=0; i < grupo3.Count; i+=2) // procura vencedores
			{
				if (i <= meio)
				{
					if (grupo3[i].Nota > grupo3[i+1].Nota)
					{
						vencedores.Add(grupo3[i]);
					}
					else if (grupo3[i].Nota < grupo3[i+1].Nota)
						{
							vencedores.Add(grupo3[i+1]);
						}
						else if (grupo3[i].Nota == grupo3[i + 1].Nota)
						{
							if (grupo3[i].Titulo.ToLower().CompareTo(grupo3[i+1].Titulo.ToLower())  < 0)
							{
								vencedores.Add(grupo3[i]);
							}
							else
							{
								vencedores.Add(grupo3[i+1]);
							}
						}
					}
			}


			vencedores = vencedores.OrderByDescending(v => v.Nota).ToList();

			return vencedores;
 		}

		[HttpPost]
		public ActionResult ExibeVencedor(string[] chkfilmes)
		{
			try
			{
				string URI = "http://copafilmes.azurewebsites.net/api/filmes";

				var ListaFilmes = new List<Filme>();
				var Selecionados = new List<Filme>();

				using (var client = new HttpClient())
				{

					using (var response = client.GetAsync(URI).Result)
					{
						if (response.IsSuccessStatusCode)
						{
							var FilmeJsonString = response.Content.ReadAsStringAsync().Result;
							ListaFilmes = JsonConvert.DeserializeObject<Filme[]>(FilmeJsonString).ToList();
						}

					}
				}

				ListaFilmes = ListaFilmes.Where(x => chkfilmes.Contains(x.Id)).ToList();
				
				// Ordenação por Titulo
				ListaFilmes = ListaFilmes.OrderBy(c => c.Titulo).ToList();
				
				ListaFilmes = ComparaTitulo(ListaFilmes);
				
				return View(ListaFilmes);

			}
			catch (Exception ex)
			{

				throw;
			}

		}
		
	}
}