using System;
using Core;

namespace Tabelle
{
	public class AreeEngine: CardEngineBase
	{
		public AreeEngine ()
		{
		}

		public new AreeEntity CardEntity 
		{
			get {return (AreeEntity)base.CardEntity;}
			set { mCardEntity = value; }
		}
	}
}

