using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
	public interface IVisitData
	{
		Visit Create(Visit visit);
		Visit GetVisitById(int Id);
		Visit GetVisitFullObjById(int Id);

		int Commit();
		IEnumerable<Visit> GetVisits(string searchTerm = null);
	}
}
