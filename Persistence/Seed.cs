using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
	public class Seed
	{
		public static void SeedData(DataContext context)
		{
			if (!context.TActivity.Any())
			{
				var activity = new List<Activity>
				{
					new Activity
					{
						Title = "Past Activity 1",
						Date = DateTime.Now.AddMonths(-2),
						Description = "Activity 2 months ago",
						Category = "drinks",
						City = "London",
						Venue = "Pub",
					},
					new Activity
					{
						Title = "Past Activity 2",
						Date = DateTime.Now.AddMonths(-1),
						Description = "Activity 1 month ago",
						Category = "culture",
						City = "Paris",
						Venue = "Louvre",
					},
					new Activity
					{
						Title = "Future Activity 1",
						Date = DateTime.Now.AddMonths(1),
						Description = "Activity 1 month in future",
						Category = "culture",
						City = "London",
						Venue = "Natural History Museum",
					},
					new Activity
					{
						Title = "Future Activity 2",
						Date = DateTime.Now.AddMonths(2),
						Description = "Activity 2 months in future",
						Category = "music",
						City = "London",
						Venue = "O2 Arena",
					}
				};
				context.TActivity.AddRange(activity);
				context.SaveChanges();
			}
		}
	}
}