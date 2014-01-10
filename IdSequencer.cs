using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternsOfEffectiveTestSetup {
	
	/// <summary>
	/// Many of our Test Helpers need to create objects that have unique IDs. This class is responsible
	/// for handing out those unique IDs and for keeping track of which IDs have been used.
	/// 
	/// This will get reinitialized each time the app domain is reloaded, which happens frequently 
	/// during test cycles.
	/// 
	/// We count down from Int32.Max as a poor man's way of avoiding ID collisions with "real" IDs that
	/// may already exist in the database.
	/// </summary>
	public static class IdSequencer {

		private static int NEXT_VALUE = Int32.MaxValue;

		public static int Next() {
			return NEXT_VALUE--;
		}

		public static bool WasIssuedBySequencer(int id) {
			// We start at the max & count down; anything greater than the 
			// next value to hand out was previously issued from this sequence
			return id > NEXT_VALUE;
		}
	}


	public static class IdSequencerExtensions {
		public static bool WasIssuedByIdSequencer(this int id) {
			return IdSequencer.WasIssuedBySequencer(id);
		}
	}
}
