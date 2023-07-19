using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services.Utilities
{
	public static class Messages
	{
		#region Education
		public static class Education
		{
			public static string NotFound(bool isPlural)
			{
				if (isPlural) return "Hiç bir eğitim bulunamadı.";
				return "Böyle bir eğitim bulunamadı.";
			}
			public static string Add(string educationLevel)
			{
				return $"{educationLevel} seviyesindeki eğitimin başarıyla eklenmiştir.";
			}
			public static string Update(string educationLevel)
			{
				return $"{educationLevel} seviyesindeki eğitimin başarıyla güncellenmiştir.";
			}
			public static string Delete(string educationLevel)
			{
				return $"{educationLevel} seviyesindeki eğitimin başarıyla silinmiştir.";
			}
		}
		#endregion

		#region Experience
		public static class Experience
		{
			public static string NotFound(bool isPlural)
			{
				if (isPlural) return "Hiç bir eğitim bulunamadı.";
				return "Böyle bir eğitim bulunamadı.";
			}
			public static string Add(string educationLevel)
			{
				return $"{educationLevel} seviyesindeki eğitimin başarıyla eklenmiştir.";
			}
			public static string Update(string educationLevel)
			{
				return $"{educationLevel} seviyesindeki eğitimin başarıyla güncellenmiştir.";
			}
			public static string Delete(string educationLevel)
			{
				return $"{educationLevel} seviyesindeki eğitimin başarıyla silinmiştir.";
			}
		}
		#endregion

		#region Referance
		public static class Referance
		{
			public static string NotFound(bool isPlural)
			{
				if (isPlural) return "Hiç bir referans bulunamadı.";
				return "Böyle bir referans bulunamadı.";
			}
			public static string Add(string referanceName)
			{
				return $"{referanceName} referansın başarıyla eklenmiştir.";
			}
			public static string Update(string referanceName)
			{
				return $"{referanceName} referansın başarıyla güncellenmiştir.";
			}
			public static string Delete(string referanceName)
			{
				return $"{referanceName} referansın başarıyla silinmiştir.";
			}
		}
		#endregion

		#region Skill
		public static class Skill
		{
			public static string NotFound(bool isPlural)
			{
				if (isPlural) return "Hiç bir yetenek bulunamadı.";
				return "Böyle bir yetenek bulunamadı.";
			}
			public static string Add(string skillName)
			{
				return $"{skillName} yeteneğin başarıyla eklenmiştir.";
			}
			public static string Update(string skillName)
			{
				return $"{skillName} yeteneğin başarıyla güncellenmiştir.";
			}
			public static string Delete(string skillName)
			{
				return $"{skillName} yeteneğin başarıyla silinmiştir.";
			}
		}
		#endregion
	}
}
