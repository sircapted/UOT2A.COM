using Server.Network;

namespace Server
{
    public class CurrentExpansion
	{
		private static readonly Expansion Expansion = Expansion.T2A;

		public static void Configure()
		{
			Core.Expansion = Expansion;

			bool Enabled = Core.AOS;

			ObjectPropertyList.Enabled = Enabled;
			Mobile.VisibleDamageType = Enabled ? VisibleDamageType.Related : VisibleDamageType.None;
			Mobile.GuildClickMessage = !Enabled;
			Mobile.AsciiClickMessage = !Enabled;

			// OSI-style action delay
			//Mobile.ActionDelay = TimeSpan.FromSeconds( 1.0 );

			if ( Enabled )
			{
				if ( ObjectPropertyList.Enabled )
					PacketHandlers.SingleClickProps = true; // single click for everything is overriden to check object property list
			}
		}
	}
}
