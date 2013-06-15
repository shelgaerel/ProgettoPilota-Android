using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Core;

namespace Core
{
    public class CardEngineBase
    {
		protected CardEntityBase mCardEntity;

		public CardEngineBase()
		{
		}

		public void SetEntity(CardEntityBase cardEntity)
		{
			mCardEntity = cardEntity;
		}

		public CardEntityBase CardEntity 
		{
			get { return mCardEntity;}
		}	
    }
}
