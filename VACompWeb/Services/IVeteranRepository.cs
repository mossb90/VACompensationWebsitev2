using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VACompWeb.Models;

namespace VACompWeb.Services
{
    public interface IVeteranRepository
    {
        //VeteranProfileModel GetVeteran(int vetID);
        //VeteranProfileModel UpdateVeteran(VeteranProfileModel vetUpdate);
        //void AddVeteran(VeteranProfileModel vet);

        float CalculateMonthlyCompensation(int dependentStatusType, int childUnder18, int child18Plus, int rating, bool spouseAid);


    }
}
