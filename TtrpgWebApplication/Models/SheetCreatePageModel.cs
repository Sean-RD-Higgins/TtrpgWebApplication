using TtrpgLibrary.Models;

namespace TtrpgWebApplication.Models
{
    public class SheetCreatePageModel
	{
		public Ttrpg Ttrpg { get; set; }

		public SheetCreatePageModel(Ttrpg ttrpg)
		{
			Ttrpg = ttrpg;
		}
	}
}
