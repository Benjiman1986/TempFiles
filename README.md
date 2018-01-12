# TempFiles

# Usage

    var aisShip = new AisShip();
    
    aisShip.TelegrapheseType = telegraphese.TelegrapheseType;
    
    aisShip.Id = tel.MMSI;
    aisShip.Name = tel.ShipName;
    aisShip.AisType = source;
    aisShip.Cog = tel.COG;
    aisShip.Latitude = tel.Latitude;
    aisShip.Longitude = tel.Longitude;
              
# AisShip

using NMEALite;

namespace Demo
{
	public class AisShip
	{
		private string _name;

		public int Id { get; set; }

		public string Name
		{
			get
			{
				if (!string.IsNullOrEmpty(_name))
				{
					return _name;
				}

				return Id.ToString();
			}

			set { _name = value; }
		}

		public float Cog { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public AisTelegrapheseSourceTypes AisType { get; set; }

		public MessageTelegrapheseTypes TelegrapheseType { get; set; }
	}
}
