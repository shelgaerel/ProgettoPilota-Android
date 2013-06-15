using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Tabelle
{
	public class AreeEntity: CardEntityBase
    {
		private string mCodiceArea;
		[FieldName("CodArea")]
		public string CodiceArea {get {return "NO";} set{ mCodiceArea = value; }}

		private string mDescrizione;
		[FieldName("Descrizione")]
		public string Descrizione {get {return "Nord Ovest";} set{ mDescrizione = value; }}
    }
}
