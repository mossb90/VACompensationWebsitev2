using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VACompWeb.Models;
using VACompWeb.Areas.Identity.Data;


namespace VACompWeb.Services

{
    public interface IVeteranRepository
    {
        //VAUser GetVeteran(string id);
        //VAUser UpdateVeteran(VAUser vetUpdate);
        //void AddVeteran(VeteranProfileModel vet);

        float CalculateMonthlyCompensation(int dependentStatusType, int childUnder18, int child18Plus, int rating, bool spouseAid);


    }
}
