using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RepairMan.DataClasses.Common;
using RepairMan.DataClasses.Motoring;
using RepairMan.DataClasses.Repairing;
using RepairMan.DataClasses.Repairing.Diagnostic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RepairMan.DataAccess
{
	public class SampleDataRepo
	{

		public SampleDataRepo(RepairManContext context)
		{
			context.Add(new Workshop()
			{
				Name = "J & G Reparaciones",
				Owner = context.Users.FirstOrDefault(),
				ImageUrl = "https://isoceles.ferreirapablo.com/rp/images/resources/repairplace.jpg",
				Description = "Reparamos vehiculos de todas las clases, estamos especializados en fallas electricas con certificaciones internacionales que apoyan nuestra tecnica.",
				Geoposition = new Geoposition()
				{
					Latitude = 18.453463F,
					Longitude = -69.931063484F,
					Date = DateTime.UtcNow
				},
				Categorization = new List<WorkshopCategorization>
				{
					new WorkshopCategorization() {	
						WorkshopCategory = new WorkshopCategory()
						{
							Name = "Electricista",
							Color = "#ffc107"
						}
					}
				},
				ModelSpecializations = new List<ModelSpecialization>
				{
					new ModelSpecialization() {
						Model = context.Models.First(x => x.Brand.Name.Contains("Volkswagen"))
					}
				},

				BrandSpecializations = new List<BrandSpecialization>
				{
					new BrandSpecialization() {
						Brand = context.Brands.First(x => x.Name.Contains("Volvo"))
					}
				},
				Contact = new Contact()
				{
					FirstName = "Pablo",
					LastName = "Ferreira",
					Address = "Calle Francisco Dominguez Charro #36",
					Email = "ceo@ferreirapablo.com",
					PhoneNumber = "8093028096"
				},
                IsActive = true,
			}) ;

			context.SaveChanges();

			context.Pronostics.Add(new Pronostic()
			{
				Name = "No tienes combustible",
				Description = "Debe echar combustible al tanque de su vehículo, diríjase en otro medio de transporte a la estación de combustible más cercana o solicite la asistencia de una persona que le pueda suministrar el combustible necesario para llegar a la estación más cercana.",
				Questions = new List<PronosticQuestion>()
				{
					new PronosticQuestion()
					{
						Question = new Question()
						{
							Description = "¿Tiene combustible?",
							AffirmativeAnswer = "No",
							NegativeAnswer = "Si"
						}
					}
				}
			});

			context.SaveChanges();

			context.Pronostics.Add(new Pronostic()
			{
				Name = "Puede ser un problema electrico.",
				Description = "Es probable que exista algún problema de batería. Verifique la batería, limpie los polos y apriete los terminales. Intente de nuevo encender el vehículo.",
				Questions = new List<PronosticQuestion>()
				{
					new PronosticQuestion()
					{
						Question = new Question()
						{
							Description = "¿Las luces del vehículo encienden?",
							AffirmativeAnswer = "No",
							NegativeAnswer = "Si"
						},
					},
					new PronosticQuestion()
					{
						Question = new Question()
						{
							Description = "¿Está la palanca de los cambios en la letra P (parqueo) o en la letra N (neutro)?",
							AffirmativeAnswer = "Si",
							NegativeAnswer = "No"
						}
					},
					
				}
			});

			context.SaveChanges();

			var workShopId = context.Workshops.First().WorkshopId.ToString();
			context.Advertisements.Add(new DataClasses.Advertising.Advertisement()
			{
				Name = "Anuncio descuento",
				ImageUrl = "https://www.strongspares.co.uk/image/cache/catalog/products/Fabric/Yellows/canary-yellow-2x2-weave-1025-900g-sqm-550x550.JPG",
				Url = "#profile/repair.html?id=" + workShopId,
				Description = "Obten 20% de descuento en mantenimiento.",
				Context = new DataClasses.Advertising.AdvertisementContext()
				{
					Url = "diagnostic/index.html"
				},
				Relevance = 1
			});
			context.SaveChanges();
		}
	}
}
